using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEfect_Hoshi : MonoBehaviour
{
    public AudioSource BladeAttack;
    public AudioClip[] SE;/*効果音の配列*/
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BladeAttackSE()
    {
        /*剣のアタックイベント*/
        BladeAttack.PlayOneShot(SE[0]);
    }
}
