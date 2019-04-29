using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HPTextMain : MonoBehaviour {
    PlayerController cs;
    GameObject Php;
    TextMeshProUGUI HPtext;
    GameObject PhpUI;
	// Use this for initialization
	void Start () {
        Php = GameObject.Find("Player");
        cs = Php.GetComponent<PlayerController>();
        PhpUI = GameObject.Find("HP");
        HPtext = PhpUI.GetComponent<TextMeshProUGUI>();
        //int Php1 = cs.Hp;
    }
	
	// Update is called once per frame

	void Update () {
        //int Php1 = cs.Hp;
        //HPtext.text = Php1.ToString();
    }
}
