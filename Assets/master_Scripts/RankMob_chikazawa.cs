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

    // Use this for initialization
    void Start () {
        num = Random.Range(0, 4);
        Dummy = RankNum[num];
        Col = GetComponent<Image>();
        scl = GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {
        Col.material.color += new Color(0, 0, 0, FadeSpd * Time.deltaTime);
        scl.sizeDelta += new Vector2(SclUpSpd * Time.deltaTime, SclUpSpd * Time.deltaTime);

        if (Col.material.color.a >= 1.0f)
        {
            Destroy(this.gameObject);
        }
	}
}
