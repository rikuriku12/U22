using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject[] gameplay;
    int i;
    [SerializeField] Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        for (int k = 0; gameplay.Length > k; k++)
        {
            ani = gameplay[k].GetComponent<Animator>();
            ani.SetBool("set", true);
        }
        ani = gameplay[i].GetComponent<Animator>();
        ani.SetBool("set", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (i == gameplay.Length - 1)
            {
                for (int k = 0; gameplay.Length > k; k++)
                {
                    ani = gameplay[k].GetComponent<Animator>();
                    ani.SetBool("set", true);
                }
                ani = gameplay[i].GetComponent<Animator>();
                ani.SetBool("set", false);
                i = 0;
            }
            else
            {
                for (int k = 0; gameplay.Length > k; k++)
                {
                    ani = gameplay[k].GetComponent<Animator>();
                    ani.SetBool("set", true);
                }
                ani = gameplay[i].GetComponent<Animator>();
                ani.SetBool("set", false);
                i++;
            }


        }
        if (Input.GetKeyDown("x"))
        {
            if (gameplay[i].name == "GamePlay")
            {
                SceneManager.LoadScene("Game");
            }
        }


    }
}
