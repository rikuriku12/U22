using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleatTU : MonoBehaviour
{
    TurretSet turretSet;
    GameObject TS;
    public int SetC;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TS = GameObject.Find("Player");
        turretSet = TS.GetComponent<TurretSet>();
        //int SetC = turretSet.Setcount;
    }

    public void OnTriggerExit(Collider other)
    {
        if ((other.gameObject.tag == "Turret") && (Input.GetButton("joystick X")))
        {
            
            GameObject Turret = other.gameObject;
            Destroy(Turret);
           // turretSet.Setcount--;
        }
    }
}
