using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadysamuraiHp : MonoBehaviour
{
    [SerializeField] int Hp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Hp <= 0)
        {
            Destroy(gameObject.transform.root.gameObject);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy_Sword")
        {
            Hp -= 10; 
        }

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy_Arrow")
        {
            Hp -= 10;
        }
    }
}
