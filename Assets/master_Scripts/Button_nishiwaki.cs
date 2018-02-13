using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_nishiwaki : MonoBehaviour {

    //　動きを止めたいオブジェクトを入れる
    public MoveStop_nishiwaki moveStop;

    //　ボタンを押しているかどうかのフラグ
    bool moveNow = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void morasu()
    {
        Debug.Log("でる");

        /*
        if (moveStop.Move_p < 0)
            moveStop.Move_p = 0;

        else
            moveStop.Move_p = -3;
        */
    }

    // ボタンを押しているときの処理
    public void buttonDown()
    {
        moveNow = true;
    }

    // ボタンを押していないときの処理
    public void buttonUp()
    {
        moveNow = false;
    }

    public bool moveNow_b
    {
        get { return this.moveNow; }
        private set { this.moveNow = value; }
    }
}
