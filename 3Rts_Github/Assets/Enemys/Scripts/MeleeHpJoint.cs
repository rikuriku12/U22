using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MeleeHpJoint : MonoBehaviour
{
    Image enemyHpvar;
    MeleeEnemyHp enemyHP;
    float Maxhp;
    // Start is called before the first frame update
    void Start()
    {
        enemyHpvar = GetComponent<Image>();
        enemyHP = transform.root.GetComponent<MeleeEnemyHp>();
        Maxhp = enemyHP.Hp;
    }

    // Update is called once per frame
    void Update()
    {
        enemyHpvar.fillAmount = enemyHP.Hp / Maxhp;
    }
}