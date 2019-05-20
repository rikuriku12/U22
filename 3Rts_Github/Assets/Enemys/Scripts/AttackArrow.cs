using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Enemy
{
    public class AttackArrow : MonoBehaviour
    {
        [SerializeField] GameObject muzzle; // 銃口
        [SerializeField] GameObject bullet; // 銃弾
        [SerializeField] float shootPower = 1000; // 打ち出す力                   

        void Generate()
        {
            var bulletInstance = GameObject.Instantiate(bullet, muzzle.transform.position, Quaternion.Euler(90, this.transform.rotation.y, 0)) as GameObject;
            bulletInstance.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * shootPower);
        }
    } 
}

