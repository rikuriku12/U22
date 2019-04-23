using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NaviLongEnemy : MonoBehaviour
{
    NavMeshAgent agent;
    
    Vector3 position;

    private GameObject towe; //towe
    private GameObject player; //player
    private Transform targget; //目的地
    GameObject nearObj;//近くのオブジェクト

    bool t_Flag;//タレットをターゲット

    float agentDistance;//プレイヤー、敵間の距離
    [SerializeField] float plyerDistance;
    [SerializeField] float time;
    private float searchTime = 0;




    void Start()
    {
        t_Flag = false;

        
        agent = gameObject.GetComponent<NavMeshAgent>();
        towe = GameObject.FindWithTag("Towe");
        player = GameObject.FindWithTag("Player");
        if (towe)
        {
            targget = towe.transform;
        }
    }

    void Update()
    {
        if (player)
        {
            //EnemyとPlayerの距離
            agentDistance = Vector3.Distance(this.agent.transform.position,
                                                player.transform.position);

            if (agentDistance <= plyerDistance && t_Flag == false)
            {
                //目的地をプレイヤに設定
                targget = player.transform;
            }
        }
        else if (t_Flag == false)
        {
            //目的地をタワーに設定
            targget = towe.transform;
        }

        //t_Flagがたったら
        if (t_Flag == true)
        {
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
                t_Flag = false;
                targget = towe.transform;
            }
        }

        if (targget)
        {
            agent.SetDestination(targget.position);
        }
    }

    GameObject serchTag(GameObject nowObj, string tagName)
    {
        float tmpDis = 0;           //距離用一時変数
        float nearDis = 0;          //最も近いオブジェクトの距離
        //string nearObjName = "";    //オブジェクト名称
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
                //nearObjName = obs.name;
                targetObj = obs;
            }
        }


        //最も近かったオブジェクトを返す
        //return GameObject.Find(nearObjName);
        return targetObj;
    }


    private void OnTriggerEnter(Collider collider)
    {
        //タレットの弾に当たったら
        if (collider.gameObject.tag == "T_Bullet")
        {
            t_Flag = true;
        }
    }

    
}

