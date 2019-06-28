using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeSwordCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.root.GetComponent<Animator>().
          GetCurrentAnimatorStateInfo(0).IsName("Charge"))
        {
            GetComponent<BoxCollider>().enabled = true;
        }

        else
        {
            GetComponent<BoxCollider>().enabled = false;
        }
    }
}
