using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SE_murata : MonoBehaviour
{

    [SerializeField]
    AudioClip[] clip;

    public AudioSource SE;

    public enum SE_Type
    {
        //[0]
        SE,

        //[1]
        SE1,

        //[2]
        SE2,

        //[3]
        SE3,

        //[4]
        SE4,

        //[5]
        SE5

    }
    void Awake()
    {
        SE = GameObject.Find("SE").GetComponent<AudioSource>();
    }

    public void SE_Play(int Se_No)
    {
        SE.PlayOneShot(clip[Se_No]);
    }
}