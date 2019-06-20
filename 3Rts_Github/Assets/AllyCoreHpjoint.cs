using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllyCoreHpjoint : MonoBehaviour
{
    Image enemyHpvar;
    AllyCoreCtrl AllyCoreHp;
    float Maxhp;
    // Start is called before the first frame update
    void Start()
    {
        enemyHpvar = GetComponent<Image>();
        AllyCoreHp = transform.root.GetComponent<AllyCoreCtrl>();
        Maxhp = AllyCoreHp.AllyCoreHP;
    }

    // Update is called once per frame
    void Update()
    {
        enemyHpvar.fillAmount = AllyCoreHp.AllyCoreHP / Maxhp;
    }
}
