﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Count_chika : MonoBehaviour {

    //public Image countImg;      //カウントするImageオブジェクト
    //public Sprite[] imageList;  //切り替え用のスプライト

    public int count;             //選択中のImage

    ///////////////////////////////////////////////////////////////////////

    public TrainMove_sanoki Train_game;
    public Image start;


	// Use this for initialization
	void Start () {

        //count = 0;
        //countImg.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        
    }
    public void OnClickButtonStart()
    {
        //ボタンを押してスタート
        StartCoroutine(CountDown());
    }
    //カウントダウン
    public IEnumerator CountDown()
    {
        ////オブジェクトをアクティブにしてカウントスタート
        //countImg.gameObject.SetActive(true);
        //for (count = 0; count < 5 ; count++)//何回変えるか
        //{
        //    countImg.sprite = imageList[count];//画像切替
        yield return new WaitForSeconds(1.0f);//1秒止める

        //}//終わったら非アクティブにする
        //countImg.gameObject.SetActive(false);

    }
}