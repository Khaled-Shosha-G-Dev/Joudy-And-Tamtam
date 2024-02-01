using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public WeaponConfig weaponConfig;

    public Transform rHand;
    public Transform lHand;

    void Start()
    {
        var parentTroop = transform.parent.GetComponent<Troop>();
        rHand = parentTroop?.rightHandIKReference;
        lHand = parentTroop?.leftHandIKReference; 
        //once instantiated all the values are set.
        if(weaponConfig){
            //right hand
            rHand.localPosition = weaponConfig.rposition;
            rHand.localRotation = weaponConfig.rrotation;
            rHand.localScale = weaponConfig.rscale;

            //left hand
            lHand.localPosition = weaponConfig.lposition;
            lHand.localRotation = weaponConfig.lrotation;
            lHand.localScale = weaponConfig.lscale;
        }
    }
}
