using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeEquip : MonoBehaviour
{
    [SerializeField]
    public GameObject[] weapons;
    public int equipment;

    PlayerController playercontroller;
    GameObject Player;

    GameObject Sword, Bow;
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
        Player = GameObject.FindWithTag("Player");
        playercontroller = Player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetButtonDown("joystick Y")||Input.GetKeyDown(KeyCode.C))  && 
            (!playercontroller.stateInfo.IsTag("Attack"))&&
            (!playercontroller.stateInfo.IsTag("Jump")))
        {
            Change();
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
            }
            else
            {
                weapons[i].SetActive(false);
            }
        }
    }
}
