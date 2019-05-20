using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{

    
    public int objectHP;

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Enemy"))
        {
            // オブジェクトのHPを１ずつ減少させる。
            objectHP -= 1;
            Debug.Log("ダメージ…");


            if (objectHP < 0)
            {

                Destroy(this.gameObject);
                Debug.Log("ゲームオーバー");

            }
        }
    }
}