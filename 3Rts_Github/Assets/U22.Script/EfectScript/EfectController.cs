using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EfectController : MonoBehaviour
{
    public ParticleSystem particle;
    //パーティクルエフェクト再生

    void Start()
    {
        particle.Stop();  //最初は止める
    }
    private void OnTriggerEnter(Collider other)
    {
        particle.Play();

        if (other.gameObject.tag == "Enemy")
        {
            particle.Play();
        }

        if (other.gameObject.tag == "Tower_center")
        {
            particle.Play();
        }

        if (other.gameObject.tag == "Tower_right")
        {
            particle.Play();
        }

        if (other.gameObject.tag == "Tower_left")
        {
            particle.Play();
        }

        if (other.gameObject.tag == "EnemyCore")
        {
            particle.Play();
        }
    }
}
