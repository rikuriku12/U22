using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public int PHP;
    [SerializeField] float nowHp,time;
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
        if(playerStatus.PHp > Maxhp)
        {
            Maxhp = playerStatus.PHp;
        }
        if(Maxhp > playerStatus.PHp + (Maxhp  / 500 ))
        {
            time += Time.deltaTime;
            if (time > 1 )
            {
                playerStatus.PHp += Maxhp / 500;
                time = 0;
            }
               
        }
        Hp.fillAmount = playerStatus.PHp / Maxhp;
        
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