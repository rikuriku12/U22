using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSE : MonoBehaviour
{
    //格納変数
    public AudioClip Sound1;
    /*public AudioClip Sound2;
    public AudioClip Sound3;
    public AudioClip Sound4;
    public AudioClip Sound5;
    public AudioClip Sound6;
    public AudioClip Sound7;
    */

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        //コンポーネントを取得
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //キーが押されたら音声ファイルの再生
        if (Input.GetButton("joystick X"))
        {
            audioSource.PlayOneShot(Sound1);
        }

        /*if (Input.GetKeyDown(KeyCode.S))
        {
            audioSource.PlayOneShot(Sound2);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            audioSource.PlayOneShot(Sound3);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            audioSource.PlayOneShot(Sound4);
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            audioSource.PlayOneShot(Sound5);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            audioSource.PlayOneShot(Sound6);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            audioSource.PlayOneShot(Sound7);
        }
        */
    }

}
