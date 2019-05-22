using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public int PHP;
    [SerializeField] float nowHp;
    [SerializeField] private Image Hp;
    [SerializeField] GameObject Player;
    PlayerStatus playerStatus;
    float Maxhp;
    // Start is called before the first frame update
    void Start()
    {
        //nowHp = hoge.GetnowHp();
        playerStatus = Player.GetComponent<PlayerStatus>();
        Maxhp = playerStatus.PHp;
    }

    // Update is called once per frame
    void Update()
    {
        Hp.fillAmount = playerStatus.PHp / Maxhp;

        //spaceを押したらHPが減る
        if (Input.GetKeyDown("space"))
        {
            Hp.fillAmount -= 0.01f;
        }
    }
    /// <summary>
    /// 切り取り用
    /// </summary>
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