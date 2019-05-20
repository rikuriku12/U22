using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TurretSet : MonoBehaviour
{
    private Vector3 velocity;//※1
    public GameObject SetTurret;
    public Transform muzzle;//※3
                            // public float speed;//※3
    int Settime;
    int cooltime;
    public float militaryforce;
    public float cost;
    //public int Setcount;

    public void Start()//ゲーム開始時に一度だけ実行する内容
    {

    }

    void Update()
    {
        if(militaryforce < 0)
        {
            militaryforce = 0;
        }
        if (militaryforce > 1)
        {
            militaryforce = 1;
        }
    }
    public void FixedUpdate()//ゲーム開始時に何度も実行する内容
    {
        cooltime++;
        if (cooltime >= 30)
        {
            if (Input.GetButton("L1") || Input.GetKey("z"))
            {
                if ((Input.GetKeyDown("x") || Input.GetButtonDown("joystick X")) && militaryforce > cost)//※3
                {
                    StartCoroutine("Turret");//※3
                    militaryforce -= cost;
                    cooltime = 0;
                }
            }

        }
    }

    public float Getmilitaryforce()
    {
        return militaryforce;
    }

    // 外部からの書き込み用.
    public void Setmilitaryforce(float _militaryforce)
    {
        militaryforce = _militaryforce;
    }

    IEnumerator Turret()//※3
    {

        yield return new WaitForSeconds(0.5f);//※3
        GameObject Turrets = GameObject.Instantiate(SetTurret) as GameObject;//※3
        Turrets.transform.position = muzzle.position;//※3
                                                     //force = this.gameObject.transform.forward * speed;//※3
                                                     //Destroy(bullets.gameObject, 2);//※3
    }
}
