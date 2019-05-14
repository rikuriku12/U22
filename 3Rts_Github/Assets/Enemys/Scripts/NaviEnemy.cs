using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Game.Enemy
{
    public class NaviEnemy : MonoBehaviour
    {
        NavMeshAgent agent;
        //agent.GetComponent<NavMeshAgent>().isStopped = true;
        Vector3 position;

        private GameObject tower; //towe
        private GameObject player; //player
        private Transform targget; //目的地
        private GameObject nearObj;//近くのオブジェクト
        
        float agentDistance;//プレイヤー、敵間の距離
                            //エネミーの感知距離
        [SerializeField] float plyerDistance;
        //[SerializeField] float time;
        private float searchTime = 0;




        void Start()
        {
            
            agent = gameObject.GetComponent<NavMeshAgent>();
            tower = GameObject.FindWithTag("Tower");

            player = GameObject.FindWithTag("Player");
            if (tower)
            {
                targget = tower.transform;
            }
        }

        void Update()
        {
            if (player)
            {
                //EnemyとPlayerの距離
                agentDistance = Vector3.Distance(this.agent.transform.position,
                                                    player.transform.position);

                if (agentDistance <= plyerDistance )
                {
                    //目的地をプレイヤに設定
                    targget = player.transform;
                }
            }
            

            
            
                searchTime += Time.deltaTime;

                if (searchTime >= 1.0f)
                {
                    //最も近かった、"Turret"タグのオブジェクトを取得
                    nearObj = serchTag(gameObject, "Turret");
                    //経過時間を初期化
                    searchTime = 0;
                }

                // nearObjがあれば
                if (nearObj)
                {
                    //目的地をタワーに
                    targget = nearObj.transform;
                }
                else // nearObjがなかったら
                {
                    
                    targget = tower.transform;
                }
            }

            if (targget)
            {
                agent.SetDestination(targget.position);
            }
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


}
}
