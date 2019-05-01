﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //移動入力
    float inputHorizontal, inputVertical;

    // キャラクターコントローラ（カプセルコライダ）の参照
    private CapsuleCollider col;
    private Rigidbody rb;

    // キャラクターコントローラ（カプセルコライダ）の移動量
    private Vector3 velocity;
    //　ジャンプ力
    [SerializeField]
    private float moveSpeed;

    public Animator animCon;  //  アニメーションするための変数
    public AnimatorStateInfo stateInfo;

    //コントローラーのための配列
    string[] ConNum;

    private void Start()
    {
        animCon = GetComponent<Animator>(); // アニメーターのコンポーネントを参照する
        stateInfo = animCon.GetCurrentAnimatorStateInfo(0);
        velocity = Vector3.zero;

        // CapsuleColliderコンポーネントを取得する（カプ   セル型コリジョン）
        col = GetComponent<CapsuleCollider>();
        rb = GetComponent<Rigidbody>();

        //コントローラーが何台接続されているか
        ConNum = Input.GetJoystickNames();
    }

    private void Update()
    {
        //現在のアニメーション
        stateInfo = animCon.GetCurrentAnimatorStateInfo(0);
        if ((ConNum[0] == ""))
        {
            inputHorizontal = /*Input.GetAxisRaw("Horizontal");*/ Input.GetAxisRaw("L Stick H");
            inputVertical = /*Input.GetAxisRaw("Vertical");*/ Input.GetAxisRaw("L Stick V");
        }
        /*else
        {
            inputHorizontal = Input.GetAxisRaw("L Stick H");
            inputVertical = Input.GetAxisRaw("L Stick V");
        }
        */
        Move();
        Weapon();
    }
    //行動関連
    private void Move()
    {
        // ▼▼▼移動処理▼▼▼
        if (inputHorizontal == 0 && inputVertical == 0)  //  テンキーや3Dスティックの入力（GetAxis）がゼロの時の動作
        {
            animCon.SetBool("Run", false);
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
            rb.angularVelocity = new Vector3(0, rb.velocity.y, 0);
        }
        else
        {
            animCon.SetBool("Run", true);  //  Runモーションする
        }
        if (animCon.GetBool("Run") == true)
        {
            if (!animCon.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
            {
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
        }

        // ▼▼▼ジャンプ処理▼▼▼
        //　ジャンプキー（デフォルトではSpace）を押したらY軸方向の速度にジャンプ力を足す
        if ((Input.GetButtonDown("Jump")||Input.GetButtonDown("joystick A"))
            && !animCon.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            animCon.SetBool("Jump", true);
        }
    }

    private void Weapon()
    {
        if ((Input.GetMouseButtonDown(0) || Input.GetButtonDown("joystick X"))
        && !animCon.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            animCon.SetBool("Attack", true);
        }
    }
}
