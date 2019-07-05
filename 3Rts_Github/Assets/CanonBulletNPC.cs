using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBulletNPC : MonoBehaviour
{
    Transform target;//追いかける対象-オブジェクトをインスペクタから登録できるように
    public float speed;//移動スピード
    private Vector3 vec;
    private GameObject nearObj;         //最も近いオブジェクト
    private float searchTime = 0;    //経過時間


    // Start is called before the first frame update
    void Start()
    {
        //最も近かったオブジェクトを取得
        // nearObj = serchTag(gameObject, "Player");
        nearObj = serchTag(gameObject, "Player_NPC");
    }

    // Update is called once per frame
    void Update()
    {
        //GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject player_npc = GameObject.FindGameObjectWithTag("Player_NPC");

        target = player_npc.transform;
        float step = Time.deltaTime * speed;
        transform.position = Vector3.MoveTowards(transform.position, player_npc.transform.position, step);


        //経過時間を取得
        searchTime += Time.deltaTime;

        if (searchTime >= 1.0f)
        {
            //最も近かったオブジェクトを取得
            //nearObj = serchTag(gameObject, "Player");
            nearObj = serchTag(gameObject, "Player_NPC");
            //経過時間を初期化
            searchTime = 0;
        }
        step = Time.deltaTime * speed;
        transform.position = Vector3.MoveTowards(transform.position, nearObj.transform.position, step);

    }

    //指定されたタグの中で最も近いものを取得
    GameObject serchTag(GameObject nowObj, string tagName)
    {
        float tmpDis = 0;           //距離用一時変数
        float nearDis = 0;          //最も近いオブジェクトの距離
        //string nearObjName = "";    //オブジェクト名称
        GameObject targetObj = null; //オブジェクト

        //タグ指定されたオブジェクトを配列で取得する
        foreach (GameObject obs in GameObject.FindGameObjectsWithTag(tagName))
        {
            //自身と取得したオブジェクトの距離を取得
            tmpDis = Vector3.Distance(obs.transform.position, nowObj.transform.position);

            //オブジェクトの距離が近いか、距離0であればオブジェクト名を取得
            //一時変数に距離を格納
            if (nearDis == 0 || nearDis > tmpDis)
            {
                nearDis = tmpDis;
                //nearObjName = obs.name;
                targetObj = obs;
            }

        }
        //最も近かったオブジェクトを返す
        //return GameObject.Find(nearObjName);
        return targetObj;
    }
}
