using System.Collections;
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
            //Invoke("FadeScene", 0f);
            SceneManager.LoadScene("Game");

        }
        if (Input.GetButtonDown("Back"))
        {
            Application.Quit();
            Debug.Log("終了");
        }

    }

    //public void FadeScene()
    //{
    //}
}
