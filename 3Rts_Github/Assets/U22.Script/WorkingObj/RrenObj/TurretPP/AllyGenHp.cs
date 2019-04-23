using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AllyGenHp : MonoBehaviour
{
    public int AllyHp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(AllyHp <= 0)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene("over");
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag ==  "Enemy")
        {
            AllyHp -= 20;
        }
    }
}
