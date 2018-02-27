﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchAnimationController_mase : MonoBehaviour
{

    public Animator animator;
    public float speed;

    private Vector3 touchStartPos; // タッチ開始座標
    private Vector3 touchEndPos; // タッチ終了座標

    bool walkanim;

    Rigidbody2D rigidbody2D;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.speed = speed;

        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.SetBool("walk", true);
            //animator.SetTrigger("walk 0");
            //Debug.Log("うごくちゃんだうー");
        }
        //else if (Input.GetMouseButtonUp(0) || Input.touchCount < 0)
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            animator.SetBool("walk", false);
            //animator.SetBool("stand",true);
            //Debug.Log("とまるちゃんだお");
        }
        Flick();
    }
    void Flick()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            touchStartPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            touchEndPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
            GetDirection();
        }
    }
    void GetDirection()
    {
        float directionX = touchEndPos.x - touchStartPos.x;
        float directionY = touchEndPos.y - touchStartPos.y;
        string Direction = "touch";

        if (Mathf.Abs(directionY) < Mathf.Abs(directionX))
        {
            if (30 < directionX)
            {
                //右向きにフリック
                Direction = "right";
            }
            else if (-30 > directionX)
            {
                //左向きにフリック
                Direction = "left";
            }
        }
        else if (Mathf.Abs(directionX) < Mathf.Abs(directionY))
        {
            if (30 < directionY)
            {
                //上向きにフリック
                Direction = "up";
            }
            //else if (-30 > directionY)
            //{
            //    //下向きのフリック
            //    Direction = "down";
            //}
        }
        else
        {
            Direction = "touch";
        }

        switch (Direction)
        {
            case "right":
                Debug.Log("右フリック");//右フリックされた時の処理
                break;

            case "left":
                Debug.Log("左フリック");//左フリックされた時の処理
                break;

            case "up":
                Debug.Log("上フリック");//上フリックされた時の処理
                animator.SetTrigger("wait");
                rigidbody2D.simulated = false;
                break;

            //case "down":
            //    Debug.Log("下フリック");//下フリックされた時の処理
            //    break;

            case "touch":
                Debug.Log("タッチ");//タッチした時の処理
                animator.SetBool("walk", true);
                walkanim = true;
                if(walkanim == true)
                {
                    animator.SetBool("walk", false);
                }
                break;
        }
    }
}