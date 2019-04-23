using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guncs : MonoBehaviour
{
    public GameObject bullet;
    public Transform muzzle;
    public float speed = 1000;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shot()
    {
        if (Input.GetButtonDown("joystick X"))
        {
            StartCoroutine("shot");
        }
    }
    IEnumerator shot()
    {
        yield return new WaitForSeconds(0.5f);
        Vector3 force;
        GameObject bullets = GameObject.Instantiate(bullet) as GameObject;
        bullets.transform.position = muzzle.position;
        force = this.gameObject.transform.forward * speed;
        bullets.GetComponent<Rigidbody>().AddForce(force);
        Destroy(bullets.gameObject, 2);
    }
}
