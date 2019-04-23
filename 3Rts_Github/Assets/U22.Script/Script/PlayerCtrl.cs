using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public float speed = 3.0f;
    float moveX = 0f;
    float moveZ = 0f;

    CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        moveX = Input.GetAxis("Horizontal") * speed;//Horizontal
        moveZ = Input.GetAxis("Vertical") * speed;//Vertical
        Vector3 direction = new Vector3(moveX, 0, moveZ);

        controller.SimpleMove(direction);
    }

}
