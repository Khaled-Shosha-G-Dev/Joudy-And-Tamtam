using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemysDisposer : MonoBehaviour
{
    public float disposeDistance;
    public const int MAXCAPACITY = 60;
    List<EnemyTroop> enemysToDispose = new List<EnemyTroop>(MAXCAPACITY);

    void Update()
    {
        var enemytroops = EnemysController.Instance.GetEnemyTroops;
        foreach(var enemy in enemytroops){
            if(IsNear(enemy.transform.position)){
                enemysToDispose.Add(enemy);
            }
        }

        foreach(var enemy in enemysToDispose){
            enemy.Die(); //disposes the enemy
        }

        enemysToDispose.Clear();
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, disposeDistance);
    }
    bool IsNear(Vector3 pos){
        return (transform.position - pos).sqrMagnitude < disposeDistance * disposeDistance; 
    }
}
