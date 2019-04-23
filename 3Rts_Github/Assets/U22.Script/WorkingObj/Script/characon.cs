using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characon : MonoBehaviour
{
    [SerializeField]int weapon;

    float inputHorizontal;
    float inputVertical;
    public float moveSpeed = 3f;

    // キャラクターコントローラ（カプセルコライダ）の参照
    private CapsuleCollider col;
    private Rigidbody rb;

    // キャラクターコントローラ（カプセルコライダ）の移動量
    private Vector3 velocity;
    float Cooltime;
    //　ジャンプ力
    [SerializeField]
    private float jumpPower = 5f;

    Animator animCon;  //  アニメーションするための変数

    GameObject hpvar;
    PlayerHP playerHP;
    float nowhp;

    guncs _guncs;
    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        weapon = 1;

        Cooltime = 0;
        animCon = GetComponent<Animator>(); // アニメーターのコンポーネントを参照する

        velocity = Vector3.zero;

        // CapsuleColliderコンポーネントを取得する（カプ   セル型コリジョン）
        col = GetComponent<CapsuleCollider>();
        rb = GetComponent<Rigidbody>();

        hpvar = GameObject.Find("Slider(hp)");
        playerHP = hpvar.GetComponent<PlayerHP>();
        nowhp = playerHP.GetnowHp();

        Player = GameObject.Find("Player");
        _guncs = Player.GetComponent<guncs>();
    }

    // Update is called once per frame
    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("L Stick H");
        inputVertical = Input.GetAxisRaw("L Stick V");


        // ▼▼▼移動処理▼▼▼
        if (inputHorizontal == 0 && inputVertical == 0)  //  テンキーや3Dスティックの入力（GetAxis）がゼロの時の動作
        {
            animCon.SetBool("Run", false);  //  Runモーションしない
                                            /*
                                             if (Cooltime > 0)
                                             {
                                                 animCon.SetBool("Cool", true);
                                             }
                                         }
                                         */
                                            //else if (animCon.GetBool("Cool") == false)//  テンキーや3Dスティックの入力（GetAxis）がゼロではない時の動作
        }
        else
        {
            animCon.SetBool("Run", true);  //  Runモーションする
        }
        if(animCon.GetBool("Run") == true)
        {
            Cooltime += Time.deltaTime * 100f;

            velocity = Vector3.zero;

            velocity.y += Physics.gravity.y * Time.deltaTime;
            // カメラの方向から、X-Z平面の単位ベクトルを取得
            Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

            // 方向キーの入力値とカメラの向きから、移動方向を決定
            Vector3 moveForward = cameraForward * inputVertical + Camera.main.transform.right * inputHorizontal;

            // 移動方向にスピードを掛ける。ジャンプや落下がある場合は、別途Y軸方向の速度ベクトルを足す。
            rb.velocity = moveForward * moveSpeed + new Vector3(0, rb.velocity.y, 0);

            // キャラクターの向きを進行方向に
            if (moveForward != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(moveForward);
            }
        }
        /*
        else if(animCon.GetBool("Cool") == true)
        {
            Cooltime -= Time.deltaTime * 120f;
            if (Cooltime < 0)
            {
                animCon.SetBool("Cool", false);
            }
        }
        */
        //　ジャンプキー（デフォルトではSpace）を押したらY軸方向の速度にジャンプ力を足す
        if (Input.GetButtonDown("joystick A")
            && !animCon.GetCurrentAnimatorStateInfo(0).IsName("Jump")
            && !animCon.IsInTransition(0)
            //&& !animCon.GetBool("Cool") == true
        )
        {
            animCon.SetBool("Jump", true);
            rb.AddForce(transform.up * jumpPower);
        }

        if(Input.GetButtonDown("joystick Y")
            && !animCon.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            animCon.SetBool("Attack",true);
        }


        if(weapon == 1)
        {
            _guncs.Shot();
        }
        else if(weapon == 2)
        {

        }
    }
    // 重なり瞬間判定
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            nowhp -= 20;
            playerHP.SetnowHp(nowhp);
            Debug.Log("あたった");
        }

        if(other.gameObject.tag == "gun")
        {
            weapon = 1;
        }
        else if(other.gameObject.tag == "sword")
        {
            weapon = 2;
        }
    }
}
