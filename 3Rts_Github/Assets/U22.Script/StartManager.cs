using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class StartManager : MonoBehaviour
{
    void Update()
    {
        if(Input.GetButton("joystick B"))
        {
            Invoke("GotoGame", 0.5f);
        }
    }

    void GotoGame()
    {
        //FadeManager.Instance.LoadScene("Game", 0.5f);
        SceneManager.LoadScene("Game");

    }
}
