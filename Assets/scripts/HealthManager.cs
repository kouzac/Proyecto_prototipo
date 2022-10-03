using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public HP playerHP;
    public Image totalHP;
    public Image currentHP;
    void Start()
    {
        totalHP.fillAmount = playerHP.currentHP / 10;
    }

    // Update is called once per frame
    void Update()
    {
        currentHP.fillAmount = playerHP.currentHP / 10;
    }
}
