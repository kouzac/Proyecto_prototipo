using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class naraja : MonoBehaviour
{
    public float speed;
    public float magnetSpeed;
    private GameObject _player;
    public static bool _magnetOn = false;


    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        endEffect();
    }


    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (transform.position.x <= -11.9)
        {
            Destroy(gameObject);
        }

        if(_magnetOn)
        {
            magnetEffect();
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            magnetEffect();
            Destroy(gameObject);
        }
    }

    void magnetEffect()
    {
        transform.position = Vector3.Lerp(this.transform.position, _player.transform.position, magnetSpeed * Time.deltaTime);
        ScoreManager._score *= 1;
        Invoke("endEffect", 2f);
    }

   void endEffect()
    {
        _magnetOn = false;
    }

}
