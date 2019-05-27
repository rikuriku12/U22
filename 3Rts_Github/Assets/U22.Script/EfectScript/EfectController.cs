using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EfectController : MonoBehaviour
{
    public ParticleSystem particle;
    //パーティクルエフェクト再生
    void Effect()
    {
        particle.Play();
    }
}
