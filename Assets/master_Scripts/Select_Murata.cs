using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Select_Murata : MonoBehaviour
{

    TutorialSlide_Murata ts;//スライドスクリプトの読み込み
    SceneFader_sanoki sf;//フェードスクリプトの読み込み
    public Image[] ButtonImage;//ボタンのイメージを保存する
    int buttonNum;//選択中のボタンが何番目なのか保存する
    int oldButtonNum;//ひとつ前に選択していたボタンを保存する

    public string thisSceneName;



    void Start()
    {
        ts = FindObjectOfType<TutorialSlide_Murata>();//スライドプログラムのメソッドを読み込む
        sf = FindObjectOfType<SceneFader_sanoki>();//フェードプログラムのメソッドを読み込む
    }

    void Update()
    {
        
        
    }
    /// <summary>
    /// 選択中のボタンを変更する
    /// </summary>
    void ButtonSelector()
    {
        switch (thisSceneName)
        {
            case "Select_Murata":
                switch (buttonNum)
                {
                    case 0:
                        ts.Slide(true);
                        break;
                    case 1:
                        ts.Slide(false);
                        break;
                }
                break;
        }

    }
}