using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundSwap : MonoBehaviour
{
    public GameObject[] background;
    public static bool _bg1;
    public static bool _bg2;
    public static bool _swap = false;
    public static bool _swap2 = false;

    void Start()
    {

        _bg1 = true;
        _swap = false;
    }

    void Update()
    {
        if(_swap)
        {
            bg2Swap();            
        }
        
        if(_swap2)
        {
            bg1Swap();
        }
    }

    void bg2Swap()
    {
        if(_bg1==true)
        {
            background[1].SetActive(true);
            background[0].SetActive(false);
            _bg2 = true;
            _bg1 = false;
        }
        
    }

    void bg1Swap()
    {

        if (_bg2 == true)
        {
            background[0].SetActive(true);
            background[1].SetActive(false);
            _bg2 = false;
            _bg1 = true;
        }       
    }

    
}
