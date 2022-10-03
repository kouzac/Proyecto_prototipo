using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{
    public float speed;
    public float distance;
    public float dmg = 1;
    public bool Right;
    private Rigidbody2D rb;
    public Transform groundController;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        RaycastHit2D groundPosition = Physics2D.Raycast(groundController.position, Vector2.down, distance);
        rb.velocity = new Vector2(speed, rb.velocity.y);
        if(groundPosition == false)
        {
            Flip();
        }
    }

    private void Flip()
    {
        Right = !Right;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        speed *= -1;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(groundController.transform.position, groundController.transform.position + Vector3.down * distance);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<HP>().Damage(dmg);
            Destroy(gameObject);
        }
    }



}
