using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hpvar : MonoBehaviour
{
    GameObject player;
    [SerializeField]GameObject enemy;
    [SerializeField]bool pcr;                       //HPバーの可視化
    [SerializeField]bool isHp;

    void Start()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        player = GameObject.FindWithTag("Player");
        //enemy = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        pcr = player.GetComponent<PlayerController>().HPvar;
        isHp = enemy.GetComponent<MeleeEnemyHp>().hpUi;

        if (pcr == true || isHp == true)
        {
            transform.GetChild(0).gameObject.SetActive(true);

        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
