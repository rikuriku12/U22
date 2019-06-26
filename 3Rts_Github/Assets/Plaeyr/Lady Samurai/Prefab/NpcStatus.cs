using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcStatus : MonoBehaviour
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
            Destroy(transform.root.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag  == "Enemy_Sword")
        {
            Hp -= 30;
        }

        if (other.gameObject.tag == "Enemy_Arrow")
        {
            Hp -= 10;
        }

        if(other.gameObject.tag  == "TowerBurret")
        {
            Hp -= 50;
        }
    }
}
