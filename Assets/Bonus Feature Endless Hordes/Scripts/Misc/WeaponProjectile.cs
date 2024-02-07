using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class WeaponProjectile : MonoBehaviour
{
    public delegate void UpdateWeapon(WeaponProjectile projectile);

    public void InitializeProjectile(UpdateWeapon updateWeapon){
        UpdateMethod = updateWeapon;
    }
    private UpdateWeapon UpdateMethod;
    void Update()
    {
        UpdateMethod(this);
    }
}
