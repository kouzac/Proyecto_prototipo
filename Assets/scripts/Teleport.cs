using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    public float speed;

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
        if (collision.CompareTag("Player"))
        {
            if(backgroundSwap._bg1 == true)
            {
                backgroundSwap._swap=true;
            }
            else
            {
                backgroundSwap._swap2 = true;
            }
            Destroy(gameObject);
        }
    }
}
