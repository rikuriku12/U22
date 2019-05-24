using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossAnimator : MonoBehaviour
{
    NavMeshAgent agent;

    [SerializeField] private GameObject player;

    [SerializeField] Animator boss_Animator;

    float agentDistance;

    [SerializeField] float stopDistance;

    // Start is called before the first frame update
    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        boss_Animator = gameObject.GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");

        if (player)
        {
            boss_Animator.SetBool("walk", true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!(agentDistance <= stopDistance))
        {
            boss_Animator.SetBool("walk", true);
        }

        if (player)
        {
            agentDistance = Vector3.Distance(this.agent.transform.position, player.transform.position);

            if(agentDistance <= stopDistance)
            {
                BossAttack();
            }
            else
            {
                agent.isStopped = false;
                boss_Animator.SetBool("attack", false);
            }
        }
        else
        {
            if(agent.isStopped == true)
            {
                agent.isStopped = false;
            }
            
        }
    }

    void BossAttack()
    {
        boss_Animator.SetBool("walk", false);

        agent.isStopped = true;

        boss_Animator.SetBool("attack", true);
    }
}
