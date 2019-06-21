using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class militaryForce : MonoBehaviour
{
    [SerializeField] float militaryForcePower;
    [SerializeField] private Image militaryforce;

    GameObject Player;
    TurretSet turretSet;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        turretSet = Player.GetComponent<TurretSet>();

        militaryForcePower = turretSet.Getmilitaryforce();

    }

    // Update is called once per frame
    void Update()
    {
        militaryForcePower = turretSet.Getmilitaryforce();
        militaryforce.fillAmount = militaryForcePower / turretSet.maxMilitary;

        //spaceを押したらHPが減る
        if (Input.GetKeyDown("space"))
        {
            turretSet.Setmilitaryforce(turretSet.Getmilitaryforce() - 0.01f) ;
        }
        //enterを押したらHPが減る
        if (Input.GetKey("tab"))
        {
            turretSet.Setmilitaryforce(turretSet.Getmilitaryforce() + turretSet.militaryforce);
        }
    }
}
