using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    private Rigidbody myBody;

    [SerializeField] private float speedXAxi;
    [SerializeField] private float speedZAxi;

    [SerializeField] private CharacterAnimations charAnim;

    private PlayerHealth health;

    void Awake()
    {
        transform.rotation = Quaternion.Euler(0,90f,0);

        myBody = GetComponent<Rigidbody>();
        
        charAnim = GetComponentInChildren<CharacterAnimations>();

        health = GetComponentInChildren<PlayerHealth>();
    }


    void Update()
    {
        if (health.isAlive)
        {
            PlayerRotation();

            PlayerAnimation();
        }
    }

    private void FixedUpdate()
    {
        if(health.isAlive)
            PlayerMovements();
    }

    private void PlayerMovements()
    {
        myBody.velocity = new Vector3(
            Input.GetAxisRaw(Axis.HORIZONTAL_AXIS)*(-speedXAxi),
            myBody.velocity.y,
            Input.GetAxisRaw(Axis.VERTICAL_AXIS) * (-speedZAxi)
            );
    }

    private void PlayerRotation()
    {
        if(Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) >0)
            transform.rotation = Quaternion.Euler(0,-90f,0);
        else if(Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) <0)
            transform.rotation = Quaternion.Euler(0,90,0);

    }
    private void PlayerAnimation()
    {
        if(Input.GetAxisRaw(Axis.HORIZONTAL_AXIS)  != 0 || Input.GetAxisRaw(Axis.VERTICAL_AXIS) != 0) 
        {
            charAnim.Walk(true);
        }
        else
        {
            charAnim.Walk(false);
        }

    }

}
