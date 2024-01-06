using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationDelegate : MonoBehaviour
{
    [SerializeField] private GameObject rightHandPoint, leftHandPoint, rightLegPoint, leftLegPoint;
    //sounds
    private AudioSource audioSource;
    [SerializeField] private AudioClip punchWhooshSound, kickWhooshSound, hitAhhSound, deathSound, FootStepSound, dropSound;
    //Camera
    private CameraManager cameraManager;

    private void Awake()
    {
        rightLegPoint.SetActive(false);
        leftLegPoint.SetActive(false);
        rightHandPoint.SetActive(false);
        leftHandPoint.SetActive(false);

        audioSource = GetComponent<AudioSource>();
        cameraManager = GameObject.FindWithTag(Tags.MAIN_CAMERA_TAG).GetComponent<CameraManager>();
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
    //Sound FX

    private void Punch_FX_Sound()
    {
        audioSource.volume = .4f;
        audioSource.clip = punchWhooshSound;
        audioSource.Play();
    }
    private void Kick_FX_Sound()
    {
        audioSource.volume = .4f;
        audioSource.clip = kickWhooshSound;
        audioSource.Play();
    }

    private void Hit_FX_Sound()
    {
        audioSource.volume = .6f;
        audioSource.clip = hitAhhSound;
        audioSource.Play();
    }

    private void Death_FX_Sound()
    {
        audioSource.volume = .6f;
        audioSource.clip = deathSound;
        audioSource.Play();
    }
    private void Drop_FX_Sound()
    {
        audioSource.volume = .6f;
        audioSource.clip = dropSound;
        audioSource.Play();
    }
    private void FootStep_FX_Sound()
    {
        audioSource.volume = .2f;
        audioSource.clip = FootStepSound;
        audioSource.Play();
    }

    //Camera
        //shake
    private void ShakeCameraOnFall()
    {
        cameraManager.ShouldShake=true;
    }
        //Zoom
    private void CameraZoomIn()
    {
        cameraManager.ShouldZoomIn=true;
    }
    private void CameraZoomOut()
    {
        cameraManager.ShouldZoomOut=true;
    }

}
