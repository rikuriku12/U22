﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerStatus : MonoBehaviour
{
    // Start is called before the first frame update
    public float PHp;
    public ParticleSystem damegepar;
    // Start is called before the first frame update
    void Start()
    {
        damegepar.Stop();//最初は停止
    }

    private void Update()
    {

        if (PHp <= 0)
        {
            SceneManager.LoadScene("Over");
        }

    }
    // Update is called once per frame
    public void OnCollisionEnter(Collision collision)//矢が刺さるように
    {
        if (collision.gameObject.tag == "EnemyArrow")
        {
            PHp -= 50;

            //ダメージ後にパーティクル発生
            damegepar.Play();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy_Sword")
        {
            PHp -= 20;

            //ダメージ後にパーティクル発生
            damegepar.Play();
        }

        if (other.gameObject.tag == "TowerBurret")
        {
            PHp -= 100;

            //ダメージ後にパーティクル発生
            damegepar.Play();
        }
    }
}