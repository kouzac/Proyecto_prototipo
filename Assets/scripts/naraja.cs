using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class naraja : MonoBehaviour
{
    public float speed;
    //public float valueHP = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
            //collision.GetComponent<HP>().extraHP(valueHP);
            gameObject.SetActive(false);
        }
    }
}
