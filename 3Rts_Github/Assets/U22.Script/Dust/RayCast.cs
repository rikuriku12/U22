using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    private RaycastHit Hit;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame

    void Update()
    {

        if (Physics.Raycast(transform.position, Vector3.down, out Hit))
        {

            Debug.Log(Hit.point);//デバッグログにヒットした場所を出す
                                 //RayTest();
        }

        /*void RayTest()
        {
            //Rayの作成　　　　　　　↓Rayを飛ばす原点　　　↓Rayを飛ばす方向
            Ray ray = new Ray(transform.position, new Vector3(0, -1, 0));

            //Rayが当たったオブジェクトの情報を入れる箱
            RaycastHit hit;

            //Rayの飛ばせる距離
            int distance = 2;

            //Rayの可視化    ↓Rayの原点　　　　↓Rayの方向　　　　　　　　　↓Rayの色
            Debug.DrawLine(ray.origin, ray.direction * distance, Color.red);

            //もしRayにオブジェクトが衝突したら
            //                  ↓Ray  ↓Rayが当たったオブジェクト ↓距離
            if (Physics.Raycast(ray, out hit, distance))
            {

                //Rayが当たったオブジェクトのtagがPlayerだったら
                if (hit.collider.tag == "Grand")
                    Debug.Log("RayがPlayerに当たった");
            }
        }
        */
    }
}
