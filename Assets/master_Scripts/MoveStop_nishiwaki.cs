﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStop_nishiwaki : MonoBehaviour
{
    public GameObject Train;
    private int move = 3;

    public Button_nishiwaki button;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (button.moveNow_b == true)
        {
            move = 3;
        }
        else if(button.moveNow_b == false)
        {
            move = 0;
        }
        //電車の移動
        Train.transform.position += new Vector3(move, 0, 0) * Time.deltaTime;

        /*
        //タッチ操作
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began || Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Z))
            {
                // タッチ開始
                move = -1;
                Debug.Log("タッチ開始");
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                // タッチ移動
            }
            else if (touch.phase == TouchPhase.Ended || Input.GetMouseButtonUp(0))
            {
                // タッチ終了
                move = -3;
                Debug.Log("タッチ終了");
            }
        }
        */
    }
    public int Move_p
    {
        get { return this.move; }
        set { this.move = value; }
    }
}
