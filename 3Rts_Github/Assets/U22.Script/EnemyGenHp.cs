using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class EnemyGenHp : MonoBehaviour
{
    public int HP;
    void Start()
    {
     
    }

    // Update is called once per frame

    void Update()
    {
        if(HP <= 0)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene("clear");
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "sword")
        {
            HP -= 100;
        }
    }
}
