using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Troop : MonoBehaviour, IDamagable
{
    private Animator _animator;
    
    private float _health = 100f;

    [HideInInspector] public Transform leftHandIKReference = null;
    [HideInInspector] public Transform rightHandIKReference = null;

    private Weapon _weaponReference = null;

    void Awake()
    {
        //IT IS EXPECTED THAT THE CHARACTER MODEL IS THE FIRST IN THE TRANSFORM TREE, 
        //IF YOU RUN INTO ANY ERRORS MAKE SURE THAT IT'S IN TOP OF THE CHILDREN HIERACHY
        var characterTransform = transform.GetChild(0).transform;
        for(int i = 0; i < characterTransform.childCount; i++){
            var child = characterTransform.GetChild(i);
            if(child.CompareTag("LeftHandIK")){
                leftHandIKReference = child.transform;
            }
            else if (child.CompareTag("RightHandIK")){
                rightHandIKReference = child.transform;
            }
        }

        if(leftHandIKReference == null || rightHandIKReference == null){
            Debug.LogError("NO HAND REFERENCE FOUND," + 
            "MAKE SURE THEY EXIST UNDER THE CHARACTER MODEL WITH THE APPROPRIATE TAGS " + 
            "AND THAT THE CHARACTER MODEL IS IN TOP OF THE CHILDREN HIERACHY AS THE CODE EXPECTS IT IN INDEX 0. " + 
            "FOR MORE INFO LOOK AT THE AWAKE FUNCTION IN THIS SCRIPT");
        }
    }
    void Start(){
        _animator = GetComponent<Animator>();
        _animator.avatar = transform.GetChild(0).GetComponent<Animator>().avatar;
        Destroy(transform.GetChild(0).GetComponent<Animator>()); //Destroys The Animator
    }
    
    public void InitializeWeapon(Weapon weapon){
        _weaponReference = Instantiate(weapon, this.transform, false);
        _weaponReference.Initialize();
    }

    public void NotifyTroops(float speed){
        _animator.SetFloat("Speed", speed);
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        if(_health <= 0f)
            Die();
    }

    private void Die(){
        TroopsController.Instance.RemoveTroop(this);
        Destroy(gameObject);
    }
}
