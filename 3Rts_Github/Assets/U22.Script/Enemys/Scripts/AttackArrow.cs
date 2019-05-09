using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArrow : MonoBehaviour
{
    [SerializeField] GameObject muzzle; // 銃口
    [SerializeField] GameObject bullet; // 銃弾
    [SerializeField] float bulletSpeed; // 打ち出す力

    float countTime;

    private void Update()
    {
        countTime += Time.deltaTime;
    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Player"
            || collider.gameObject.tag == "Towe"
            || collider.gameObject.tag == "Turret")
        {
            if (countTime >= 3)
            {
                Generate();
            }           
        }
    }

    void Generate()
    {
        var bulletInstance = GameObject.Instantiate(bullet, muzzle.transform.position, Quaternion.Euler(90, this.transform.rotation.y, 0)) as GameObject;
        bulletInstance.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * bulletSpeed);
        Debug.Log("射ね");
        countTime = 0;
    }
}
