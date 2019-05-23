using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Hp;
    Animation KnoCk;
    // Start is called before the first frame update
    void Start()
    {
        KnoCk = this.gameObject.GetComponent<Animation>();
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "NPC_Sword")
        {
            Hp -= 20;
        }
    }

    public void OnTrggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "P_Sword")
        {
            KnoCk.Play();
        }
    }
}

