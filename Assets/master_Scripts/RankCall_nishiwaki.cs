using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankCall_nishiwaki : MonoBehaviour
{
    // スコアの画像
    [SerializeField]
    Sprite[] hyoukaSprites = new Sprite[4];

    // スプライトを張りたいオブジェクト
    public GameObject testImage;

    //スケール拡大用
    public GameObject TriggerImg;   //トリガーにするドア
    public float TriggerPos;        //トリガーの場所

    public static bool ScaleUPFlg = false;//拡大のフラグ
    public bool RandomSwitch = false; // ランダム出現から移動
    bool sizeStop = false;          // 停止ポイント


    public float sclSP;             //拡大速度
    Vector2 MaxScale;               //最大値、実行前のスケールに依存させる

    RectTransform ScaleChange;      //大きくなるImage

    // Use this for initialization
    void Start()
    {
        //仮ランク
      //  Score_nishiwaki.rank = "C";
        //コンポーネントの取得とMaxScaleの保存
        ScaleChange = GetComponent<RectTransform>();
        MaxScale = ScaleChange.sizeDelta;
        Debug.Log("Max" + MaxScale);

        //ランクの取得
        HyoukaImage(Score_nishiwaki.rank);
    }

    // Update is called once per frame
    void Update()
    {
        //ランクの取得
        //HyoukaImage(Score_nishiwaki.rank);

        //フラグが立つ前にスケールを0にする
        if (ScaleUPFlg == false)
        {
            ScaleChange.sizeDelta = new Vector2(0.0f, 0.0f);
            Debug.Log("Start" + ScaleChange.sizeDelta + "  Max" + MaxScale);
        }//トリガーが指定の位置を過ぎたら拡大開始
        if (TriggerImg.transform.localPosition.x >= TriggerPos)
        {
            //Debug.Log(TriggerImg.transform.position);
            RandomSwitch = true;
        }
        //元の大きさに戻ったら抜ける
        if (ScaleUPFlg == true && sizeStop==false)
        {   //拡大処理
            if (MaxScale.x >= ScaleChange.sizeDelta.x)
            {
                //Debug.Log("正常");
                ScaleChange.sizeDelta += new Vector2(sclSP + Time.deltaTime, sclSP + Time.deltaTime);
            }//拡大終了
            else if (ScaleChange.sizeDelta.x >= MaxScale.x)
            {
                //Debug.Log("サイズおなじー");

                ScaleChange.sizeDelta = MaxScale;
                sizeStop = true;
            }
        }
    }

    // スコアに応じた評価の画像を出す
    public void HyoukaImage(string RankImage)
    {
        switch (RankImage)
        {
            case "S":
                Debug.Log("Sです");
                this.testImage.GetComponent<Image>().sprite = hyoukaSprites[0];
                break;
            case "A":
                Debug.Log("Aです");
                this.testImage.GetComponent<Image>().sprite = hyoukaSprites[1];
                break;
            case "B":
                Debug.Log("Bです");
                this.testImage.GetComponent<Image>().sprite = hyoukaSprites[2];
                break;
            case "C":
                Debug.Log("Cです");
                this.testImage.GetComponent<Image>().sprite = hyoukaSprites[3];
                break;
        }
    }
}