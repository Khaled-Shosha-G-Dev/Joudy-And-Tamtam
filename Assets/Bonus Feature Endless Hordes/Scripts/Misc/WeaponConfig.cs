using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "Weapon Data", menuName = "ScriptableObjects/EndlessHordes/WeaponConfig", order = 1)]
public class WeaponConfig : ScriptableObject
{
    [Header("Right Hand Transform")]
    [SerializeField][FormerlySerializedAs("Position")] public Vector3 rposition = Vector3.zero;
    [SerializeField][FormerlySerializedAs("Rotation")] public Quaternion rrotation = Quaternion.identity;
    [SerializeField][FormerlySerializedAs("Scale")] public Vector3 rscale = Vector3.one;

    [Header("Right Hand Transform")]
    [SerializeField][FormerlySerializedAs("Position")] public Vector3 lposition = Vector3.zero;
    [SerializeField][FormerlySerializedAs("Rotation")] public Quaternion lrotation = Quaternion.identity;
    [SerializeField][FormerlySerializedAs("Scale")] public Vector3 lscale = Vector3.one;

    [HideInInspector()]
    public Matrix4x4 GetRightHandMatrix{
        get {
            Matrix4x4 transformationMatrix = Matrix4x4.TRS(rposition, rrotation, rscale);
            return transformationMatrix;
        }
    }
    [HideInInspector()]
    public Matrix4x4 GetLeftHandTrs{
        get{
            Matrix4x4 transformationMatrix = Matrix4x4.TRS(rposition, rrotation, rscale);
            return transformationMatrix;
        }
    }
}
