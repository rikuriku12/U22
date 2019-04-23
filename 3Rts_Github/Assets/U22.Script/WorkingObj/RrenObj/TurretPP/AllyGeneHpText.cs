using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AllyGeneHpText : MonoBehaviour
{
    AllyGenHp cs;
    GameObject Allyhp;
    TextMeshProUGUI AHPtext;
    GameObject AhpUI;
    // Use this for initialization
    void Start()
    {
        Allyhp = GameObject.Find("PlayerGeneral");//HP対象オブジェのを取得
        cs = Allyhp.GetComponent<AllyGenHp>();
        AhpUI = GameObject.Find("AllyHpText");
        AHPtext = AhpUI.GetComponent<TextMeshProUGUI>();
        
    }

    // Update is called once per frame

    void Update()
    {
        
        int Allyhp1 = cs.AllyHp;
        AHPtext.text = Allyhp1.ToString();
        
    }
}
