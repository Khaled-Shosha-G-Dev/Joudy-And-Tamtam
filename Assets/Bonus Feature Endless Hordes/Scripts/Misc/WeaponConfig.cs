using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "Weapon Data", menuName = "ScriptableObjects/EndlessHordes/WeaponConfig", order = 1)]
public class WeaponConfig : ScriptableObject
{
    [Header("Right Hand Transform")]
    [SerializeField][FormerlySerializedAs("Position")] private Vector3 rposition = Vector3.zero;
    [SerializeField][FormerlySerializedAs("Rotation")] private Quaternion rrotation = Quaternion.identity;
    [SerializeField][FormerlySerializedAs("Scale")] private Vector3 rscale = Vector3.one;

    [Header("Right Hand Transform")]
    [SerializeField][FormerlySerializedAs("Position")] private Vector3 lposition = Vector3.zero;
    [SerializeField][FormerlySerializedAs("Rotation")] private Quaternion lrotation = Quaternion.identity;
    [SerializeField][FormerlySerializedAs("Scale")] private Vector3 lscale = Vector3.one;

    [Header("Weapon Properties")]
    [SerializeField] public WeaponProjectile Projectile;
    [SerializeField] public float Damage = 5f;

    [SerializeField] public float ProjectileLifeTime = 10f;

    [Tooltip("How many bullets fired in a second.")]
    [SerializeField] public float fireRate = 20f;

    [Tooltip("How fast can the projectile travel.")]
    [SerializeField] public float projectileSpeed = 5f;

    [HideInInspector()]
    public Matrix4x4 GetRightHandMatrix{
        get {
            Matrix4x4 transformationMatrix = Matrix4x4.TRS(rposition, rrotation, rscale);
            return transformationMatrix;
        }
    }
    [HideInInspector()]
    public Matrix4x4 GetLeftHandMatrix{
        get{
            Matrix4x4 transformationMatrix = Matrix4x4.TRS(lposition, lrotation, lscale);
            return transformationMatrix;
        }
    }
}
