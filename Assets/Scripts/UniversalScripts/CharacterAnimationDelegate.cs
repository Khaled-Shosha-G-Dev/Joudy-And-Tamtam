using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationDelegate : MonoBehaviour
{
    [SerializeField]private GameObject rightHandPoint,leftHandPoint,rightLegPoint,leftLegPoint;

    private void Awake()
    {
        rightLegPoint.SetActive(false);
        leftLegPoint.SetActive(false);
        rightHandPoint.SetActive(false);
        leftHandPoint.SetActive(false);

    }

    //Activate Attack points
    //hand points
    private void EnableRightHandPoint()
    {
        rightHandPoint.SetActive(true);
    }
    private void EnableLeftHandPoint()
    {
        leftHandPoint.SetActive(true);
    }
        //leg Points
    private void EnableRightLegPoint()
    {
        rightLegPoint.SetActive(true);
    }
    private void EnableLeftLegPoint()
    {
        leftLegPoint.SetActive(true);
    }
    //Disable Attack points
        //Hand Points
    private void DisableRightHandPoint()
    {
        rightHandPoint.SetActive(false);
    }
    private void DisableLeftHandPoint()
    {
        leftHandPoint.SetActive(false);
    }
        //Leg Points
    private void DisableRightLegPoint()
    {
        rightLegPoint.SetActive(false);
    }
    private void DisableLeftLegPoint()
    {
        leftLegPoint.SetActive(false);
    }
}
