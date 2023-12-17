using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumping : MonoBehaviour
{
    private Rigidbody myBody;
    private Animator playerAnim;
        
    [SerializeField] private float jumpForce;
    private int doubleJump=2; 
    void Awake()
    {
        myBody = GetComponentInParent<Rigidbody>();
        playerAnim = GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        PlayerAnimation(); 
    }
    private void Player_Jumping()
    {
        myBody.AddForce(Vector3.up * jumpForce);
        doubleJump--;
    }
    private void PlayerAnimation()
    {
        if(Input.GetKeyDown(KeyCode.Space)&&doubleJump >0)
            playerAnim.SetTrigger("Jumping");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground")&&doubleJump<2)
        {
            doubleJump = 2;
            playerAnim.SetTrigger("TouchGround");
        }
    }
}
