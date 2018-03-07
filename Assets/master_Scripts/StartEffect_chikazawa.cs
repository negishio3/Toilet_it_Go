using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartEffect_chikazawa : MonoBehaviour {

    public Image start_button;              //拡大する画像
    public Image[] Clone = new Image[2];    //左右に移動する画僧
    bool flg = false;                       //ボタンを押した時のフラグ
    float spd = 0.05f;                      //拡大速度
    float alqa = 1;                         //α値

    // Use this for initialization
    void Start () {
        start_button.GetComponent<RectTransform>();
        //最初は非表示
        Clone[0].gameObject.SetActive(false);
        Clone[1].gameObject.SetActive(false);
        start_button.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonUp(0))//押したら表示。放したら拡散
        {
            flg = true;
        }
        if (flg)
        {
            start_button.rectTransform.localScale += new Vector3(spd,spd);     //拡大
            Clone[0].rectTransform.localPosition += new Vector3(25.0f, 0.0f);  //右に
            Clone[1].rectTransform.localPosition -= new Vector3(25.0f, 0.0f);  //左に
            
            //消える    
            start_button.color = new Color(0, 0, 0, alqa);
            Clone[0].color = new Color(0, 0, 0, alqa);
            Clone[1].color = new Color(0, 0, 0, alqa);

            alqa -= spd;
        }
    }

    public void BUTTON_DOWN()//イベントトリガーで設定する
    {
        start_button.gameObject.SetActive(true);

        for (int i = 0; i < 2; i++)
        {
            Clone[i].gameObject.SetActive(true);
        }

    }
}
