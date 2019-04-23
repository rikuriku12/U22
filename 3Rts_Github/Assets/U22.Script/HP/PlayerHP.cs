using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    Slider hpslider;
    [SerializeField]float nowHp;

    // Start is called before the first frame update
    void Start()
    {
        hpslider = GetComponent<Slider>();

        float maxHp = 1000f;
        nowHp = 1000f;

        //スライダー最大値の設定
        hpslider.maxValue = maxHp;

        //スライダーの現在地設定
        hpslider.value = nowHp;

    }

    // Update is called once per frame
    void Update()
    {
        //スライダーの現在地設定
        //hpslider.value = nowHp;

        //spaceを押したらHPが減る
        if (Input.GetKeyDown("space"))
        {
            hpslider.value -= 20f;
        }
    }
    // 外部からの読み取り用.
    public float GetnowHp()
    {
        return nowHp;
    }

    // 外部からの書き込み用.
    public void SetnowHp(float _nowHp)
    {
        nowHp = _nowHp;
    }
}
