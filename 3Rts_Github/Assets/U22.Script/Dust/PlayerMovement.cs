
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Transform _playerTrans;
    private float DIFF = 7.5f;
    Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        _playerTrans = this.transform;
        rb = this.gameObject.transform.Find("body").GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rollPlayer();
        }
        else
        {
            movePlayer();
        }
    }

    /**
	 * Playerを矢印キーで動かす関数
	 */
    private void movePlayer()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.velocity = (Vector3.forward * Time.deltaTime * 50000);
            //_playerTrans.Translate(Vector3.forward * DIFF);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            _playerTrans.Translate(Vector3.right * DIFF);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            _playerTrans.Translate(Vector3.left * DIFF);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            _playerTrans.Translate(Vector3.back * DIFF);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }

    /**
	 * Playerを左右に回転させる関数
	 */
    private void rollPlayer()
    {
        Quaternion q = _playerTrans.localRotation;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            q = q * Quaternion.Euler(0f, -DIFF, 0f);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            q = q * Quaternion.Euler(0f, DIFF, 0f);
        }
        _playerTrans.localRotation = q;
    }

    /* オブジェクト同士の衝突判定 */
    // オブジェクトが衝突したとき
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Enter: " + collision.gameObject.name); // 衝突先のオブジェクト名を取得
    }

    // オブジェクトが離れた時
    void OnCollisionExit(Collision collision)
    {
        Debug.Log("Exit: " + collision.gameObject.name); // 衝突していたオブジェクト名を取得
    }

    // オブジェクトが触れている間
    void OnCollisionStay(Collision collision)
    {
        Debug.Log("Stay: " + collision.gameObject.name); // 触れているオブジェクト名を取得
    }
}
