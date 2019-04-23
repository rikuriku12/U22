using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMP : MonoBehaviour
{
    Slider mpSlider;
    // Start is called before the first frame update
    void Start()
    {
        mpSlider = GetComponent<Slider>();

        float maxMp = 100f;
        float nowMp = 100f;

        //MPゲージの最大値
        mpSlider.maxValue = maxMp;
        //MPゲージの現在値
        mpSlider.value = nowMp;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("m"))
        {
            mpSlider.value -= 20f;

        }
    }
}
