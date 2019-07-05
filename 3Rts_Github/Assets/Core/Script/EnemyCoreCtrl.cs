using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCoreCtrl : MonoBehaviour
{
    public int EnemyCoreHp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(EnemyCoreHp <= 0)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene("Clear");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "P_Sword")
        {
            EnemyCoreHp -= 50;
        }

        if (other.gameObject.tag == "NPC_Sword")
        {
            EnemyCoreHp -= 20;
        }
    }

}
