using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EnemyGenHpText : MonoBehaviour
{
    
    EnemyGenHp cs;
    GameObject Php;
    TextMeshProUGUI HPtext;
    GameObject PhpUI;
    // Use this for initialization
    void Start()
    {
        Php = GameObject.Find("EnemyGeneral");
        cs = Php.GetComponent<EnemyGenHp>();
        PhpUI = GameObject.Find("EnemyGenHpText");
        HPtext = PhpUI.GetComponent<TextMeshProUGUI>();
        int Php1 = cs.HP;
    }
    
    // Update is called once per frame

    void Update()
    {
        int Php1 = cs.HP;
        HPtext.text = Php1.ToString();
    }
}
