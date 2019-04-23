using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeEquip : MonoBehaviour
{
    [SerializeField]
    private GameObject[] weapons;
    private int equipment;

    PlayerController playercontroller;
    GameObject Player;

    GameObject Sword, Gun;
    //private ProcessMyAttack processMyAttack;
    //private Move move;

    // Use this for initialization
    void Start()
    {
        //move = GetComponentInParent<Move>();
        //processMyAttack = transform.root.GetComponent<ProcessMyAttack>();

        //　初期装備設定
        equipment = 0;
        weapons[equipment].SetActive(true);
        Player = GameObject.Find("Player");
        playercontroller = Player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetButtonDown("joystick Y") /*&& move.GetState() == Move.MyState.Normal*/)&& 
            (!playercontroller.stateInfo.IsName("New State 1"))&&
            (!playercontroller.stateInfo.IsName("New State 4")))
        {
            Change();

            Sword = GameObject.FindWithTag("sword");
            //Gun = GameObject.FindWithTag("gun");
            if (Sword)
            {
                playercontroller.weapon = 2;
            }
            else
            {
                playercontroller.weapon = 1;
            }
        }
    }

    void Change()
    {
        equipment++;
        if (equipment >= weapons.Length)
        {
            equipment = 0;
        }
        //　武器を切り替え
        for (var i = 0; i < weapons.Length; i++)
        {
            if (i == equipment)
            {
                weapons[i].SetActive(true);
                /*processMyAttack.SetCollider(weapons[i].GetComponent<Collider>());*/
            }
            else
            {
                weapons[i].SetActive(false);
            }
        }
    }
}
