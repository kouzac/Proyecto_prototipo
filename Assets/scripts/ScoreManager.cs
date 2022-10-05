using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int _score;
    public Text scoreDisplay;
    void Start()
    {
        _score = 0;
    }
    
    void Update()
    {
        scoreDisplay.text = _score.ToString();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Orange"))
        {
            _score++;
            Debug.Log(_score);
        }
    }
}
