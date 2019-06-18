using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowAtack : MonoBehaviour
{
    [SerializeField] GameObject muzzle; // 銃口
    [SerializeField] GameObject bullet; // 銃弾
    [SerializeField] float shootPower = 1000; // 打ち出す力                   
    [SerializeField] float cost;
    void Generate()
    {
        float power = GetComponent<TurretSet>().Getmilitaryforce();
        if (power >= cost)
        {
            var bulletInstance = GameObject.Instantiate(bullet, muzzle.transform.position, Quaternion.Euler(90, this.transform.eulerAngles.y, 0)) as GameObject;
            bulletInstance.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * shootPower);
            gameObject.GetComponent<TurretSet>().Setmilitaryforce(power - cost);
        }
    }
}
