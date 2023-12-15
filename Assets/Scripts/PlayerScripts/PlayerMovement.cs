using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator playerAnim;
    
    private Rigidbody myBody;

    [SerializeField] private float speed;


    void Awake()
    {
        playerAnim = GetComponentInChildren<Animator>();
        myBody = GetComponent<Rigidbody>();
        transform.rotation = Quaternion.Euler(0,90f,0);
    }


    void Update()
    {
        PlayerRotation();
        PlayerAnimation();
    }

    private void FixedUpdate()
    {
        PlayerMovements();
      
    }

    private void PlayerMovements()
    {
        myBody.velocity = new Vector3(
            Input.GetAxisRaw("Horizontal")*(-speed),
            myBody.velocity.y,
            Input.GetAxisRaw("Vertical")* (-speed)
            );
    }

    private void PlayerRotation()
    {
        if(Input.GetAxisRaw("Horizontal")>0)
        {
            transform.rotation = Quaternion.Euler(0,-90f,0);
            playerAnim.SetBool("Walk", true);
        }
        else if(Input.GetAxisRaw("Horizontal")<0)
        {
            playerAnim.SetBool("Walk", true);
            transform.rotation = Quaternion.Euler(0,90,0);
        }
    }
    private void PlayerAnimation()
    {
        if(Input.GetAxisRaw("Horizontal")  != 0 || Input.GetAxisRaw("Vertical")!= 0) 
        {
            playerAnim.SetBool("Walk", true);
        }
        else
        {
            playerAnim.SetBool("Walk", false);
        }

    }
}
