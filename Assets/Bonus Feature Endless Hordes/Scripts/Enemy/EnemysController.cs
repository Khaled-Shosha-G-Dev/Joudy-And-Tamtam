using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemysController : MonoBehaviour
{
    [Tooltip("Distance from the troops controller to the enemy point.")]
    [SerializeField] private float _startDistance = 10f;
    [SerializeField] private float _enemySpeed = 3f;
    private Vector3 initialPos = Vector3.zero;


    public float timeBetweenSpawns = 3f;
    
    public EnemyTroop enemyPrefab;
    List<EnemyTroop> transforms = new List<EnemyTroop>();
    
    #region SINGLETON
    public static EnemysController Instance = null;
    #endregion
    void Awake()
    {
        if(Instance != null)
            Debug.LogError("CANNOT HAVE MORE THAN ONE ENEMYSCONTROLLER IN THE SCENE.");
        
        Instance = this; 
        initialPos = transform.position;
    }

    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn(){
        while(true){
            transforms.Add(Instantiate(enemyPrefab, null, true));
            transforms[transforms.Count - 1].transform.position = initialPos + transform.forward * _startDistance;
            yield return HelperFunctions.GetWaitForSeconds(timeBetweenSpawns);
        }
    }

    void Update()
    {
        foreach(var child in transforms){
            child.transform.Translate(-child.transform.forward * _enemySpeed * Time.deltaTime);
        }
    }

    public void RemoveEnemyTroop(EnemyTroop troop){
        transforms.Remove(troop);
    }
    void OnDrawGizmos()
    {
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.color = Color.red;
        

        Vector3 cubeDimensions = new Vector3(GetComponent<TroopsController>().GetBoundingVolume.width, 3f, 1f);
        Gizmos.DrawCube(Vector3.forward * _startDistance, cubeDimensions);
    }
}
