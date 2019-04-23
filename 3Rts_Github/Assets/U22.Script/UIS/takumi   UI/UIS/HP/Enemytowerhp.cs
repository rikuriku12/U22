using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Enemytowerhp : MonoBehaviour
{
    Slider fa;
    TowerHp thp;
    GameObject Tower;
    int THpSllider;
    // Start is called before the first frame update
    void Start()
    {
        Tower = transform.root.gameObject;
        thp = Tower.GetComponent<TowerHp>();
        THpSllider = thp.Thp;

        fa = GetComponent<Slider>();
        /* float maxFaHP = 5000f;
         float EnemyFaHP = 5000f;*/

        fa.maxValue = THpSllider;
        fa.value = THpSllider;
    }

    // Update is called once per frame
    void Update()
    {
        THpSllider = thp.Thp;
        fa.value = THpSllider;

        Debug.Log(THpSllider);

    }
}
