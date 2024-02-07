using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemysController : MonoBehaviour
{
    [Tooltip("Distance from the troops controller to the enemy point.")]
    [SerializeField] private float _startDistance = 10f;

    private Vector3 initialPos = Vector3.zero;


    public float timeBetweenSpawns = 3f;
    
    public Transform enemyPrefab;
    List<Transform> transforms = new List<Transform>();
    void Awake()
    {
        initialPos = transform.position;
    }

    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn(){
        while(true){
            transforms.Add(Instantiate(enemyPrefab, null, true));
            transforms[transforms.Count - 1].position = initialPos + transform.forward * _startDistance;
            yield return HelperFunctions.GetWaitForSeconds(timeBetweenSpawns);
        }
    }

    void Update()
    {
        foreach(var transform in transforms){
            transform.Translate(-transform.forward * 5f * Time.deltaTime);
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.color = Color.red;
        

        Vector3 cubeDimensions = new Vector3(GetComponent<TroopsController>().GetBoundingVolume.width, 3f, 1f);
        Gizmos.DrawCube(Vector3.forward * _startDistance, cubeDimensions);
    }
}
