using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TurretSet : MonoBehaviour
{

    //private CharacterController characterController;//※1
    private Vector3 velocity;//※1
    public GameObject SetTurret;//※3
    /*public GameObject SetCanon;
    public GameObject SetLaser;
    public GameObject SetOverdW;*/
    public Transform muzzle;//※3
   // public float speed;//※3
    int Settime;
    int cooltime;
    private RaycastHit Hit;
    Vector3 HitP;
    public int SetLimit;
    public int Setcount;

    public void Start()//ゲーム開始時に一度だけ実行する内容
    {
        //characterController = GetComponent<CharacterController>();//※1

    }

    void Update()
    {
        /*if (Physics.Raycast(transform.position, Vector3.down, out Hit))
        {

            HitP = Hit.point;
            Debug.Log(HitP);//デバッグログにヒットした場所を出す
        }*/
        /*if (Input.GetMouseButtonDown(0))
        {
            float distance = 100; // 飛ばす&表示するRayの長さ
            float duration = 3;   // 表示期間（秒）

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * distance, Color.red, duration, false);

            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit, distance))
            {
                GameObject hitObject = hit.collider.gameObject;
                // （以下略）
            }
        }
        */
    }
   public void FixedUpdate()//ゲーム開始時に何度も実行する内容
    {
        cooltime++;
        if (cooltime >= 30)
        {
            if (Input.GetButton("L1") || Input.GetKey("z"))
            {


                if ((Input.GetKeyDown("x") ||Input.GetButtonDown("joystick X"))&&Setcount<SetLimit)//※3
                {
                    StartCoroutine("Turret");//※3
                    Setcount++;
                    cooltime = 0;
                    Debug.Log(Setcount);
                }

                /*if (Input.GetMouseButtonDown(1) || Input.GetAxis("ArrowH") < 0)//※3
                {
                    StartCoroutine("Canon");//※3
                    cooltime = 0;
                }

                if (Input.GetMouseButtonDown(0) || Input.GetAxis("ArrowV") > 0)//※3
                {
                    StartCoroutine("Laser");//※3
                    cooltime = 0;
                }

                if (Input.GetMouseButtonDown(1) || Input.GetAxis("ArrowV") < 0)//※3
                {
                    StartCoroutine("OverdW");//※3
                    cooltime = 0;
                }
            }*/
            }

        }
    }

            IEnumerator Turret()//※3
            {

                yield return new WaitForSeconds(0.5f);//※3
                Vector3 force;//※3
                GameObject Turrets = GameObject.Instantiate(SetTurret) as GameObject;//※3
                Turrets.transform.position = muzzle.position;//※3
                                                             //force = this.gameObject.transform.forward * speed;//※3
                                                             //Destroy(bullets.gameObject, 2);//※3
            }

            /*IEnumerator Canon()//※3
            {

                yield return new WaitForSeconds(0.5f);//※3
                Vector3 force;//※3
                GameObject Canons = GameObject.Instantiate(SetCanon) as GameObject;//※3
                Canons.transform.position = muzzle.position;//※3
                                                            //force = this.gameObject.transform.forward * speed;//※3
                                                            //Destroy(bullets.gameObject, 2);//※3
            }

            IEnumerator Laser()//※3
            {

                yield return new WaitForSeconds(0.5f);//※3
                Vector3 force;//※3
                GameObject Lasers = GameObject.Instantiate(SetLaser) as GameObject;//※3
                Lasers.transform.position = muzzle.position;//※3
                                                            //force = this.gameObject.transform.forward * speed;//※3
                                                            //Destroy(bullets.gameObject, 2);//※3
            }

            IEnumerator OverdW()//※3
            {

                yield return new WaitForSeconds(0.5f);//※3
                Vector3 force;//※3
                GameObject OverdWs = GameObject.Instantiate(SetOverdW) as GameObject;//※3
                OverdWs.transform.position = muzzle.position;//※3
                                                             //force = this.gameObject.transform.forward * speed;//※3
                                                             //Destroy(bullets.gameObject, 2);//※3
            }*/
        }
    