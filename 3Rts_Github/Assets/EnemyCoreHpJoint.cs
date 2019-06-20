using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCoreHpJoint : MonoBehaviour
{
    Image enemyHpvar;
    EnemyCoreCtrl EnemyCoreCtrl;
    float Maxhp;
    // Start is called before the first frame update
    void Start()
    {
        enemyHpvar = GetComponent<Image>();
        EnemyCoreCtrl = transform.root.GetComponent<EnemyCoreCtrl>();
        Maxhp = EnemyCoreCtrl.EnemyCoreHp;
    }

    // Update is called once per frame
    void Update()
    {
        enemyHpvar.fillAmount = EnemyCoreCtrl.EnemyCoreHp / Maxhp;
    }
}
