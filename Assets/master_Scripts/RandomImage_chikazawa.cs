using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomImage_chikazawa : MonoBehaviour {
    //速さ
    public float AxelMin;
    public float AxelMax;
    //位置
    public float PosMin;
    public float PosMax;
    //角度
    public float RotMin;
    public float RotMax;
    float Rot_z;

    public GameObject Getswitch;
    RankCall_nishiwaki Rswitch;
    bool s=true;
    bool isRunning;
    public int barets;

    public GameObject setPoint;
    public GameObject MOB;

    //    RankMob_chikazawa RMob;
	// Use this for initialization
	void Start ()
    {
	}

    // Update is called once per frame
    void Update() {

        if (Rswitch.RandomSwitch == true)
        {
            StartCoroutine(getDummy());

        }
    }
    public IEnumerator getDummy()
    {
        if (isRunning)
            yield break;
        isRunning = true;

        for (int i = 0; i < barets; i++)
        {
            transform.localPosition = new Vector2(Random.Range(PosMin, PosMax), 0);
            //transform.rotation = Rot_z;
            Debug.Log("deta");
            Instantiate(
            MOB,               //出すオブジェクト
            transform.position,//座標指定
            Quaternion.identity,//回転
            setPoint.transform);//親にするオブジェクト

            yield return new WaitForSeconds(0.3f);//0.3秒止める

        }
        Rswitch.ScaleUPFlg = true;
        Rswitch.RandomSwitch = false;
    }

}
