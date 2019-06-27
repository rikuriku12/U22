using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordingCam : MonoBehaviour
{
    //X軸の角度を制限するための変数
    float angleUp = 360f;
    float angleDown = -360f;

    //ユニティちゃんをInspectorで入れる
    [SerializeField] GameObject player;
    //Main CameraをInspectorで入れる
    [SerializeField] Camera cam;

    //Cameraが回転するスピード
    [SerializeField] float rotate_speed = 3;
    //Axisの位置を指定する変数
    [SerializeField] Vector3 axisPos;

    //コントローラーのための配列
    string[] ConNum;

    void Start()
    {
        //CameraのAxisに相対的な位置をlocalPositionで指定
        cam.transform.localPosition = new Vector3(0, 1.5f, -3f);
        //CameraとAxisの向きを最初だけそろえる
        cam.transform.localRotation = transform.rotation;
        //コントローラーが何台接続されているか
        ConNum = Input.GetJoystickNames();
    }

    void Update()
    {
        if (player)
        {
            //Axisの位置をユニティちゃんの位置＋axisPosで決める
            transform.position = player.transform.position + axisPos;
        }

        //三人称の時のCameraの位置にマウススクロールの値を足して位置を調整
        //thirdPosAdd = thirdPos + new Vector3(0, 0, scrollLog);

        if ((ConNum[0] == ""))
        {
            //Cameraの角度にマウスからとった値を入れる
            transform.eulerAngles += new Vector3(
            Input.GetAxis("Mouse Y")/*("R Stick V")*/ * rotate_speed,
            Input.GetAxis("Mouse X")/*("R Stick H")*/ * rotate_speed
            , 0);
        }
        else
        {
            //Cameraの角度にマウスからとった値を入れる
            transform.eulerAngles += new Vector3(
            Input.GetAxis("R Stick V") * rotate_speed,
            Input.GetAxis("R Stick H") * rotate_speed
            , 0);
        }
        //X軸の角度
        float angleX = transform.eulerAngles.x;
        //X軸の値を180度超えたら360引くことで制限しやすくする
        if (angleX >= 180)
        {
            angleX = angleX - 360;
        }
        //Mathf.Clamp(値、最小値、最大値）でX軸の値を制限する
        transform.eulerAngles = new Vector3(
            Mathf.Clamp(angleX, angleDown, angleUp),
            transform.eulerAngles.y,
            transform.eulerAngles.z
        );
    }
}
