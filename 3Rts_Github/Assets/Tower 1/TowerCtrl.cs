using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCtrl : MonoBehaviour
{
    [SerializeField] GameObject UI;
    public int Hp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Hp <= 0)
        {
            UI.GetComponent<UIctl>().skillPoint += 1;
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "P_Sword")
        {
            Hp -= 50;
        }

        if(other.gameObject.tag == "NPC_Sword")
        {
            Hp -= 20;
        }
    }
}
