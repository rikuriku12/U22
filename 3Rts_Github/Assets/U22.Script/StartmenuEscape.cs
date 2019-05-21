using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class StartmenuEscape : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Start"))
        {
            Invoke("GotoStartmenu", 0.5f);
        }
    }

    void GotoStartmenu()
    {
        //FadeManager.Instance.LoadScene("Startmenu", 0.5f);
        SceneManager.LoadScene("Startmenu");

    }
}
