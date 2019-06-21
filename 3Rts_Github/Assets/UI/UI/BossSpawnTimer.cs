using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawnTimer : MonoBehaviour
{
    [SerializeField]float count,Time_limit;
    bool Spawn;
    [SerializeField]GameObject boss,core;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;
        if (!Spawn)
        {
            if (count > Time_limit)
            {
                Instantiate(boss, core.transform.position, Quaternion.Euler(0, 0, 0));
                Spawn = true;
            }
        }
    }
}
