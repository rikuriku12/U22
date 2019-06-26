﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherHp : MonoBehaviour
{
    public int Hp;
    public float up = 0.1f;
    float uiTime;
    public bool hpUi;
    GameObject player;
    public ParticleSystem particle;
    // Start is called before the first frame update
    void Start()
    {
        hpUi = false;
        player = GameObject.FindWithTag("Player");
        particle.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (hpUi)
        {
            uiTime += Time.deltaTime;
        }
        else
        {
            uiTime = 0;
        }

        if (uiTime >= 3f)
        {
            hpUi = false;
        }
        if (Hp <= 0)
        {
            player.GetComponent<TurretSet>().militaryforce += up;
            Destroy(this.gameObject);
        }
    }

    public void OnCollisionEnter(Collision collision)//矢が刺さるように
    {
        


    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "NPC_Sword")
        {
            Hp -= 20;
        }
        if (other.gameObject.tag == "P_Sword")
        {
            Hp -= player.GetComponent<PlayerStatus>().AttackPower + 50;
            hpUi = true;
        }

        if (other.gameObject.tag == "P_Arrow")
        {
            Hp -= 5;
            hpUi = true;
            particle.Play();
        }
    }

}
