using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TowerHpJoint : MonoBehaviour
{
    Image TowerHpBar;
    TowerCtrl TowerCtrl;
    float Maxhp;
    // Start is called before the first frame update
    void Start()
    {
        TowerHpBar = GetComponent<Image>();
       TowerCtrl = transform.parent.parent.parent.GetComponent<TowerCtrl>();
        Maxhp = TowerCtrl.Hp;
    }

    // Update is called once per frame
    void Update()
    {
        TowerHpBar.fillAmount = TowerCtrl.Hp / Maxhp;
    }
}
