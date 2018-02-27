using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomImage : MonoBehaviour {
    //速さ
    public float AxelMin;
    public float AxelMax;
    //位置
    public float PosMin;
    public float PosMax;
    //角度
    public float RotMin;
    public float RotMax;

    RankCall_nishiwaki Rswitch;
    public int barets;

    public GameObject shotpoint;
    public GameObject shot;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Rswitch.RandomSwitch)
        {
            for (int i = 0; i < barets; i++)
            {
                shotpoint.transform.localPosition = new Vector2(Random.Range(PosMin, PosMax), 0);
                Instantiate(shot, shotpoint.transform);
            }
        }
	}
}
