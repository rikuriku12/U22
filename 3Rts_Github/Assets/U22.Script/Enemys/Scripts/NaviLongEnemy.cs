﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Game.Enemy
{
    public class NaviLongEnemy : MonoBehaviour
    {
        NavMeshAgent agent;

        [SerializeField] Animator e_Animator;

        Vector3 position;

        private GameObject tower;// タワー
        private GameObject player;// プレイヤー
        private Transform targget;// 目的地
        private GameObject nearObj;// 近くの特定のタグ付きオブジェクト

        private bool npc_Flag;// プレイヤーNPCをターゲットにするフラグ

        private float agentDistance;// プレイヤー、敵間の距離
        private float towerDistance;// 敵、タワー間の距離
        private float playerNpcDistance;// 敵、プレイヤーのNPC間の距離
        [SerializeField] float plyerDistance = 10f;// プレイヤーを検知する距離
        [SerializeField] float stopDistance = 5f;// 停止距離

        private float searchTime = 0;//serchTagの探す時間

        void Start()
        {
            npc_Flag = false;

            agent = gameObject.GetComponent<NavMeshAgent>();//NaviMeshAgentのコンポーネントを取得
            tower = GameObject.FindWithTag("AllyCore");// タワーを取得
            player = GameObject.FindWithTag("Player");// プレイヤーを取得
                                                      //タワーがあれば
            if (tower)
            {
                //目的地をタワーに
                targget = tower.transform;
            }
        }

        void Update()
        {
            //停止距離より離れていたら
            if (!(agentDistance <= stopDistance
                && towerDistance <= stopDistance))
            {
                // 走るアニメーションの再生
                e_Animator.SetBool("IsRun", true);
            }
            if (player)// playerの中にオブジェクトが入っていたら
            {
                // EnemyとPlayerの距離
                agentDistance = Vector3.Distance(this.agent.transform.position,
                                                    player.transform.position);
                // プレイヤーとの距離が近くなり、npcフラグオフのとき
                if (agentDistance <= plyerDistance && npc_Flag == false)
                {
                    // 目的地をプレイヤに設定
                    targget = player.transform;

                    // 停止距離になったら
                    if (agentDistance <= stopDistance)
                    {
                        //攻撃
                        ArrowAttack();
                    }
                    else
                    {
                        // NaviをON
                        agent.GetComponent<NavMeshAgent>().isStopped = false;
                    }
                }
                else
                {
                    //目的地をタワーに設定
                    targget = tower.transform;
                    searchTower();
                }
            }
            else if (npc_Flag == false)
            {
                //目的地をタワーに設定
                targget = tower.transform;
                searchTower();
            }

            //npcフラグがたったら
            if (npc_Flag == true)
            {
                searchTime += Time.deltaTime;

                if (searchTime >= 1.0f)
                {
                    //最も近かった、"Player_NPC"タグのオブジェクトを取得
                    nearObj = serchTag(gameObject, "Player_NPC");
                    //経過時間を初期化
                    searchTime = 0;
                }
                // nearObjがあれば
                if (nearObj)
                {
                    targget = nearObj.transform;
                    searchNPC();

                }
                else // nearObjがなかったら
                {
                    npc_Flag = false;
                    //目的地をタワーに
                    targget = tower.transform;
                    searchTower();
                }
            }
            //ターゲットが入っていたら
            if (targget)
            {
                // エージェント
                agent.SetDestination(targget.position);
            }
        }

        // タグ付きのオブジェクトを探す    
        GameObject serchTag(GameObject nowObj, string tagName)
        {
            float tmpDis = 0;           //距離用一時変数
            float nearDis = 0;          //最も近いオブジェクトの距離        
            GameObject targetObj = null; //オブジェクト

            //タグ指定されたオブジェクトを配列で取得する
            foreach (GameObject obs in GameObject.FindGameObjectsWithTag(tagName))
            {
                //自身と取得したオブジェクトの距離を取得
                tmpDis = Vector3.Distance(obs.transform.position, nowObj.transform.position);

                //オブジェクトの距離が近いか、距離0であればオブジェクト名を取得
                //一時変数に距離を格納
                if (nearDis == 0 || nearDis > tmpDis)
                {
                    nearDis = tmpDis;
                    targetObj = obs;
                }
            }
            //最も近かったオブジェクトを返す        
            return targetObj;
        }

        /// <summary>
        /// タワー検知、攻撃の関数
        /// </summary>
        void searchTower()
        {
            towerDistance = Vector3.Distance(this.agent.transform.position,
                                                    tower.transform.position);
            if (towerDistance <= stopDistance)
            {
                //攻撃
                ArrowAttack();
            }
            else
            {
                // Naviを切る
                agent.GetComponent<NavMeshAgent>().isStopped = false;
            }
        }
        /// <summary>
        /// プレイヤーのNPCの検知、攻撃の関数
        /// </summary>
        void searchNPC()
        {
            playerNpcDistance = Vector3.Distance(this.agent.transform.position,
                                                    tower.transform.position);
            if (playerNpcDistance <= stopDistance)
            {
                //攻撃
                ArrowAttack();
            }
            else
            {
                // Naviを切る
                agent.GetComponent<NavMeshAgent>().isStopped = false;
            }
        }

        /// <summary>
        /// 攻撃関数
        /// </summary>
        void ArrowAttack()
        {
            // 走るアニメーションの停止
            e_Animator.SetBool("IsRun", false);
            // Naviを切る
            agent.GetComponent<NavMeshAgent>().isStopped = true;
            //プレイヤーの方向を向く
            var aim = this.targget.transform.position - this.transform.position;
            var look = Quaternion.LookRotation(aim);
            this.transform.localRotation = look;
            //攻撃アニメーションの再生
            e_Animator.SetTrigger("IsAttack");
        }


    }
}


