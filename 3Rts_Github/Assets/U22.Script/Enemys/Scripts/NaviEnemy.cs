using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NaviEnemy : MonoBehaviour
{
    NavMeshAgent agent;
    Rigidbody rigidbody;
    Vector3 position;

    private GameObject towe; //towe
    private GameObject player; //player
    private Transform targget; //目的地
    GameObject nearObj;//近くのオブジェクト

    bool t_Flag;//タレットをターゲット

    float agentDistance;//プレイヤー、敵間の距離
    //エネミーの感知距離
    [SerializeField] float plyerDistance;
    [SerializeField] float time;
    private float searchTime = 0;




    void Start()
    {
        t_Flag = false;

        rigidbody = GetComponent<Rigidbody>();
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



        //ノックバック
        if ((time > 0.5f) && (agent.GetComponent<NavMeshAgent>().isStopped == true))
        {
            agent.GetComponent<NavMeshAgent>().isStopped = false;
            rigidbody.velocity = Vector3.zero;
        }
        else
        {
            time += Time.deltaTime;
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
        //Turret、Turret、Toweのタグに当たったら
        if (collider.gameObject.tag == "Player" || collider.gameObject.tag == "Turret"
                                                || collider.gameObject.tag =="Towe")
        {
            // ノックバック
            //rigidbody.AddForce(this.transform.up * 2f, ForceMode.VelocityChange);        
            rigidbody.AddForce(-transform.forward * 10f, ForceMode.Impulse);
        }
        //タレットの弾に当たったら
        if (collider.gameObject.tag == "T_Bullet")
        {
            t_Flag = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player" || collider.gameObject.tag == "Turret"
                                                || collider.gameObject.tag == "Towe")
        {
            agent.GetComponent<NavMeshAgent>().isStopped = true;
            time = 0;
        }
    }
}