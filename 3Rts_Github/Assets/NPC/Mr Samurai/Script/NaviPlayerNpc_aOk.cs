using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class NaviPlayerNpc_aOk : MonoBehaviour
{
    NavMeshAgent agent;

    Animator p_Animator;
    GameObject p_core;
    // private GameObject enemyTarget;
    private GameObject core;// 敵タワー
    [SerializeField] private Transform[] botTower;// 敵タワー
    [SerializeField] private Transform[] midTower;// 敵タワー
    [SerializeField] private Transform[] topTower;// 敵タワー
    private GameObject[] nearTower;
    private GameObject[] _nearTower = new GameObject[3];
    private GameObject nearEnemy;// 近くのEnemy
    [SerializeField] private Transform target;// 目的地    

    float agentDistance;// プレイヤーのNPC、敵間の距離
    float coreDistance;// tower、PlayerNPC間の距離
    float distance; //top側のタワーとの距離
    [SerializeField] float enemyDistance = 10f;// エネミーを検知する距離
    [SerializeField] float stopDistance = 5f;// 停止距離

    //出現時のラインの判定
    [SerializeField] bool isBotLine = false;
    bool isTopLine = false;
    //bool isMidLine = false;

    [SerializeField]bool enemyAttack;

    private float searchTime = 0;//serchTagの探す時間

    void Start()
    {
        p_Animator = gameObject.GetComponent<Animator>(); //animatorコンポーネントを取得
        agent = gameObject.GetComponent<NavMeshAgent>();//NaviMeshAgentのコンポーネントを取得

        core = GameObject.FindWithTag("EnemyCore");// 敵タワーを取得
        p_core = GameObject.FindGameObjectWithTag("Tower");


        if (GameObject.FindGameObjectWithTag("Tower_left"))
        {
            // "tower"という名前のタグ名の付いたGameObjectを取得しLinqでTransformを抽出         
            Transform[] lane_tower = GameObject.FindGameObjectsWithTag("Tower_left").Select(e => e.transform).ToArray();
            // OrderByで距離(昇順)でソート         
            botTower = lane_tower.OrderBy(e => Vector3.Distance(e.transform.position, p_core.transform.position)).ToArray();
        }
        if (GameObject.FindGameObjectWithTag("Tower_rigth"))
        {
            // "tower"という名前のタグ名の付いたGameObjectを取得しLinqでTransformを抽出         
            Transform[] lane_tower = GameObject.FindGameObjectsWithTag("Tower_rigth").Select(e => e.transform).ToArray();
            // OrderByで距離(昇順)でソート         
            topTower = lane_tower.OrderBy(e => Vector3.Distance(e.transform.position, p_core.transform.position)).ToArray();
        }
        if (GameObject.FindGameObjectWithTag("Tower_center"))
        {
            // "tower"という名前のタグ名の付いたGameObjectを取得しLinqでTransformを抽出         
            Transform[] lane_tower = GameObject.FindGameObjectsWithTag("Tower_center").Select(e => e.transform).ToArray();
            // OrderByで距離(昇順)でソート         
            midTower = lane_tower.OrderBy(e => Vector3.Distance(e.transform.position, p_core.transform.position)).ToArray();
        }

        //タワーがあれば
        SearchLine();
        if (core)
        {
            if (isBotLine)
            {
                if (botTower[0].name == "LeftPoint")
                {
                    Transform hoge = botTower[0];
                    if (botTower.Length == 1)
                    {
                        botTower[0] = core.transform;
                    }
                    else
                    {
                        botTower[0] = botTower[1];
                        botTower[1] = hoge;
                    }
                }
                target = botTower[0].transform;
            }
            else if (isTopLine)
            {
                if (topTower[0].name == "RightPoint")
                {
                    Transform hoge = topTower[0];
                    if (topTower.Length == 1)
                    {
                        topTower[0] = core.transform;
                    }
                    else
                    {
                        topTower[0] = topTower[1];
                        topTower[1] = hoge;
                    }
                }
                target = topTower[0].transform;
            }

            else if (!isTopLine && !isBotLine)
            {
                if (midTower[0].name == "CenterPoint")
                {
                    Transform hoge = midTower[0];
                    if (midTower.Length == 1)
                    {
                        midTower[0] = core.transform;
                    }
                    else
                    {
                        midTower[0] = midTower[1];
                        midTower[1] = hoge;
                    }
                }
                target = midTower[0].transform;
            }
            else
            {
                target = core.transform;
            }
            p_Animator.SetBool("IsRun", true);
        }
    }

    void Update()
    {
        coreDistance = Vector3.Distance(this.agent.transform.position, core.transform.position);
        //停止距離より離れていたら
        if (!(agentDistance <= stopDistance
              && coreDistance <= stopDistance))
        {
            // 走るアニメーションの再生
            p_Animator.SetBool("IsRun", true);
        }
        if (enemyAttack)
        {
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
                    target = nearEnemy.transform;
                    // AttackEnemy();
                }
            }
            else
            {
                enemyAttack = false;
            }
        }
        else
        {
            // サーチ時間カウント
            searchTime += Time.deltaTime;
            if (isBotLine)
            {
                ChaseTower("Tower_left", "LeftPoint", botTower);
            }
            if (isTopLine)
            {
                ChaseTower("Tower_rigth", "RightPoint", topTower);

            }
            if (!isBotLine && !isTopLine)
            {
                ChaseTower("Tower_center", "CenterPoint", midTower);
            }
            if ((topTower.Length == 1) && (botTower.Length == 1))
            {
                target = core.transform;
            }

            if (agent.GetComponent<NavMeshAgent>().isStopped == true)
            {
                // Naviを入れる
                agent.GetComponent<NavMeshAgent>().isStopped = false;
            }
        }


        //if (target == core.transform)
        //{
        //    //AttackTower();
        //}

        //ターゲットが入っていたら
        if (target)
        {
            // エージェント
            agent.SetDestination(target.position);
            distance = Vector3.Distance(target.position, agent.transform.position);
        }
        AttackTT();
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
                //nearObjName = obs.name;
                targetObj = obs;
            }
        }
        //最も近かったオブジェクトを返す
        return targetObj;
    }

    void Attack()
    {
        // 走るアニメーションの停止
        p_Animator.SetBool("IsRun", false);
        // Naviを切る
        agent.GetComponent<NavMeshAgent>().isStopped = true;
        //Enemyの方向を向く
        if (target)
        {
            var aim = this.target.transform.position - this.transform.position;
            var look = Quaternion.LookRotation(aim);
            this.transform.localRotation = look;
        }
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
        if (coreDistance <= stopDistance)
        {
            Attack();
        }
        else
        {
            // Naviを動かす
            agent.GetComponent<NavMeshAgent>().isStopped = false;
        }
    }


    void ChaseTower(string tagName, string pointName, Transform[] lane_Tower)
    {
        if (searchTime >= 1.0f)
        {
            if (GameObject.FindGameObjectWithTag(tagName))
            {
                // "tower"という名前のタグ名の付いたGameObjectを取得しLinqでTransformを抽出         
                Transform[] lane_tower = GameObject.FindGameObjectsWithTag(tagName).Select(e => e.transform).ToArray();
                // OrderByで距離(昇順)でソート         
                lane_Tower = lane_tower.OrderBy(e => Vector3.Distance(e.transform.position, p_core.transform.position)).ToArray();
            }
            else
            {
                lane_Tower[0] = core.transform;
            }
            //serchTag(gameObject, "Tower_left");
            if (lane_Tower[0].name == pointName)
            {
                Transform hoge = lane_Tower[0];
                if (lane_Tower.Length == 1)
                {
                    lane_Tower[0] = core.transform;
                }
                else
                {
                    lane_Tower[0] = lane_Tower[1];
                    lane_Tower[1] = hoge;
                }
            }
            //最も近かった、"Enemy"タグのオブジェクトを取得
            nearEnemy = serchTag(gameObject, "Enemy");

            searchTime = 0;
        }
        if (lane_Tower[0])
        {
            target = lane_Tower[0].transform;
        }
    }

    void AttackTT()
    {

        if (distance <= stopDistance)

        {
            Attack();
        }
        else
        {
            // Naviを動かす
            agent.GetComponent<NavMeshAgent>().isStopped = false;
        }
    }

    void SearchLine()
    {
        if (botTower.Length >= 2)
        {
            _nearTower[0] = serchTag(gameObject, "BotLine" /*"Tower_left"*/);
        }
        else
        {
            _nearTower[0] = serchTag(gameObject, "BotLine"); ;
        }
        if (topTower.Length >= 2)
        {
            _nearTower[1] = serchTag(gameObject, "TopLine" /*"Tower_rigth"*/);
        }
        else
        {
            _nearTower[1] = serchTag(gameObject, "TopLine"); ;
        }
        if (midTower.Length >= 2)
        {
            _nearTower[2] = serchTag(gameObject, "MidLine"/*"Tower_center"*/);
        }
        else
        {
            _nearTower[2] = serchTag(gameObject, "MidLine");

            //            _nearTower[2] = core;
        }
        nearTower = _nearTower.OrderBy(e => Vector3.Distance(e.transform.position, gameObject.transform.position)).ToArray();
        if (nearTower[0] != core)
        {
            if (nearTower[0] == _nearTower[0])
            {
                //ボットレーンにいる
                isBotLine = true;
            }
            if (nearTower[0] == _nearTower[1])
            {
                //ボットレーンにいる
                isTopLine = true;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "EnemyArrow")
        {
            enemyAttack = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy_Sword")
        {
            enemyAttack = true;
        }
    }
    //private void OnTriggerStay(Collider other)
    //{
    //    //Debug.Log("Trigger:" + other.gameObject.tag);
    //    if (other.gameObject.tag == "TopLine")
    //    {
    //        isTopLine = true;
    //        //Debug.Log("Top");
    //    }
    //    else
    //    {
    //        isTopLine = false;
    //    }

    //    if (other.gameObject.tag == "BotLine")
    //    {
    //        //ボットレーンにいる
    //        isBotLine = true;
    //        //Debug.Log("bot");
    //    }
    //    else
    //    {
    //        //ボットレーンいない
    //        isBotLine = false;
    //    }
    //}
}
