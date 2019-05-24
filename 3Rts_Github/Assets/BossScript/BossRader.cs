using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRader : MonoBehaviour
{
    private GameObject Player;

    //void OnTriggerStay(Collider other)
    //{

    //    if (other.CompareTag("Player"))
    //    {
    //        transform.root.LookAt(target);
    //    }
    //}

    private void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }
    private void Update()
    {
        if (Player)
        {
            var aim = this.Player.transform.position - this.transform.position;
            var look = Quaternion.LookRotation(aim);
            this.transform.localRotation = look;
        }
    }
}
