using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

class Troop : MonoBehaviour
{
    private Animator _animator;

    public Transform leftHandIKReference = null;
    public Transform rightHandIKReference = null;

    public Weapon weaponPrefab;

    private Weapon weaponReference = null;

    void Awake()
    {
        //IT IS EXPECTED THAT THE CHARACTER MODEL IS THE FIRST IN THE TRANSFORM TREE, 
        //IF YOU RUN INTO ANY ERRORS MAKE SURE THAT IT'S IN TOP OF THE HIERACHY
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
    }
    void Start(){
        _animator = GetComponent<Animator>();
        _animator.avatar = transform.GetChild(0).GetComponent<Animator>().avatar;

        weaponReference = Instantiate(weaponPrefab, this.transform, false);
    }

    public void NotifyTroops(float speed){
        _animator.SetFloat("Speed", speed);
    }
}
