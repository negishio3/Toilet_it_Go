using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankMob_chikazawa : MonoBehaviour {

    
    public Sprite[] RankNum = new Sprite[4];
    int num;
    Image Col;

    public Sprite Dummy;
    RectTransform scl;
    public float FadeSpd;
    public float SclUpSpd;

    float time;
    public float fadetime;

    // Use this for initialization
    void Start () {
        num = Random.Range(0, 4);
        Dummy = RankNum[num];
        Col = GetComponent<Image>();
        scl = GetComponent<RectTransform>();
        Col.sprite = Dummy;

        time = fadetime;
    }
	
	// Update is called once per frame
	void Update () {
        //Col.color = new Color(1.0f, 1.0f, 1.0f, 255.0f - (FadeSpd * Time.deltaTime) / 255.0f);
        time -= FadeSpd * Time.deltaTime;//時間更新(徐々に減らす)
        float a = time / fadetime;//徐々に0に近づける
        var color = Col.color;//取得したimageのcolorを取得
        color.a = a;//カラーのアルファ値(透明度合)を徐々に減らす
        Col.color = color;//取得したImageに適応させる

        scl.sizeDelta += new Vector2(SclUpSpd +Time.deltaTime, SclUpSpd + Time.deltaTime);

        if (Col.color.a <= 0.0f)
        {
            Debug.Log("kieta!");
            Destroy(this.gameObject);
        }
	}
}
