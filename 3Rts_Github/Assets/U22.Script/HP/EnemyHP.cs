using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();

        float maxEnemyHP = 100f;
        float enemyHP = 100f;

        slider.maxValue = maxEnemyHP;
        slider.value = enemyHP;

    }

    // Update is called once per frame
    void Update()
    {  //敵のHPを視点変えても見える
       // GameObject.Find("SliderCanvas").transform.LookAt(GameObject.Find("Player"));

        if (Input.GetKeyDown("n"))
        {
            slider.value -= 20f;

        }
    }
}
