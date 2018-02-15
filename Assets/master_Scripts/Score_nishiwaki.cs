using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_nishiwaki : MonoBehaviour {

    /*
    ScriptはCanvasに入れる

    評価（仮）
    10点以上　S
    8点以上　A
    5点以上　B
    以下　C
    */

    // 変更したいスコアを入れる
    //public Text Score1;
    //public Text Score2;
    //public Text Score3;

    // スコアを入れる　評価の基準点
    //public int one_i;
    //public int two_i;
    //public int three_i;
    public int[] score_i;

    // スコアの評価を入れる
    //public string one_str;  // 1位用
    //public string two_str;  // 2位用
    //public string three_str;  // 3位用

    public float newScoretime_f;
    string newScore_str;

    TimeCount_murata timeCount;

    // Use this for initialization
    void Start () {



	}
	
	// Update is called once per frame
	void Update () {
        newScoretime_f = timeCount.timeCount_gs;

        // スコアの算出
        Hyouka((int)timeCount.timeCount);

        // スコアの並び替え
        //scoresort();

        //// 変更されたスコアを更新する
        //Score1.text = "1位　：　" + one_i;
        //Score2.text = "2位　：　" + two_i;
        //Score3.text = "3位　：　" + three_i;
    }

    public void Hyouka(int score)
    {
        if (score < 0)
        {
            Debug.Log("これはエラーよ！！おかしいわ！！");
        }
        else if (score < 20)
        {
            Debug.Log("C");
        }
        else if (score < 30)
        {
            Debug.Log("B");
        }
        else if (score < 40)
        {
            Debug.Log("A");
        }
        else
        {
            Debug.Log("S");
        }
    }

    //public void scoresort()
    //{
    //    int x;
    //    for (int i=0;i<score_i.Length;i++)
    //    {
    //        if(newScore_i > score_i[i])
    //        {
    //            x = score_i[i];
    //            score_i[i] = newScore_i;
    //            newScore_i = x;
    //            Debug.Log("ソート");
    //        }
    //    }
    //}
}
