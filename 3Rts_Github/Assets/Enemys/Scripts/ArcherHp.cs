using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherHp : MonoBehaviour
{
    public int Hp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void OnCollisionEnter(Collision collision)//矢が刺さるように
    {
        if (collision.gameObject.tag == "P_Sword")
        {
            Hp -= 50;
        }


    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "NPC_Sword")
        {
            Hp -= 20;
        }
    }
}
