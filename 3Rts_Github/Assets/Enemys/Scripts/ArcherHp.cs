using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherHp : MonoBehaviour
{
    public int Hp;
    public float up = 0.1f;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
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
        }
    }

}
