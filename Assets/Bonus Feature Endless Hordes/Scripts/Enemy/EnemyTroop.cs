using UnityEngine;

public class EnemyTroop : MonoBehaviour, IDamagable
{
    [SerializeField] private float _health = 100f;

    public EnemyData Data;

    public void Initialize(EnemyData enemyData){
        Data = enemyData;
    }
    public void TakeDamage(float damage)
    {
        _health -= damage;
        if(_health <= 0f)
            Die();
    }

    public void Die(){
        EnemysController.Instance.RemoveEnemyTroop(this);
    }
}