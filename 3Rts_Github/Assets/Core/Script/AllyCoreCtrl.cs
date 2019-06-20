using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AllyCoreCtrl : MonoBehaviour
{
    
    public int AllyCoreHP;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(AllyCoreHP == 0)
        {
            SceneManager.LoadScene("Over");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            AllyCoreHP -= 10;
        }
    }
}
