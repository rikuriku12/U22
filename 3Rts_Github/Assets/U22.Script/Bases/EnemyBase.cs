using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{


    public int objectHP;

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Sword"))
        {
            // オブジェクトのHPを１ずつ減少させる。
            objectHP -= 1;
            Debug.Log("痛い");


            if (objectHP < 0)
            {

                Destroy(this.gameObject);

                Debug.Log("ゲームクリア");
            }
        }
    }
}
