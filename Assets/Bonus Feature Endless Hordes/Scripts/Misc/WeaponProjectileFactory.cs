using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
class WeaponProjectileFactory : MonoBehaviour{

    public static WeaponProjectileFactory Instance = null;

    //Once the weapon is changed this Pool must be CHANGED so it can instantiate and get the appropiate prefabs.
    public ObjectPool<WeaponProjectile> Pool = new ObjectPool<WeaponProjectile>(
        () => { return Instantiate( GameObject.FindObjectOfType<TroopsController>().weaponPrefab.weaponConfig.Projectile);},
        projectile => {projectile.gameObject.SetActive(true);},
        projectile => {projectile.gameObject.SetActive(false);},
        projectile => {Destroy(projectile);}, true, 30, 40
    );

    void Awake()
    {
        if(Instance){
            Debug.LogError("there's more than a projectile factory instance in the scene!");
        }
        Instance = this;
    }

}