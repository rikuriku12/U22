using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class BossManager : MonoBehaviour
{
   // public GameObject target;
    private NavMeshAgent agent;
    private GameObject Player;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        Player = GameObject.FindWithTag("Player");

    }

    void Update()
    {

        // ターゲットの位置を目的地に設定する。

        if (Player)
        {
            agent.SetDestination(Player.transform.position);
        }
    }
}
