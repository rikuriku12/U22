using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossCtrl : MonoBehaviour
{
    public int Hp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Hp <= 0)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene("Clear");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "P_Sword")
        {
            Hp -= 50;
        }
    }
}
