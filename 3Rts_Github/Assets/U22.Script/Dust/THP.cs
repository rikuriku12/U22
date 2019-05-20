using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class THP : MonoBehaviour
{
    TurretSet turretSet;
    GameObject TS;
    public int SetC;
    public int HP;
    // Start is called before the first frame update
    void Start()
    {
        TS = GameObject.Find("Player");
        turretSet = TS.GetComponent<TurretSet>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {
            //turretSet.Setcount--;
            Destroy(gameObject.transform.root.gameObject); 
        }
        //TS = GameObject.Find("Player");
        //turretSet = TS.GetComponent<TurretSet>();
        //int SetC = turretSet.Setcount;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            HP -= 20;
        }

        

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "E_Bullet")
        {
            HP -= 1;
        }
        

    }
}
