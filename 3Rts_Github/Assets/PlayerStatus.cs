using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerStatus : MonoBehaviour
{
    // Start is called before the first frame update
    public float PHp;
    public int AttackPower;
    public ParticleSystem DamegeArrow;
    public ParticleSystem DamegeSword;
    public ParticleSystem DamegeTower;

    // Start is called before the first frame update
    void Start()
    {
        DamegeArrow.Stop();//最初は停止
        DamegeSword.Stop();
        DamegeTower.Stop();
    }

    private void Update()
    {
        if (PHp <= 0)
        {
            SceneManager.LoadScene("Over");
        }
    }
    // Update is called once per frame
    public void OnCollisionEnter(Collision collision)
    { 
        if (collision.gameObject.tag == "EnemyArrow")
        {
            PHp -= 50;
            Debug.Log("5");
            //ダメージ後にパーティクル発生
            DamegeArrow.Play();
        }

        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy_Sword")
        {
            PHp -= 20;
            Debug.Log("5");
            //ダメージ後にパーティクル発生
            DamegeSword.Play();
        }

        if (other.gameObject.tag == "TowerBurret")
        {
            PHp -= 100;
            Debug.Log("5");
            //ダメージ後にパーティクル発生
            DamegeTower.Play();
        }
    }
}