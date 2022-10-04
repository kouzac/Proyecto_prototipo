using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class player_controller : MonoBehaviour
{
public float JumpForce;
    public float jumpTime;
    private float jumpTimeCount;
    public bool isGrounded;
    public bool isJumping;
    private bool isShielded;
    private bool doubleJump;
    public GameObject shield;
    public LayerMask ground;
    private Rigidbody2D RB;
    private Collider2D PlayerCollider;
    
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        PlayerCollider = GetComponent<Collider2D>();
        isShielded = false;
    }

    void Update()
    {
        Shield();
        isGrounded = Physics2D.IsTouchingLayers(PlayerCollider, ground);
        
        if(isGrounded && !Input.GetButton("Jump"))
        {
            doubleJump = false;
        }
        
        if(Input.GetButtonDown("Jump"))
        {
            if(isGrounded || doubleJump)
            {
            isJumping = true;
            jumpTimeCount = jumpTime;
            RB.velocity = Vector2.up * JumpForce;
            doubleJump = !doubleJump;

            }
        }

        if(Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if(jumpTimeCount>0)
            {
                RB.velocity = Vector2.up * JumpForce;
                jumpTimeCount -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }

    void Shield()
    {
        if(Input.GetKey(KeyCode.S) && !isShielded)
        {
            shield.SetActive(true);
            isShielded = true;
            Invoke("noShield", 3f);
        }
    }

    void noShield()
    {
        shield.SetActive(false);
        isShielded = false;
    }
}
