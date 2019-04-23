using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TowerHP : MonoBehaviour
{
    Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();

        float maxtowerHP = 2000f;
        float towerHP = 2000f;

        slider.maxValue = maxtowerHP;
        slider.value = towerHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("i"))
        {
            slider.value -= 25f;
        }
    }
}
