using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PNPCctrl : MonoBehaviour
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
        }
    }

    public void OnCollisionEnter(Collision collision)//矢が刺さるように
    {
        if(collision.gameObject.tag == "EnemyArrow")
        {
            Hp -= 20;
        }

        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemySword")
        {
            Hp -= 20;
        }
    }
}
