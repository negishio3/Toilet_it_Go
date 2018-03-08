using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGM_mura : MonoBehaviour {

    static public BGM_mura instance;

    public AudioClip BGM1;
    public AudioClip BGM2;

    private AudioSource audioSource;

    public int BGMFlg = 0;

    

    private void Awake()
    {
        
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            
        }
        else 
        {
            Destroy(gameObject);
        }
        audioSource = gameObject.GetComponent<AudioSource>();

        SceneManager.LoadScene("green");
    }
    public void StartBGM1()
    {
        audioSource.clip = BGM1;
        audioSource.Play();
        BGMFlg = 1;
    }
    public void StartBGM2()
    {
        audioSource.clip = BGM2;
        audioSource.Play();
        BGMFlg = 2;
    }
}
