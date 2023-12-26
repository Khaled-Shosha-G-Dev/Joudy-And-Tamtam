using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private int maxHealth=100;
    private int currentHealth;
    [SerializeField] private Healthbar enemyHealthBar;
    [SerializeField] private GameObject Enemy;
    void Awake()
    {
        currentHealth = maxHealth;
        enemyHealthBar.SetMAXhealthbar(maxHealth);
    }

    private void Update()
    {
        if (currentHealth <=0) 
        {
            Destroy(Enemy);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tags.Hand_ATTACK))
            Damage(10);
        else if (other.CompareTag(Tags.lEG_ATTACK))
            Damage(20);
    }
    private void Damage(int damage)
    {
        if(currentHealth > 0)
        {
            currentHealth -= damage;
            enemyHealthBar.SetHealthbar(currentHealth);
        }
    }
}
