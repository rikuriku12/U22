using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NaviEnemyOld : MonoBehaviour
{
    NavMeshAgent agent;
    
    private Transform towe; //目的地
    private Transform player; //player
    private Transform turret;
    float agentDistance;//プレイヤー、敵間の距離
    [SerializeField] float plyerDistance;
    
    
    Vector3 position;
    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        towe = GameObject.FindWithTag("Towe").transform;
        player = GameObject.FindWithTag("Player").transform;
        turret = GameObject.FindWithTag("Turret").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //EnemyとPlayerの距離
        agentDistance = Vector3.Distance(this.agent.transform.position, 
                                            player.transform.position);

        if (agentDistance <= plyerDistance)
        {
            //目的地をプレイヤに設定
            agent.SetDestination(player.position);
            
        }
        else
        {
            //目的地をタワーに設定
            agent.SetDestination(towe.position);
                  
        }
        //Debug.Log(traget.position);
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "T_Bullet")
        {
            agent.SetDestination(turret.position);
        }

    }
}


