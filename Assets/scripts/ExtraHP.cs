using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraHP : MonoBehaviour
{
    public float speed;
    public float valueHP = 1;
    void Start()
    {
        
    }
    
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
                if (transform.position.x <= -11.9)
                {
                    Destroy(gameObject);
                }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<HP>().extraHP(valueHP);
            gameObject.SetActive(false);
        }
    }
}
