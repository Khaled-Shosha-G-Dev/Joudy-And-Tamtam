using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public abstract class Weapon : MonoBehaviour
{
    public WeaponConfig weaponConfig;

    protected Transform rightHand;
    protected Transform leftHand;

    [SerializeField] protected ParticleSystem muzzleFlash;

    public void Initialize()
    {
        var parentTroop = transform.parent.GetComponent<Troop>();
        if(parentTroop){
            InitializeTransforms(parentTroop);
        }

        StartCoroutine(Shoot());
    }


    public abstract IEnumerator Shoot();
    private void InitializeTransforms(Troop parent)
    {
        rightHand = parent.rightHandIKReference;
        leftHand = parent.leftHandIKReference; 
        //once instantiated all the values are set.
        if(weaponConfig){
            //right hand
            if(rightHand){
                // Vector3 position = weaponConfig.GetRightHandMatrix.GetColumn(3);
                // Quaternion rotation = Quaternion.LookRotation(weaponConfig.GetRightHandMatrix.GetColumn(2), weaponConfig.GetRightHandMatrix.GetColumn(1));
                // Vector3 scale = new Vector3(
                //     weaponConfig.GetRightHandMatrix.GetColumn(0).magnitude,
                //     weaponConfig.GetRightHandMatrix.GetColumn(1).magnitude,
                //     weaponConfig.GetRightHandMatrix.GetColumn(2).magnitude
                // );

                // Set the position, rotation, and scale
                // rightHand.localPosition = position;
                // rightHand.localRotation = rotation;
                // rightHand.localScale = scale;

                rightHand.transform.localToWorldMatrix.SetRow(0, weaponConfig.GetRightHandMatrix.GetRow(0));
                rightHand.transform.localToWorldMatrix.SetRow(1, weaponConfig.GetRightHandMatrix.GetRow(1));
                rightHand.transform.localToWorldMatrix.SetRow(2, weaponConfig.GetRightHandMatrix.GetRow(2));
                rightHand.transform.localToWorldMatrix.SetRow(3, weaponConfig.GetRightHandMatrix.GetRow(3));
            }

            //left hand
            if(leftHand)
            {
                // Vector3 position = weaponConfig.GetLeftHandMatrix.GetColumn(3);
                // Quaternion rotation = Quaternion.LookRotation(weaponConfig.GetLeftHandMatrix.GetColumn(2), weaponConfig.GetLeftHandMatrix.GetColumn(1));
                // Vector3 scale = new Vector3(
                //     weaponConfig.GetLeftHandMatrix.GetColumn(0).magnitude,
                //     weaponConfig.GetLeftHandMatrix.GetColumn(1).magnitude,
                //     weaponConfig.GetLeftHandMatrix.GetColumn(2).magnitude
                // );

                // Set the position, rotation, and scale
                // leftHand.localPosition = position;
                // leftHand.localRotation = rotation;
                // leftHand.localScale = scale;


                leftHand.transform.localToWorldMatrix.SetRow(0, weaponConfig.GetLeftHandMatrix.GetRow(0));
                leftHand.transform.localToWorldMatrix.SetRow(1, weaponConfig.GetLeftHandMatrix.GetRow(1));
                leftHand.transform.localToWorldMatrix.SetRow(2, weaponConfig.GetLeftHandMatrix.GetRow(2));
                leftHand.transform.localToWorldMatrix.SetRow(3, weaponConfig.GetLeftHandMatrix.GetRow(3));

            }
        }
    }
}
