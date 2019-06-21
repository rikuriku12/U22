using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class menu : MonoBehaviour
{
    [SerializeField]GameObject[] gameplay;
    [SerializeField ]int i;
    [SerializeField]Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        for (int k = 0; gameplay.Length > k; k++)
        {
            ani = gameplay[k].GetComponent<Animator>();
            ani.SetBool("set", false);
        }
        ani = gameplay[i].GetComponent<Animator>();
        ani.SetBool("set", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (i == gameplay.Length-1)
            {
                i = 0;
                for (int k = 0; gameplay.Length > k; k++)
                {
                    ani = gameplay[k].GetComponent<Animator>();
                    ani.SetBool("set", false);
                }
                ani = gameplay[i].GetComponent<Animator>();
                ani.SetBool("set", true);
            }
            else
            {
                i++;
                for (int k = 0; gameplay.Length > k; k++)
                {
                    ani = gameplay[k].GetComponent<Animator>();
                    ani.SetBool("set", false);
                }
                ani = gameplay[i].GetComponent<Animator>();
                ani.SetBool("set", true);
            }

           
        }
        if (Input.GetKeyDown("x"))
        {
            if (gameplay[i].name == "start")
            {
                SceneManager.LoadScene("Game");
            }
        }

       
    }
}
