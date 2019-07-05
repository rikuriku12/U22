using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonatNpc : MonoBehaviour
{
    public GameObject ObjB;
    public Transform muzzle;//※3
    GameObject target;
    // public float speed;//※3
    //public GameObject target;
    private GameObject nearObj;         //最も近いオブジェクト
    private float searchTime = 0;    //経過時間
    int cooltime;
    public int BurretModeTriggerN;
    CanonAt CanonAtSC;
    CanonAt CanonPCAtSC;
    public GameObject CanonB;
    // Start is called before the first frame update
    void Start()
    {

        //nearObj = serchTag(gameObject, "Player");
        CanonPCAtSC = CanonB.GetComponent<CanonAt>();

    }

    // Update is called once per frame
    void Update()
    {
        if (CanonPCAtSC.BurretModeTriggerP == 1)
        {
            this.gameObject.GetComponent<CanonatNpc>().enabled = false;
            BurretModeTriggerN = 0;
            CanonPCAtSC.enabled = true;
        }
        //else if(CanonPCAtSC.BurretModeTriggerP == 0)
        //{
        //    this.GetComponent<CanonatNpc>().enabled = true;
        //}
        cooltime++;

        searchTime += Time.deltaTime;

        if (searchTime >= 1.0f)
        {
            //最も近かったオブジェクトを取得
            nearObj = serchTag(gameObject, "Player_NPC");
            //経過時間を初期化
            searchTime = 0;
        }
        // float step = Time.deltaTime * speed;
        //transform.position = Vector3.MoveTowards(transform.position, nearObj.transform.position, step);
        //対象の位置の方向を向く
        //transform.LookAt(nearObj.transform);
        if (nearObj)
        {
            Vector3 targetPos = nearObj.transform.position;

            // ターゲットのY座標を自分と同じにすることで2次元に制限する。
            targetPos.y = this.transform.position.y;
            this.transform.LookAt(targetPos);
        }
        //自分自身の位置から相対的に移動する
        //transform.Translate(Vector3.forward * 0.01f);

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

    public void OnTriggerStay(Collider ATRange)
    {

        if (ATRange.gameObject.tag == "Player_NPC")
        {
            //CanonPCAtSC.enabled = false;
            BurretModeTriggerN = 1;
            if (searchTime >= 1.0f)
            {
                //最も近かったオブジェクトを取得
                nearObj = serchTag(gameObject, "Player_NPC");
                //経過時間を初期化
                searchTime = 0;
            }
            //transform.LookAt(nearObj.transform);
            if (cooltime >= 60)
            {
                if (ATRange.gameObject.tag == "Player_NPC")
                {
                    StartCoroutine("Turret");//※3
                    cooltime = 0;

                }
            }
        }
    }

    //public void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.tag == "Player_NPC")

    //}



    IEnumerator Turret()//※3
    {
        //BurretModeTriggerN = 1;
        yield return new WaitForSeconds(0.5f);//※3
                                              //Vector3 force;//※3
        GameObject ObjBs = GameObject.Instantiate(ObjB) as GameObject;//※3
        ObjBs.transform.position = muzzle.position;//※3
                                                   //force = this.gameObject.transform.forward * speed;//※3
                                                   //Destroy(bullets.gameObject, 2);//※3
    }
}


