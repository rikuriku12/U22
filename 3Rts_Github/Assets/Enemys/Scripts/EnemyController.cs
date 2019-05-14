using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game.Enemy
{
    public class EnemyController : MonoBehaviour
    {

        [SerializeField] float maxEnemyHP;//最大HP
        [SerializeField] float nowEnemyHp;//hpの現在値
                                          //[SerializeField] float _enemyAttackPower;//攻撃力
        [SerializeField] float damage;//ダメ―ジ


        void Start()
        {
            //----初期化------------------------
            nowEnemyHp = maxEnemyHP;//HP
                                    //----------------------------------
        }

        void Update()
        {
            if (nowEnemyHp <= 0f)
            {
                Destroy(gameObject);
                //Debug.Log("私は、消えない……！　消えられるものか……！");
            }
        }

        private void OnTriggerEnter(Collider _collider)
        {
            //---ダメージ-------------------------------
            //P_Bulletタグのオブジェクトにあたったら
            if (_collider.gameObject.tag == "P_Bullet"
                || _collider.gameObject.tag == "Weapon"
                || _collider.gameObject.tag == "T_Bullet"
                || _collider.gameObject.tag == "sword")
            {
                //ダメージ処理             
                nowEnemyHp = nowEnemyHp - damage;
                //Debug.Log("くっ……");
            }


            //---攻撃------------------------------------
            //Plyerタグのオブジェクトにあたったら
            if (_collider.gameObject.tag == "Player")
            {
                //ダメージ処理
                //hogehoge = hogehoge - _enemyAttackPower;
                Debug.Log("汝の道は、すでに途絶えた！");
            }
        }
    }

}
