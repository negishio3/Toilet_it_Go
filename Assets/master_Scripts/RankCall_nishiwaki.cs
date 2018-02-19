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

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HyoukaImage(Score_nishiwaki.rank);
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