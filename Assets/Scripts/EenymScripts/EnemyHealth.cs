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
    void Awake()
    {
        currentHealth = maxHealth;
        enemyHealthBar.SetMAXhealthbar(maxHealth);
        charAnim = GetComponent<CharacterAnimations>();
    }

    private void Update()
    {
        if (currentHealth <=0) 
        {
            isAlive = false;
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
        else if (other.CompareTag(Tags.lEG_ATTACK)&& currentHealth > 0)
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
}
