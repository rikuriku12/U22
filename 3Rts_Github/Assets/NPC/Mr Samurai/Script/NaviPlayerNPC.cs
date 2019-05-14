using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NaviPlayerNPC : MonoBehaviour
{
    NavMeshAgent agent;

    [SerializeField] Animator p_Animator;

    Vector3 position;

    private GameObject tower;// 敵タワー
    private GameObject enemy;// エネミー
    private Transform targget;// 目的地
    private GameObject nearObj;// 近くの特定のタグ付きオブジェクト

    //private bool npc_Flag;// エネミーをターゲットにするフラグ

    float agentDistance;// プレイヤー、敵間の距離
    [SerializeField] float plyerDistance = 10f;// エネミーを検知する距離
    [SerializeField] float stopDistance = 5f;// 停止距離

    private float searchTime = 0;//serchTagの探す時間

    void Start()
    {
        //npc_Flag = false;

        agent = gameObject.GetComponent<NavMeshAgent>();//NaviMeshAgentのコンポーネントを取得
        tower = GameObject.FindWithTag("e_Towe");// 敵タワーを取得
        enemy = GameObject.FindWithTag("Enemy");// エネミーを取得
        //タワーがあれば
        if (tower)
        {
            //目的地をタワーに
            targget = tower.transform;
            p_Animator.SetBool("IsRun", true);
        }
    }

    void Update()
    {
        //Debug.Log(enemy);
        //停止距離より離れていたら
        if (!(agentDistance <= stopDistance))
        {
            // 走るアニメーションの再生
            p_Animator.SetBool("IsRun", true);
        }
        if (enemy)// Enemyの中にオブジェクトが入っていたら
        {
            // EnemyとNPCの距離
            agentDistance = Vector3.Distance(this.agent.transform.position,
                                                enemy.transform.position);
            // Enemyとの距離が近くなり、npcフラグオフのとき
            if (agentDistance <= plyerDistance /*&& npc_Flag == false*/)
            {
                // 目的地をEnemyに設定
                targget = enemy.transform;

                // 停止距離になったら
                if (agentDistance <= stopDistance)
                {
                    //攻撃関数
                    ArrowAttack();
                }
                else
                {
                    // Naviを入れる
                    agent.GetComponent<NavMeshAgent>().isStopped = false;
                }
            }
            else
            {
                //目的地をタワーに設定
                targget = tower.transform;
            }

            //searchTime += Time.deltaTime;

            //if (searchTime >= 1.0f)
            //{
            //    //最も近かった、"Enemy"タグのオブジェクトを取得
            //    nearObj = serchTag(gameObject, "Enemy");
            //    //経過時間を初期化
            //    searchTime = 0;
            //}
        }
        else
        {
            searchTime += Time.deltaTime;

            if (searchTime >= 1.0f)
            {
                //最も近かった、"Enemy"タグのオブジェクトを取得
                nearObj = serchTag(gameObject, "Enemy");
                //経過時間を初期化
                searchTime = 0;
            }

            if (agent.GetComponent<NavMeshAgent>().isStopped == true)
            {
                // Naviを入れる
                agent.GetComponent<NavMeshAgent>().isStopped = false;
            }
            //目的地をタワーに設定
            targget = tower.transform;
            p_Animator.SetBool("IsRun", true);
        }

        // nearObjがあれば
        if (nearObj)
        {
            enemy = nearObj;
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

    void ArrowAttack()
    {
        // 走るアニメーションの停止
        p_Animator.SetBool("IsRun", false);
        // Naviを切る
        agent.GetComponent<NavMeshAgent>().isStopped = true;
        //Enemyの方向を向く
        var aim = this.enemy.transform.position - this.transform.position;
        var look = Quaternion.LookRotation(aim);
        this.transform.localRotation = look;
        //攻撃アニメーションの再生
        p_Animator.SetTrigger("IsAttack");
    }
}

