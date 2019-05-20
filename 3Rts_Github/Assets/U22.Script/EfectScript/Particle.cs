using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    public ParticleSystem particle;//パーティクルシステムの使用の定義
    ccc cs;//スクリプトが入る箱
    bool flagpart;//cccのflagが入る箱
    GameObject par;//cccが入ったオブジェクトを取得する箱

    // Start is called before the first frame update
    void Start()
    {
        particle.Stop();  //最初は止める

    }

    // Update is called once per frame
    void Update()
    {
        //{hit-blue-1 のエフェクト}

        /*
        par = GameObject.Find("Player");//1.Playerの取得
        cs = par.GetComponent<ccc>();   //2.Playerのスクリプト「ccc」を取得する
        flagpart = cs.flag;             //3.cccの中のflag変数を取得する


        if (Input.GetKey("w"))//wボタンで
        {
            particle.Play();
        }



        if (flagpart == true)//フラグで
        {

            particle.Play();//再生
            cs.flag = false;//cccのフラグをリセット。これをしないとflagはt
        }
        */
        //----------------------------------------------------------------------------------------

        //{hit-blue-2 のエフェクト}

        /*
        par = GameObject.Find("Player2");
        cs = par.GetComponent<ccc>();
        flagpart = cs.flag;
     

        if (Input.GetKey("e"))//eボタンで
        {
            particle.Play();
        }
   
        if (flagpart == true)
        {
            particle.Play();
            cs.flag = false;
        }
        */
        //-----------------------------------------------------------------------------------------

        //{hit-blue-3 のエフェクト}

        /*
        par = GameObject.Find("Player3");
        cs = par.GetComponent<ccc>();
        flagpart = cs.flag;

        if (Input.GetKey("r"))//rボタンで
        {
            particle.Play();
        }

        if (flagpart == true)
        {
            particle.Play();
            cs.flag = false;
        }
        */
        //-----------------------------------------------------------------------------------------

        //{hit-line-1のエフェクト}
        /*
        par = GameObject.Find("Player4");
        cs = par.GetComponent<ccc>();
        flagpart = cs.flag;

        if (Input.GetKey("t"))//tボタンで
        {
            particle.Play();
        }

        if (flagpart == true)
        {
            particle.Play();
            cs.flag = false;
        }
        */
        //-----------------------------------------------------------------------------------------

        //{hit-line-2のエフェクト}
        /*
        par = GameObject.Find("Player5");
        cs = par.GetComponent<ccc>();
        flagpart = cs.flag;

        if (Input.GetKey("y"))//yボタンで
        {
            particle.Play();
        }

        if (flagpart == true)
        {
            particle.Play();
            cs.flag = false;
        }
        */
        //-----------------------------------------------------------------------------------------

        //{hit-outer-1のエフェクト}
        /*
        par = GameObject.Find("Player6");
        cs = par.GetComponent<ccc>();
        flagpart = cs.flag;

        if (Input.GetKey("u"))//uボタンで
        {
            particle.Play();
        }

        if (flagpart == true)
        {
            particle.Play();
            cs.flag = false;
        }
        */
        //-----------------------------------------------------------------------------------------

        //{hit-outer-2のエフェクト}
        /*
        par = GameObject.Find("Player7");
        cs = par.GetComponent<ccc>();
        flagpart = cs.flag;

        if (Input.GetKey("i"))//iボタンで
        {
            particle.Play();
        }

        if (flagpart == true)
        {
            particle.Play();
            cs.flag = false;
        }
        */
        //-----------------------------------------------------------------------------------------

        //{hit-red-1のエフェクト}
        /*
        par = GameObject.Find("Player8");
        cs = par.GetComponent<ccc>();
        flagpart = cs.flag;

        if (Input.GetKey("a"))//aボタンで
        {
            particle.Play();
        }

        if (flagpart == true)
        {
            particle.Play();
            cs.flag = false;
        }
        */
        //-----------------------------------------------------------------------------------------

        //{hit-red-2のエフェクト}
        /*
        par = GameObject.Find("Player9");
        cs = par.GetComponent<ccc>();
        flagpart = cs.flag;

        if (Input.GetKey("s"))//sボタンで
        {
            particle.Play();
        }

        if (flagpart == true)
        {
            particle.Play();
            cs.flag = false;
        }
        */
        //-----------------------------------------------------------------------------------------

        //{hit-red-3のエフェクト}
        /*
        par = GameObject.Find("Player10");
        cs = par.GetComponent<ccc>();
        flagpart = cs.flag;

        if (Input.GetKey("d"))//dボタンで
        {
            particle.Play();
        }

        if (flagpart == true)
        {
            particle.Play();
            cs.flag = false;
        }
        */
        //-----------------------------------------------------------------------------------------

        //{hit-white-1のエフェクト}
        /*
        par = GameObject.Find("Player11");
        cs = par.GetComponent<ccc>();
        flagpart = cs.flag;

        if (Input.GetKey("f"))//fボタンで
        {
            particle.Play();
        }

        if (flagpart == true)
        {
            particle.Play();
            cs.flag = false;
        }
        */
        //-----------------------------------------------------------------------------------------

        //{hit-white-2のエフェクト}
        /*
        par = GameObject.Find("Player12");
        cs = par.GetComponent<ccc>();
        flagpart = cs.flag;

        if (Input.GetKey("g"))//gボタンで
        {
            particle.Play();
        }

        if (flagpart == true)
        {
            particle.Play();
            cs.flag = false;
        }
        */
        //-----------------------------------------------------------------------------------------

        //{hit-white-3のエフェクト}
        /*
        par = GameObject.Find("Player13");
        cs = par.GetComponent<ccc>();
        flagpart = cs.flag;

        if (Input.GetKey("h"))//hボタンで
        {
            particle.Play();
        }

        if (flagpart == true)
        {
            particle.Play();
            cs.flag = false;
        }
        */
        //-----------------------------------------------------------------------------------------

        //{hit-white-2のエフェクト}
        /*
        par = GameObject.Find("Player14");
        cs = par.GetComponent<ccc>();
        flagpart = cs.flag;

        if (Input.GetKey("j"))//jボタンで
        {
            particle.Play();
        }

        if (flagpart == true)
        {
            particle.Play();
            cs.flag = false;
        }
        */
        //-----------------------------------------------------------------------------------------

        //{hit-yellow-1のエフェクト}
        /*
        par = GameObject.Find("Player15");
        cs = par.GetComponent<ccc>();
        flagpart = cs.flag;

        if (Input.GetKey("k"))//kボタンで
        {
            particle.Play();
        }

        if (flagpart == true)
        {
            particle.Play();
            cs.flag = false;
        }
        */
        //-----------------------------------------------------------------------------------------

        //{punch-1のエフェクト}
        /*
        par = GameObject.Find("Player16");
        cs = par.GetComponent<ccc>();
        flagpart = cs.flag;

        if (Input.GetKey("z"))//zボタンで
        {
            particle.Play();
        }

        if (flagpart == true)
        {
            particle.Play();
            cs.flag = false;
        }
        */
        //-----------------------------------------------------------------------------------------

        //{punch-2のエフェクト}
        /*
        par = GameObject.Find("Player17");
        cs = par.GetComponent<ccc>();
        flagpart = cs.flag;

        if (Input.GetKey("x"))//xボタンで
        {
            particle.Play();
        }

        if (flagpart == true)
        {
            particle.Play();
            cs.flag = false;
        }
        */
        //-----------------------------------------------------------------------------------------

        //{scratch-1のエフェクト}
        /*
        par = GameObject.Find("Player18");
        cs = par.GetComponent<ccc>();
        flagpart = cs.flag;

        if (Input.GetKey("c"))//cボタンで
        {
            particle.Play();
        }

        if (flagpart == true)
        {
            particle.Play();
            cs.flag = false;
        }
        */
        //-----------------------------------------------------------------------------------------

        //{scratch-2のエフェクト}
        /*
        par = GameObject.Find("Player19");
        cs = par.GetComponent<ccc>();
        flagpart = cs.flag;

        if (Input.GetKey("v"))//vボタンで
        {
            particle.Play();
        }

        if (flagpart == true)
        {
            particle.Play();
            cs.flag = false;
        }
        */
        //-----------------------------------------------------------------------------------------

        //{slash-1のエフェクト}
        /*
        par = GameObject.Find("Player20");
        cs = par.GetComponent<ccc>();
        flagpart = cs.flag;

        if (Input.GetKey("b"))//bボタンで
        {
            particle.Play();
        }

        if (flagpart == true)
        {
            particle.Play();
            cs.flag = false;
        }
        */
        //-----------------------------------------------------------------------------------------

        //{slash-2のエフェクト}
        /*
        par = GameObject.Find("Player21");
        cs = par.GetComponent<ccc>();
        flagpart = cs.flag;

        if (Input.GetKey("n"))//nボタンで
        {
            particle.Play();
        }

        if (flagpart == true)
        {
            particle.Play();
            cs.flag = false;
        }
        */
        //-----------------------------------------------------------------------------------------

        //{slash-3のエフェクト}

        /*par = GameObject.Find("Lady Samurai");
        cs = par.GetComponent<ccc>();
        flagpart = cs.flag;
        */
        if (Input.GetButton("joystick X"))//mボタンで
        {
            particle.Play();
        }

        if (flagpart == true)
        {
            particle.Play();
            cs.flag = false;
        }

    }

}

