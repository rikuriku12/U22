using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EfectController2 : MonoBehaviour
{
    public ParticleSystem particle;
    //パーティクルエフェクト再生

    void Start()
    {
        particle.Stop();  //最初は止める
    }

    void Effect2()
    {
        particle.Play();
    }
}
