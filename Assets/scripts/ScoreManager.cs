using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public Text scoreDisplay;
    void Start()
    {
        
    }
    
    void Update()
    {
        scoreDisplay.text = score.ToString();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Orange"))
        {
            score++;
            Debug.Log(score);
        }
    }
}
