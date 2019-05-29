using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NaviPlayerNPC : MonoBehaviour
{
    NavMeshAgent agent;

    Animator p_Animator;    

    private GameObject tower;// 敵タワー
    private GameObject nearEnemy;// 近くのEnemy
    [SerializeField] private Transform targget;// 目的地    

    float agentDistance;// プレイヤーのNPC、敵間の距離
    float towerDistance;// tower、PlayerNPC間の距離
    [SerializeField] float enemyDistance = 10f;// エネミーを検知する距離
    [SerializeField] float stopDistance = 5f;// 停止距離

    private float searchTime = 0;//serchTagの探す時間

    void Start()
    {
        p_Animator = gameObject.GetComponent<Animator>(); //animatorコンポーネントを取得
        agent = gameObject.GetComponent<NavMeshAgent>();//NaviMeshAgentのコンポーネントを取得
        tower = GameObject.FindWithTag("EnemyCore");// 敵タワーを取得
       
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
        towerDistance = Vector3.Distance(this.agent.transform.position, tower.transform.position);
        //停止距離より離れていたら
        if (!(agentDistance <= stopDistance
              && towerDistance <= stopDistance))
        {
            // 走るアニメーションの再生
            p_Animator.SetBool("IsRun", true);
        }

        // nearEnemyの中にオブジェクトが入っていたら
        if (nearEnemy)
        {
            // EnemyとNPCの距離
            agentDistance = Vector3.Distance(this.agent.transform.position,
                                                nearEnemy.transform.position);
            // Enemyとの距離が近くのとき
            if (agentDistance <= enemyDistance)
            {
                // 目的地をEnemyに設定
                targget = nearEnemy.transform;
                AttackEnemy();
            }
            else
            {
                //目的地をタワーに設定
                targget = tower.transform;
            }
        }
        else
        {
            targget = tower.transform;

            if (agent.GetComponent<NavMeshAgent>().isStopped == true)
            {
                // Naviを入れる
                agent.GetComponent<NavMeshAgent>().isStopped = false;
            }

            // サーチ時間カウント
            searchTime += Time.deltaTime;
            //サーチ時間
            float limitTime = 1.0f;
            if (searchTime >= limitTime)
            {
                //最も近かった、"Enemy"タグのオブジェクトを取得
                nearEnemy = serchTag(gameObject, "Enemy");
                //経過時間を初期化
                searchTime = 0;
            }
        }

        if (targget == tower.transform)
        {
            AttackTower();
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

    void Attack()
    {
        // 走るアニメーションの停止
        p_Animator.SetBool("IsRun", false);
        // Naviを切る
        agent.GetComponent<NavMeshAgent>().isStopped = true;
        //Enemyの方向を向く
        var aim = this.targget.transform.position - this.transform.position;
        var look = Quaternion.LookRotation(aim);
        this.transform.localRotation = look;
        //攻撃アニメーションの再生
        p_Animator.SetTrigger("IsAttack");
    }

    /// <summary>
    /// Enemyの検知、攻撃の関数
    /// </summary>
    void AttackEnemy()
    {       
        if (agentDistance <= stopDistance)
        {
            //攻撃
            Attack();
        }
        else
        {
            // Naviを動かす
            agent.GetComponent<NavMeshAgent>().isStopped = false;
            p_Animator.SetBool("IsRun", true);
        }
    }

    void AttackTower()
    {        
        if (towerDistance <= stopDistance)
        {
            Attack();
        }
        else
        {
            // Naviを動かす
            agent.GetComponent<NavMeshAgent>().isStopped = false;
        }
    }
}

