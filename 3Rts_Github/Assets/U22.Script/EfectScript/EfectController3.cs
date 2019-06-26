using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EfectController3 : MonoBehaviour
{
    public ParticleSystem particle;
    //パーティクルエフェクト再生

    void Start()
    {
        particle.Stop();  //最初は止める
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            particle.Play();
        }
    }
}

