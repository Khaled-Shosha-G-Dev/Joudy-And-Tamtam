using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float smoothSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TrackXPlayer();
    }

    private void TrackXPlayer()
    {
        // Calculate the desired position for the camera along the X-axis
        Vector3 desiredPosition = new Vector3(player.position.x, transform.position.y, transform.position.z);

        // Use Mathf.Lerp to smoothly move the camera towards the desired position
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
    }
}
