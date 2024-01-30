using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Troop : MonoBehaviour
{
    private Animator _animator;

    void Start(){
        _animator = GetComponent<Animator>();
        _animator.avatar = transform.GetChild(0).GetComponent<Animator>().avatar;
    }

    public void NotifyTroops(float speed){
        _animator.SetFloat("Speed", speed);
    }
}
