using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    //ZoomCamera
    private bool shouldZoomIn;
    private bool shouldZoomOut;
    [SerializeField]
    private float zoomSpeed;
    private float minimumZoom=60;
    private float maxmumZoom=40;
    Camera cam;

    //Shake Camera
    private float power = .2f;
    private float duration=.4f;
    private float slowDownAmount = 1f;
    private bool shouldShake;
    private float initialDuration;

    private Vector3 normalPosition;
    //the target
    [SerializeField] private Transform player;
    //catch target speed
    [SerializeField] private float smoothSpeed;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        normalPosition = new Vector3(transform.position.x, .75f, 6f);
        initialDuration = duration;

    }

    // Update is called once per frame
    void Update()
    {
        Shake();
        if (player != null)
            TrackXPlayer();

    }
    private void LateUpdate()
    {
        CameraZoomIn();
        CameraZoomOut();
        
    }

    //Camera track a player
    private void TrackXPlayer()
    {
        // Calculate the desired position for the camera along the X-axis
        Vector3 desiredPosition = new Vector3(player.position.x, transform.position.y, transform.position.z);
        
        // Use Mathf.Lerp to smoothly move the camera towards the desired position
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
    }
    //shake camera funciton
    private void Shake()
    {
        if(shouldShake)
        {
            if(duration >0)
            {
                transform.localPosition = transform.localPosition+Random.insideUnitSphere*power;
                duration -= Time.deltaTime * slowDownAmount;
            }
            else
            {
                shouldShake = false;
                duration = initialDuration;
                transform.localPosition = normalPosition ;
            }
        }
    }
    //Camera Zoom in / Zoom Out 
    private void CameraZoomIn()
    {
        if (shouldZoomIn)
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView,maxmumZoom, Time.deltaTime*zoomSpeed);
            if(cam.fieldOfView <=maxmumZoom)
                shouldZoomIn = false;
        }

    }
    private void CameraZoomOut()
    {
        if (shouldZoomOut)
        { 
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, minimumZoom, Time.deltaTime * zoomSpeed);
            if(cam.fieldOfView >=minimumZoom)
                shouldZoomOut = false;
        }
    }
    //Properties
    public bool ShouldShake
    {
        get { return shouldShake; }
        set { shouldShake = value; }
    }

    public bool ShouldZoomIn
    {
        get { return shouldZoomIn; }
        set { shouldZoomIn = value; }
    }
    public bool ShouldZoomOut
    {
        get { return shouldZoomOut; }
        set { shouldZoomOut = value; }
    }

}
