using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public bool isAlive = true;
    private float currentDeathTime=3.7f;
    private float defaultDeathTime = 4f;
    private int maxHealth=100;
    private int currentHealth;
    private CharacterAnimations charAnim;
    [SerializeField] private Healthbar enemyHealthBar;
    [SerializeField] private GameObject Enemy;
    private EnemyMovement enemyMovement;
    void Awake()
    {
        currentHealth = maxHealth;
        enemyHealthBar.SetMAXhealthbar(maxHealth);
        charAnim = GetComponent<CharacterAnimations>();
        enemyMovement = GetComponentInParent<EnemyMovement>();
    }

    private void Update()
    {
        if (currentHealth <=0) 
        {
            isAlive = false;
            enemyMovement.DisableEenmyCollider();
            EnemyDeathAniamtion();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tags.Hand_ATTACK)&& currentHealth > 0)
        { 
            Damage(10);
            charAnim.Hit();
        }
        else if (other.CompareTag(Tags.LEG_ATTACK)&& currentHealth > 0)
        { 
            Damage(20);         
            charAnim.Hit();
        }
    }
    private void Damage(int damage)
    {
        if(currentHealth > 0)
        {
            currentHealth -= damage;
            enemyHealthBar.SetHealthbar(currentHealth);
        }
    }

    private void  DeleteEnemy()
    { 
        Destroy(Enemy);
    }
    public void EnemyDeathAniamtion()
    {
        currentDeathTime += Time.deltaTime;
        if(currentDeathTime > defaultDeathTime) 
        {
            charAnim.Death();
            Debug.Log(currentHealth);
            currentDeathTime = 0;
        }
    }
    private void StopMovement()
    {
        enemyMovement.enabled = false;
    }
    private void KeepMovement()
    {
        enemyMovement.enabled=true;
    }
}
