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
    //public int[] score_i;

    // スコアの評価を入れる
    //public string one_str;  // 1位用
    //public string two_str;  // 2位用
    //public string three_str;  // 3位用

    // スコアの画像
    //[SerializeField]
    //Sprite[] hyoukaSprites = new Sprite[4];

    float newScoretime_f = 0.0f;
    string newScore_str;

    // TimeCount_murataスクリプトからgetする
    public TimeCount_murata timeCount;

    // スプライトを張りたいオブジェクト
    //public GameObject testImage;

    // 最終的なランクをRankSceneに渡す
    public static string rank;

    // Use this for initialization
    void Start () {
        rank = "C";
	}
	
	// Update is called once per frame
	void Update () {
        newScoretime_f = timeCount.timeCount;

        // スコアの算出
        Hyouka(newScoretime_f);

        // 評価のイメージを表示
        //HyoukaImage(newScore_str);

        // スコアの並び替え
        //scoresort();

        //// 変更されたスコアを更新する
        //Score1.text = "1位　：　" + one_i;
        //Score2.text = "2位　：　" + two_i;
        //Score3.text = "3位　：　" + three_i;
    }

    // タイムに応じてスコアをだす
    public void Hyouka(float score)
    {
        if (score < 0)
        {
            //Debug.Log("これはエラーよ！！おかしいわ！！");
        }
        else if (score < 70)
        {
           // Debug.Log("S");
            newScore_str = "S";
            rank = "S";
        }
        else if (score < 60)
        {
           // Debug.Log("A");
            newScore_str = "A";
            rank = "A";
        }
        else if (score < 50)
        {
            //Debug.Log("B");
            newScore_str = "B";
            rank = "B";
        }
        else
        {
            //Debug.Log("C");
            newScore_str = "C";
            rank = "C";
        }
    }

    /*
    // スコアに応じた評価の画像を出す
    public void HyoukaImage(string Image)
    {
        switch (Image)
        {
            case "S":
                Debug.Log("Sです");
                //this.testImage.GetComponent<Image>().sprite = hyoukaSprites[0];
                rank = "S";
                break;
            case "A":
                Debug.Log("Aです");
                //this.testImage.GetComponent<Image>().sprite = hyoukaSprites[1];
                rank = "A";
                break;
            case "B":
                Debug.Log("Bです");
                //this.testImage.GetComponent<Image>().sprite = hyoukaSprites[2];
                rank = "B";
                break;
            case "C":
                Debug.Log("Cです");
                //this.testImage.GetComponent<Image>().sprite = hyoukaSprites[3];
                rank = "C";
                break;
        }
    }
    */

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
