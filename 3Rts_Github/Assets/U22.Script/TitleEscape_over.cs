using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class TitleEscape_over1 : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Start"))
        {
            Invoke("GotoGame", 0.5f);
        }
        if (Input.GetButton("Back"))
        {
            Application.Quit();
        }
    }

    void GotoGame()
    {
       
        SceneManager.LoadScene("Game");

    }
   
}
