using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBullet : MonoBehaviour
{    
    private void OnTriggerEnter(Collider collider)
    {
        // 2秒で弾が消える
        Destroy(gameObject, 2f);

        // プレイヤーに当たったら
        if (collider.gameObject.tag == "Player" 
            || collider.gameObject.tag == "Towe"
            || collider.gameObject.tag == "Turret")
        { 
            // 弾が消える
            Destroy(gameObject);
        }

        
    }
}
