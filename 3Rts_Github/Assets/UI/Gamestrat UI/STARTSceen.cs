﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class STARTSceen : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Start"))
        {
            Invoke("FadeScene", 0f);
        }
    }

    public void FadeScene()
    {
        FadeManager.Instance.LoadScene("SampleScene", 3f);
    }
}
