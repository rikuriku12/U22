using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossCtrl : MonoBehaviour
{
    public int Hp;
    public ParticleSystem particle_arrow;
    public ParticleSystem particle_sword;
        // Start is called before the first frame update
    void Start()
    {
        particle_arrow.Stop();
        particle_sword.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if(Hp <= 0)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene("Clear");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "P_Sword")
        {
            Hp -= GameObject.FindWithTag("Player").GetComponent<PlayerStatus>().AttackPower + 50;
            particle_sword.Play();
        }
        if (other.gameObject.tag == "P_Arrow")
        {
            Hp -= 5;
            particle_arrow.Play();
            Debug.Log("5");
        }
    }
}
