using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointMove : MonoBehaviour
{
   
    //標的
    GameObject target;
    MeshRenderer meshrenderer;
    float PoszI;
    public float speed;
    float PoszAn;
    int Count;
    GameObject PointForm;

    
    TurretSet TurretSet2;
    public int SetLimit;
    float SLim;
    float Scost;
    GameObject SetPointObject;

    public Material[]  _Material;
    //GameObject SetComponent;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Renderer>().material = _Material[0];
        PoszI = 0;
        PointForm = GameObject.Find("SetPoint");
       
    }

    // Update is called once per frame
    void Update()
    {
        PointForm = GameObject.Find("SetPoint");//セットポイントおぬじぇくとの取得
        
        meshrenderer = PointForm.GetComponent<MeshRenderer>();//セットポイントの外見の値の取得
        //meshrenderer.material.color = new Color(0, 0, 0, 0.0f);//常時ポイント透明化
        this.GetComponent<Renderer>().material = _Material[0];

        SetPointObject = GameObject.FindWithTag("Player");
        TurretSet2 = SetPointObject.GetComponent<TurretSet>();
        SLim = TurretSet2.militaryforce;
        Scost = TurretSet2.cost;

        Transform mytransform = this.transform;

         //if (Input.GetAxis("R Stick V") < 0 && Count<= 10)
         //{
         //   transform.position += transform.forward * speed * Time.deltaTime;
         //   Count++;
                   
         //}

        if (Input.GetButton("L1")|| Input.GetKey("z"))
        {
            //SLim = TurretSet2.SetLimit;
            //Scount = TurretSet2.Setcount;
            if (Scost >= SLim)
            {
                this.GetComponent<Renderer>().material = _Material[2];
                //meshrenderer.material.color = Color.red; ;
            }
            //meshrenderer.material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);//L1ボタンを押した時だけセットポイントを可視化
           else
            {
                this.GetComponent<Renderer>().material = _Material[1];
            }

        }

       
        //if (Input.GetAxis("R Stick V") > 0 && Count>=2)
        //{
        //    transform.position -= transform.forward * speed * Time.deltaTime;
        //    Count--;
                 
        //}
        //}
    }
}
