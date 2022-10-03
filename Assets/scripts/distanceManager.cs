using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class distanceManager : MonoBehaviour
{
    public Text scoreText;
    public float scoreAmount;
    public float pointIncreasedPerSecond;
    void Start()
    {
        scoreAmount = 0f;
        pointIncreasedPerSecond = 5f;
    }

    
    void Update()
    {
        scoreText.text = (int)scoreAmount + "m";
        scoreAmount += pointIncreasedPerSecond * Time.deltaTime;
    }
}
