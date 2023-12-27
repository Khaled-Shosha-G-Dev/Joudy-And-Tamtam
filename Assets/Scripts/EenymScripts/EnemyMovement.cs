using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //player
    private Transform playerPos;

    //Walking Distance
    private float disctanceBetweenPlayerAndEnemy;

    //Attacking Distance
    [SerializeField] private float attackDistance;

    //Walking speed
    [SerializeField]private float speed;

    private EnemyHealth health;

    private CharacterAnimations charAnim;

    private EnemyAttack enemyAttack;

    private Rigidbody myBody;

    // Start is called before the first frame update
    void Awake()
    {
        playerPos = GameObject.FindWithTag("Player")?.transform;

        charAnim = GetComponentInChildren<CharacterAnimations>();

        health = GetComponentInChildren<EnemyHealth>();

        enemyAttack = GetComponent<EnemyAttack>();
        myBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        DistacneCalculater();
        EnemyAnimatioin();
    }
    private void FixedUpdate()
    {
         CatchPlayer();
    }

    private void CatchPlayer()
    {
        if(disctanceBetweenPlayerAndEnemy>attackDistance && health.isAlive)
        {
            transform.LookAt(playerPos.position);
            myBody.velocity = transform.forward * speed;
            charAnim.Walk(true);
        }
        else if(health.isAlive && disctanceBetweenPlayerAndEnemy <= attackDistance) 
        {
            charAnim.Walk(false);
            transform.LookAt(playerPos.position);
            myBody.velocity = Vector3.zero; 
            //Attack on Player
        }
    }
    private void DistacneCalculater()
    {
        disctanceBetweenPlayerAndEnemy = Vector3.Distance(transform.position , playerPos.position);
    }
    private void EnemyAnimatioin()
    {
        if (disctanceBetweenPlayerAndEnemy > attackDistance && health.isAlive)
        {
            charAnim.Walk(true);
        }
        else if (health.isAlive && disctanceBetweenPlayerAndEnemy <= attackDistance)
        {
            charAnim.Walk(false);
            enemyAttack.EnemyAttacks();
        }
        //else if(!health.isAlive)
        //    health.EnemyDeathAniamtion();

    }
}
