using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalToilet_chikazawa : MonoBehaviour
{
    public static ParticleSystem particle;
    public static bool PlayEnd =false; //パーティクルを再生したかどうか

    // Use this for initialization
    void Start()
    {
        particle = this.GetComponent<ParticleSystem>();
    }
    void Update()
    {
        //ゴールに着いた時点でtrueになる
        if (PlayEnd == true)
        {
            //再生終了時
            if (particle.isPlaying == false)
            {
                //リザルトに移動
                SceneManager.LoadScene("SceneName");
            }
        }
    }
}