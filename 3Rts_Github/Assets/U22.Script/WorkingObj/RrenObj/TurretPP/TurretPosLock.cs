using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPosLock : MonoBehaviour
{
    Transform wpn;
    // Start is called before the first frame update
    void Start()
    {
        wpn = this.transform;
        wpn.localPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
        wpn.localPosition = new Vector3(wpn.transform.position.x, wpn.transform.position.y, wpn.transform.position.z);
    }
}
