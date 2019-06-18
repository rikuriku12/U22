using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
public class SwordCollider : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("joystick X"))
        {
            GetComponent<BoxCollider>().enabled = true;
        }

        else
        {
            GetComponent<BoxCollider>().enabled = false;
        }
    }
}
