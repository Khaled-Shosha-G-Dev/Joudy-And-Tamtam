using UnityEngine;

public class EnemyTroop : MonoBehaviour, IDamagable
{
    [SerializeField]private float _health = 100f;


    private Animator _animator = null;
    void Start()
    {
        _animator = GetComponent<Animator>();
        if(transform.GetChild(0).TryGetComponent<Animator>(out var animator)){
            _animator.avatar = animator.avatar;
            Destroy(animator);
        }
    }
    public void TakeDamage(float damage)
    {
        _health -= damage;
        if(_health <= 0f)
            Die();
    }

    private void Die(){
        EnemysController.Instance.RemoveEnemyTroop(this);

        Destroy(gameObject);
    }
}