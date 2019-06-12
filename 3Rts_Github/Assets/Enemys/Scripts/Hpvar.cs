﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hpvar : MonoBehaviour
{
    GameObject player;
    [SerializeField]bool pcr;
    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        player = GameObject.FindWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        pcr = player.GetComponent<PlayerController>().HPvar;
        if (pcr == true)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
