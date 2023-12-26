using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //player
    private Transform playerPos;

    private float disctanceBetweenPlayerAndEnemy;
    [SerializeField] private float attackDistance;

    [SerializeField]private float speed;

    private Rigidbody myBody;

    // Start is called before the first frame update
    void Awake()
    {
        playerPos = GameObject.FindWithTag("Player")?.transform;
        myBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        DistacneCalculater();
    }
    private void FixedUpdate()
    {
         CatchPlayer();
    }

    private void CatchPlayer()
    {
        if(disctanceBetweenPlayerAndEnemy>attackDistance)
        {
            transform.LookAt(playerPos.position);
            myBody.velocity = transform.forward * speed;
        }
        else
        {
            transform.LookAt(playerPos.position);
            myBody.velocity = Vector3.zero; 
            //Attack on Player
        }
    }
    private void DistacneCalculater()
    {
        disctanceBetweenPlayerAndEnemy = Vector3.Distance(transform.position , playerPos.position);
    }
}
