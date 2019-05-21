using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class TitleEscape_over : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            Invoke("GotoTitle", 0.5f);
        }
    }

    void GotoTitle()
    {
        //FadeManager.Instance.LoadScene("Title", 0.5f);
        SceneManager.LoadScene("Title");

    }
}
