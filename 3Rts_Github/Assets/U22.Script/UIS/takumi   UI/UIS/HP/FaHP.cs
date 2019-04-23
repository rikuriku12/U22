using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FaHP : MonoBehaviour
{
    Slider fa;
    THP thp;
    GameObject TurretA;
    int HpSllider;
    // Start is called before the first frame update
    void Start()
    {
        TurretA = transform.root.gameObject;
        thp = TurretA.GetComponent<THP>();
        HpSllider = thp.HP;

        fa = GetComponent<Slider>();
        /* float maxFaHP = 5000f;
         float EnemyFaHP = 5000f;*/
        
        fa.maxValue = HpSllider;
        fa.value = HpSllider;
    }

    // Update is called once per frame
    void Update()
    {
        HpSllider = thp.HP;
        fa.value = HpSllider;
    
    Debug.Log(HpSllider);

    }
}
