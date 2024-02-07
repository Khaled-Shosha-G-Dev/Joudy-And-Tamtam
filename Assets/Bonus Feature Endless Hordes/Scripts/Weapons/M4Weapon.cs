using System.Collections;
using UnityEngine;

public class M4Weapon : Weapon
{
    public override IEnumerator Shoot()
    {
        // Special Functionality for the weapon
        while(true){
            var projectile = WeaponProjectileFactory.Instance.Pool.Get();
            projectile.transform.position = muzzleFlash.transform.position;
            projectile.transform.rotation = transform.rotation;
            projectile.InitializeProjectile(ProjectileLogic);
            StartCoroutine(KillProjectile(projectile));
            muzzleFlash.Play();
            yield return HelperFunctions.GetWaitForSeconds(1f / weaponConfig.fireRate);
        }
    }

    IEnumerator KillProjectile(WeaponProjectile projectile){
        yield return HelperFunctions.GetWaitForSeconds(weaponConfig.ProjectileLifeTime);
        WeaponProjectileFactory.Instance.Pool.Release(projectile);
    }

    public void ProjectileLogic(WeaponProjectile projectile){
        projectile.transform.Translate(projectile.transform.forward * weaponConfig.projectileSpeed * Time.deltaTime);
    }
}