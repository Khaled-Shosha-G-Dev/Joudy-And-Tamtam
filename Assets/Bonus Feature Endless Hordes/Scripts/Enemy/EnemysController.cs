using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using System.Linq;

public class EnemysController : MonoBehaviour
{
    [Tooltip("Distance from the troops controller to the enemy point.")]
    [SerializeField] private float _startDistance = 10f;
    [SerializeField] private float _enemySpeed = 3f;
    private Vector3 initialPos = Vector3.zero;
    public float timeBetweenSpawns = 3f;
    public EnemyTroop enemyPrefab;
    List<EnemyTroop> transforms = new List<EnemyTroop>();
    public List<EnemyTroop> GetEnemyTroops => transforms;
    public SpawnerData spawnerPreset;
    public float distanceBetweenCenterAndSpawnEntities = 2f;
    public int level = 1;
    public Dictionary<EnemyData, ObjectPool<EnemyTroop>> enemysPoolDictionary = new Dictionary<EnemyData, ObjectPool<EnemyTroop>>();

    private TroopInstanceDrawer instancesDrawer;

    #region SINGLETON
    public static EnemysController Instance = null;
    #endregion
    void Awake()
    {
        instancesDrawer = gameObject.AddComponent<TroopInstanceDrawer>();

        if(Instance != null)
            Debug.LogError("CANNOT HAVE MORE THAN ONE ENEMYSCONTROLLER IN THE SCENE.");
        
        Instance = this; 
        initialPos = transform.position;

        foreach(var level in spawnerPreset.levels){
            foreach(var type in level.types){
                if(!enemysPoolDictionary.ContainsKey(type)){
                    enemysPoolDictionary[type] = new ObjectPool<EnemyTroop>(
                        () => { GameObject troop = new GameObject("enemyTroop"); 
                        var rigid = troop.AddComponent<Rigidbody>();
                        rigid.isKinematic = true;
                        var capsule = troop.AddComponent<CapsuleCollider>();
                        capsule.center = Vector3.up;
                        capsule.radius = 0.4f;
                        capsule.height = 2f;
                        capsule.isTrigger = true;
                        return troop.AddComponent<EnemyTroop>(); },
                        enemy => {enemy.gameObject.SetActive(true);},
                        enemy => {enemy.gameObject.SetActive(false);},
                        enemy => {Destroy(enemy.gameObject);}, true, 30, 40
                    );
                }
            }
        }


    }

    void Start()
    {
        StartCoroutine(Spawn(transform.right * distanceBetweenCenterAndSpawnEntities + initialPos + transform.forward * _startDistance));
        StartCoroutine(Spawn(transform.right * -distanceBetweenCenterAndSpawnEntities + initialPos + transform.forward * _startDistance));
    }

    IEnumerator Spawn(Vector3 center){
        while(true){
            List<EnemyData> enemiesInCurrentLevel = new List<EnemyData>();
            foreach(var enemy in spawnerPreset.levels[level - 1].types){
                enemiesInCurrentLevel.Add(enemy);
            }


            //Stupid Propability log
            int stupidRandomNumberForNow = Random.Range(1, 6);
            var possibleEnemiesToSpawn = new List<EnemyData>();
            if(stupidRandomNumberForNow == 6){
                possibleEnemiesToSpawn.AddRange(from enemy in enemiesInCurrentLevel 
                where enemy.probability == Probability.Low 
                select enemy);
            }
            else {
                possibleEnemiesToSpawn.AddRange(from enemy in enemiesInCurrentLevel 
                where enemy.probability == Probability.High 
                select enemy);
            }
            if(possibleEnemiesToSpawn.Count == 0) yield return null; // list is empty

            var enemyToSpawn = possibleEnemiesToSpawn[Random.Range(0, possibleEnemiesToSpawn.Count)];

            switch(enemyToSpawn.type){
                case EnemyType.Minion:
                    SpawnMinions(enemyToSpawn, center);
                    break;
                case EnemyType.Boss:
                    SpawnBoss(enemyToSpawn, center);
                    break;
                case EnemyType.Prop:
                    SpawnProp(enemyToSpawn, center);
                    break;
                default:
                    Debug.LogError("EnemyType Undefined");
                    break;
            }
            yield return HelperFunctions.GetWaitForSeconds(timeBetweenSpawns);
        }
    }

    void SpawnMinions(EnemyData enemy, Vector3 center){
        for(int i = 0; i < enemy.spawnCount; i++){
            var enemyInstance = enemysPoolDictionary[enemy].Get();
            enemyInstance.Initialize(enemy);
            float x = Random.Range(-distanceBetweenCenterAndSpawnEntities, distanceBetweenCenterAndSpawnEntities);
            float z = Random.Range(-distanceBetweenCenterAndSpawnEntities, distanceBetweenCenterAndSpawnEntities);
            Vector3 randomPosInABox = new Vector3(x, 0, z);
            enemyInstance.transform.position = center + randomPosInABox;
            enemyInstance.transform.rotation = transform.rotation;
            enemyInstance.transform.Rotate(0f, -180f, 0f);
            transforms.Add(enemyInstance);
        }
    }
    void SpawnBoss(EnemyData boss, Vector3 center){

    }
    void SpawnProp(EnemyData prop, Vector3 center){

    }
    void Update()
    {
        foreach(var child in transforms){
            child.transform.Translate(-child.transform.forward * _enemySpeed * Time.deltaTime);
            if(!instancesDrawer.transformInstances.ContainsKey(child.Data.modelPrefab)){
                instancesDrawer.transformInstances.Add(child.Data.modelPrefab, new List<Matrix4x4>());
            }
            instancesDrawer.transformInstances[child.Data.modelPrefab].Add(child.transform.localToWorldMatrix);
        }
    }

    public void RemoveEnemyTroop(EnemyTroop troop){
        transforms.Remove(troop);
        enemysPoolDictionary[troop.Data].Release(troop);
        
    }
    void OnDrawGizmos()
    {
        if(initialPos == Vector3.zero){
            initialPos = transform.position;
        }
        Gizmos.color = Color.red;
        Vector3 center = Vector3.up + (transform.forward * _startDistance) + initialPos;
        Gizmos.DrawSphere(transform.right * distanceBetweenCenterAndSpawnEntities + center, 1f);
        Gizmos.DrawWireCube(transform.right * distanceBetweenCenterAndSpawnEntities + center, 2f *Vector3.one * distanceBetweenCenterAndSpawnEntities);
        Gizmos.DrawSphere(-transform.right * distanceBetweenCenterAndSpawnEntities + center, 1f);
        Gizmos.DrawWireCube(-transform.right * distanceBetweenCenterAndSpawnEntities + center, 2f * Vector3.one * distanceBetweenCenterAndSpawnEntities);
    }
}
