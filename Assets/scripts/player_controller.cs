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
    public static bool _isShielded;
    private bool doubleJump;
    public GameObject shield;
    public LayerMask ground;
    private Rigidbody2D RB;
    private Collider2D PlayerCollider;
    
    void Start()
    {
        shield = transform.Find("Shield").gameObject;
        DeactivateShield();
        RB = GetComponent<Rigidbody2D>();
        PlayerCollider = GetComponent<Collider2D>();
 
    }

    void Update()
    {
      
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

        if(Input.GetKeyDown(KeyCode.S) && _isShielded==false)
        {
            ActiateShield();
        }
    }

    void ActiateShield()
    {
        shield.SetActive(true);
        _isShielded = true;
        Invoke("DeactivateShield", 2f);
    }

    void DeactivateShield()
    {
        shield.SetActive(false);
        _isShielded = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            DeactivateShield();
        }
    }
}
