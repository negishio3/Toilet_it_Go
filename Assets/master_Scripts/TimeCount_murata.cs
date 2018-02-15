﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCount_murata : SceneFader_sanoki
{
    //表示する数字小数まで
    [SerializeField]
    Image[] images = new Image[4];

    //0～9までの数字
    [SerializeField]
    Sprite[] numberSprites = new Sprite[10];

    //時間をカウント
    public float timeCount { get; private set; }

    //カウント値（60秒）
    public int tim_count = 60;

    //ゲームオーバー
    public GameObject GameOber;

    void Start()
    {
        GameOber.SetActive(false);
        //カウントダウン値
        SetTime(tim_count);
    }


    void Update()
    {

    }
    public void SetTime(float time)
    {
        //コルーチンでカウントダウン
        timeCount = time;
        StartCoroutine(TimerStart());
    }

    //時間を画像の数字で表示
    void SetNumbers(int sec, int val1, int val2)
    {
        string str = string.Format("{0:00}", sec);
        images[val1].sprite = numberSprites[Convert.ToInt32(str.Substring(0, 1))];
        images[val2].sprite = numberSprites[Convert.ToInt32(str.Substring(1, 1))];
    }

    //コルーチン分秒
    IEnumerator TimerStart()
    {
        while (timeCount >= 0)
        {
            int sec = Mathf.FloorToInt(timeCount % 60);
            SetNumbers(sec, 2, 3);
            int minu = Mathf.FloorToInt((timeCount - sec) / 60);
            SetNumbers(minu, 0, 1);
            yield return new WaitForSeconds(1.0f);
            timeCount -= 1.0f;
        }
        GameOber.SetActive(true);
    }
}