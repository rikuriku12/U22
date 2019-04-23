using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLongAttack : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] float bulletSpeed;
    
    int countTime;

    private void Update()
    {
        countTime++;
    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Player" 
            || collider.gameObject.tag =="Towe" 
            || collider.gameObject.tag =="Turret")
        {
            Generate();
            
        }
    }

    void Generate()
    {
        if (countTime >= 80)
        {
            var bulletInstance = GameObject.Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
            bulletInstance.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * bulletSpeed);
            //Debug.Log("ガンド！");
            countTime = 0;
        }
        
    }
}
