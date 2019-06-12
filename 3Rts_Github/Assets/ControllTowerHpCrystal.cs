using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllTowerHpCrystal : MonoBehaviour
{
    public int Border;
    GameObject Tower_GettingObj;
    TowerCtrl Tower_Controller;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Tower_GettingObj = transform.parent.parent.gameObject;
        Tower_Controller = Tower_GettingObj.GetComponent<TowerCtrl>();

        if(Border >= Tower_Controller.Hp)
        {
            Destroy(this.gameObject);
        }
    }
}
