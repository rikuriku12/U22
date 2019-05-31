using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCHPManager : MonoBehaviour
{
    public float npcHP;
    public ParticleSystem npcParticle;
    // Start is called before the first frame update
    void Start()
    {
        npcParticle.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (npcHP <= 0)
        {
            Destroy(this.gameObject);//破壊
        }
    }
    public void OnCollisionEnter(Collision collision)//矢が刺さるように
    {
        if (collision.gameObject.tag == "EnemyArrow")
        {
            npcHP -= 50;

            //ダメージ後にパーティクル発生
            npcParticle.Play();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy_Sword")
        {
            npcHP -= 20;

            //ダメージ後にパーティクル発生
            npcParticle.Play();
        }

        if (other.gameObject.tag == "TowerBurret")
        {
            npcHP -= 100;

            //ダメージ後にパーティクル発生
            npcParticle.Play();
        }
    }

}
