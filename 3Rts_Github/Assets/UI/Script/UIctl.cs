using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIctl : MonoBehaviour
{
    [SerializeField] int e;
    [SerializeField] Sprite[] Item;
    [SerializeField] GameObject[] Item_UI;
    GameObject Back;


    // Start is called before the first frame update
    void Start()
    {
        Back = GameObject.Find("Item_Background");
        Back.SetActive(false);
        for (int i = 0; i < Item_UI.Length; i++)
        {
            Item_UI[i].GetComponent<Image>().sprite = Item[i];
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("L1") || Input.GetKey("z"))
        {
            Back.SetActive(true);
            if (Input.GetButtonDown("joystick Y"))
            {
                e--;
                if (e < 0) e += Item.Length;
                imagechange();
            }
            if (Input.GetButtonDown("joystick X"))
            {
                e++;
                if (e >= Item.Length) e -= Item.Length;
                imagechange();
            }
        }
        else
        {
            Back.SetActive(false);
        }
    }

    private void imagechange()
    {
        for (int k = 0; k < Item_UI.Length; k++)
        {
            int g;
            g = e + k;
            if (g >= Item.Length) g -= Item.Length;
            if (g >= 0)
            {
                Item_UI[k].GetComponent<Image>().sprite = Item[g];
            }
            else
            {
                g = Item.Length - 1;
                Item_UI[k].GetComponent<Image>().sprite = Item[g];
            }
        }
    }
}