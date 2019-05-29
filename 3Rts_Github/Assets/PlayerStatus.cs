using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerStatus : MonoBehaviour
{
    // Start is called before the first frame update
    public float PHp;

    Animator animator;
    AnimatorStateInfo stateInfo;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>(); // アニメーターのコンポーネントを参照する
        stateInfo = animator.GetCurrentAnimatorStateInfo(0);
    }

    private void Update()
    {
        stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (PHp <= 0)
        {
            SceneManager.LoadScene("Over");
        }

    }
    // Update is called once per frame
    public void OnCollisionEnter(Collision collision)//矢が刺さるように
    {
        if (!(stateInfo.IsTag("rolling")))
        {
            if (collision.gameObject.tag == "EnemyArrow")
            {
                PHp -= 50;
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (!(stateInfo.IsTag("rolling")))
        {
            if (other.gameObject.tag == "Enemy_Sword")
            {
                PHp -= 20;
            }

            if (other.gameObject.tag == "TowerBurret")
            {
                PHp -= 50;
            }

            if (other.gameObject.tag == "Boss_Sword")
            {
                PHp -= 20;
            }
        }
    }
}