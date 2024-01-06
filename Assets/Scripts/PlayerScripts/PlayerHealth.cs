using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public bool isAlive = true;
    private float currentDeathTime = 3.7f;
    private float defaultDeathTime = 4f;
    private int maxHealth = 100;
    private int currentHealth;
    private CharacterAnimations charAnim;
    [SerializeField] private Healthbar PlayerHealthBar;
    [SerializeField] private GameObject player;
    void Awake()
    {
        currentHealth = maxHealth;
        PlayerHealthBar.SetMAXhealthbar(maxHealth);
        charAnim = GetComponent<CharacterAnimations>();
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            isAlive = false;
            PlayerDeathAniamtion();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tags.Enemy_Hand_ATTACK) && currentHealth > 0)
        {
            Damage(5);
            charAnim.Hit();
        }
        else if (other.CompareTag(Tags.Enemy_LEG_ATTACK) && currentHealth > 0)
        {
            Damage(10);
            charAnim.Hit();
        }
    }
    private void Damage(int damage)
    {
        if (currentHealth > 0)
        {
            currentHealth -= damage;
            PlayerHealthBar.SetHealthbar(currentHealth);
        }
    }
    public void PlayerDeathAniamtion()
    {
        currentDeathTime += Time.deltaTime;
        if (currentDeathTime > defaultDeathTime)
        {
            charAnim.Death();
            Debug.Log(currentHealth);
            currentDeathTime = 0;
        }
    }
    //character delegate function
    private void DeletePlayer()
    {
        Destroy(player);
    }
}
