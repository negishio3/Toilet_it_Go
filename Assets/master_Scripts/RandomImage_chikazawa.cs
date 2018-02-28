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

    RankCall_nishiwaki Rswitch;
    bool s=true;
    public int barets;

    public GameObject setPoint;
    public GameObject MOB;
    //    RankMob_chikazawa RMob;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {

        if (/*Rswitch.RandomSwitch*/s)
        {
            for (int i = 0; i < barets; i++)
            {
                transform.localPosition = new Vector2(Random.Range(PosMin, PosMax), 0);
                //transform.rotation = Rot_z;
                Instantiate(
                    MOB,               //出すオブジェクト
                    transform.position,//座標指定
                    Quaternion.identity,//回転
                    setPoint.transform);//親にするオブジェクト
                getDummy();
            }
            s = false;
        }
    }
    public IEnumerator getDummy()
    {
        yield return new WaitForSeconds(0.5f);//1秒止める

    }

}
