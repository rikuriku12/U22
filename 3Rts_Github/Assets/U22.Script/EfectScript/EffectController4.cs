using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController4 : MonoBehaviour
{
    public ParticleSystem effectArrow1, effectArrow2, effectArrow3, effectArrow4, effectArrow5;
    //Animator animator;
    //bool o = false;

    void Start()
    {
       
        effectArrow1.Stop();
        effectArrow2.Stop();
        effectArrow3.Stop();
        effectArrow4.Stop();
        effectArrow5.Stop();
    }

    //private void Update()
    //{
    //    if (animator.GetBool("check"))
    //    {
    //        o = true;
    //    }
    //    else
    //    {
    //        o = false;
    //    }
    //    Effect4();
    //}
    void Effect4()
    {
        //if (o)
        //{
            effectArrow1.Play();
            effectArrow2.Play();
            effectArrow3.Play();
            effectArrow4.Play();
            effectArrow5.Play();
        //}

    }
}
