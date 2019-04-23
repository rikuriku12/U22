using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] GameObject bullet;//射出するオブジェクト
    [SerializeField] float bulletSpeed;//弾速
    [SerializeField] float interval;//射出間隔
    float countTime;//カウント

    [SerializeField]int distanse = 30;//レイの射程
    RaycastHit hit;//レイが当たったオブジェクトの情報


    // Start is called before the first frame update
    void Start()
    {
        //--初期化-----------------
        countTime = 0;
        //-------------------------

    }

    // Update is called once per frame
    void Update()
    {
        countTime += Time.deltaTime;
        //レイ
        Ray ray = new Ray(transform.position, transform.forward);
        
        //レイを可視化
        Debug.DrawLine(ray.origin, ray.direction * 100000, Color.red);

        //ヒットしたオブジェクト情報を取得
        if (Physics.Raycast(ray, out hit, distanse))
        {

            //レイがplayerにあたったら
            if (hit.collider.tag == "Player" || hit.collider.tag =="Towe")
            {
                Debug.Log("Playerにあたった");
                if (interval <= countTime)
                {
                    //弾の生成後、前方に射出
                    var bulletInstance = GameObject.Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
                    bulletInstance.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * bulletSpeed);
                    Debug.Log("生成");

                    //時間カウントのリセット
                    countTime = 0f;
                }
            }
        }
        

    }
}



