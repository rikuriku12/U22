using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Enemy
{
    
    public class HitBullet : MonoBehaviour
    {
        ParticleSystem Fire;
        private void Start()
        {
            // 2秒で弾が消える
            Fire = GetComponent<ParticleSystem>();
            
        }
        private void Update()
        {
            // 2秒で弾が消える
            Destroy(gameObject, 2f);
            Fire.Stop();
        }
        //private void OnTriggerEnter(Collider collider)
        //{

        //    // プレイヤーに当たったら
        //    if (collider.gameObject.tag == "Player" 
        //        || collider.gameObject.tag == "Towe"
        //        || collider.gameObject.tag == "PlayerNpc")
        //    { 
        //        // 弾が消える
        //        Destroy(gameObject);
        //    }
        //}
    }
}

