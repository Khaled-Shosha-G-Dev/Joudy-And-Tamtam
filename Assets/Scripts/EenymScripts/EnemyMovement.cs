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

    //Attacking
    private EnemyAttack enemyAttack;

    //Walking speed
    [SerializeField]private float speed;

    //EnemyHealth
    private EnemyHealth health;

    //Combonent
    private Rigidbody myBody;
    private Collider myCollider;

    //Animation
    private CharacterAnimations charAnim;

    // Start is called before the first frame update
    void Awake()
    {
        playerPos = GameObject.FindWithTag("Player")?.transform;

        charAnim = GetComponentInChildren<CharacterAnimations>();

        health = GetComponentInChildren<EnemyHealth>();

        enemyAttack = GetComponent<EnemyAttack>();
        myBody = GetComponent<Rigidbody>();
        myCollider = GetComponent<Collider>();

    }

    // Update is called once per frame
    void Update()
    {
        if (playerPos != null)
        {
            DistacneCalculater();
            EnemyAnimatioin();
        }
    }
    private void FixedUpdate()
    {
        if (playerPos != null)
            CatchPlayer();
    }

    private void CatchPlayer()
    {
        if(disctanceBetweenPlayerAndEnemy>attackDistance && health.isAlive )
        {
            transform.LookAt(playerPos.position);
            myBody.velocity = transform.forward * speed;
        }
        else if(health.isAlive && disctanceBetweenPlayerAndEnemy <= attackDistance ) 
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
    public void DisableEenmyCollider()
    {
        if (!health.isAlive)
        {
            myBody.useGravity = false;
            myCollider.enabled = false;
        }
    }
}
