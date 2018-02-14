using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreNoRank_nishiwaki : MonoBehaviour {

    /*
    ScriptはCanvasに入れる

    評価（仮）
    10点以上　S
    8点以上　A
    5点以上　B
    以下　C
    */

    // 変更したいスコアテキストを入れる
    public Text ScoreTime;

    // こなしたギミックの数
    public int gimmick;

    // かかった時間
    public float limitTime;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // スコアポイントを評価に変える
    public void Hyouka(int score)
    {
        if (score < 0)
        {
            Debug.Log("これはエラーよ！！おかしいわ！！");
        }
        else if (score < 5)
        {
            Debug.Log("C");
        }
        else if (score < 8)
        {
            Debug.Log("B");
        }
        else if (score < 10)
        {
            Debug.Log("A");
        }
        else
        {
            Debug.Log("S");
        }
    }

    public void scorePoint()
    {

    }
}
