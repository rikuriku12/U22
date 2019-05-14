using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyGenerater : MonoBehaviour
{
    [SerializeField] GameObject enemys;// 出現するオブジェクト
    [SerializeField] float nextTime;// 次に出現するまでの時間
    float counutTime;// 経過時間
    [SerializeField] float timeRag;//時間の変化
    [SerializeField] float time;//時間の変化

    //[SerializeField] int _maxNumEnemy;// 出現できる限界数
    int countEnemy;// 出現している数
    [SerializeField] int num;//1度に生成する数 
    
    private GameObject[] enemyObject;//エネミータグの付いたオブジェクト

    void Start()
    {
        //--初期化-------------------------
        countEnemy = 0;
        counutTime = 0.0f;
        //---------------------------------

        //ゲーム開始直後に出現
        for (int i = 0; i < num; i++)
        {
            GameObject.Instantiate(enemys, transform.position, Quaternion.Euler(0, 0, 0));
        }
    }

    void Update()
    {
        // エネミータグの付いたオブジェクトの数を数える
        enemyObject = GameObject.FindGameObjectsWithTag("Enemy");
        countEnemy = enemyObject.Length;
       // Debug.Log(enemyObject.Length);

        counutTime += Time.deltaTime;

        //// 出現数が最大数を超えていたら何もしない
        //if (_countEnemy >= _maxNumEnemy)
        //{
        //    return;
        //}
        //else
        //{
        //}

        // 経過時間がたったら
        if (nextTime < counutTime)
        {
            EnemyGenerate();
        }

        //2の約数体出現したら
        if (countEnemy % 2 == 0)
        {
            nextTime = time + timeRag;
        }
        else /*if (_countEnemy == 9)*/
        {
            nextTime = time - timeRag;
        }
    }

    // 敵の出現関数
    void EnemyGenerate()
    {
        // インスタンスを生成
        for (int i = 0; i < num; i++)
        {
            GameObject.Instantiate(enemys, transform.position, Quaternion.Euler(0, 0, 0));
        }
   
        //経過時間のリセット
        counutTime = 0.0f;
    }
}


