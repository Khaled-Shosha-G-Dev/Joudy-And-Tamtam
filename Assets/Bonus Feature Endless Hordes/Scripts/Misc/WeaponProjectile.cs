using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponProjectile : MonoBehaviour
{
    public delegate void UpdateWeapon(WeaponProjectile projectile);
    public delegate void OnCollide(IDamagable collision);
    public void InitializeProjectile(UpdateWeapon updateWeapon, OnCollide collide, float lifetime){
        _UpdateMethod = updateWeapon;
        _CollideMethod = collide;
        //KillProjectile(lifetime);
    }
    private UpdateWeapon _UpdateMethod;
    private OnCollide _CollideMethod;
    void Update()
    {
        _UpdateMethod(this);
    }

    IEnumerator KillProjectile(float lifetime){
        yield return HelperFunctions.GetWaitForSeconds(lifetime);
        WeaponProjectileFactory.Instance.Pool.Release(this);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<IDamagable>(out IDamagable damagable)){
            _CollideMethod(damagable);
        }
        WeaponProjectileFactory.Instance.Pool.Release(this);
    }
}
