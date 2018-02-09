using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effectAcsess_chikazawa : MonoBehaviour
{
    //パーティクルを設定
    public GameObject effectset;

    // Use this for initialization
    void Start()
    {
        effectset.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag == "Player")
        {
            GoalToilet_chikazawa.PlayEnd = true;//再生フラグ
            Debug.Log("何だよ…結構あたるんじゃねぇか…");
            //アクティブにしてパーティクルを再生
            effectset.SetActive(true);
        }
    }
}
