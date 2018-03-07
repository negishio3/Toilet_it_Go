using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchAnimationController_mase : MonoBehaviour
{
    public bool isTitle;

    TrainMove_sanoki trainmove;
    public Animator animator;
    public float speed;

    private Vector3 touchStartPos; // タッチ開始座標
    private Vector3 touchEndPos; // タッチ終了座標

    Rigidbody2D rigidbody2D;


    Yankee_nishiwaki yankee;
    AutoPlay_sanoki auto;

    // Use this for initialization
    void Start()
    {
        auto = FindObjectOfType<AutoPlay_sanoki>();
        animator = GetComponent<Animator>();
        animator.speed = speed;

        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isTitle)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                animator.SetBool("walk", true);
            }
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                animator.SetBool("walk", false);
            }
            Flick();
        }
    }
    void Flick()
    {
        if (!trainmove.PauseFlg)
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
    }
    void GetDirection()
    {
        //    x の差分
        float directionX = touchEndPos.x - touchStartPos.x;
        //    y の差分
        float directionY = touchEndPos.y - touchStartPos.y;
        string Direction = "touch";

        //if (長押し条件 <= 1f){
        if (Input.touchCount <= 1)
        {
            if (Mathf.Abs(directionY) < Mathf.Abs(directionX))
            {
                if (60 < directionX)
                {
                    //右向きにフリック
                    Direction = "right";
                }
                //else if (-30 > directionX)
                //{
                //    //左向きにフリック
                //    Direction = "left";
                //}
            }
            else if (Mathf.Abs(directionX) < Mathf.Abs(directionY))
            {
                if (60 < directionY)
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
        }
        else
        {
            Direction = "touch";
        }
        // else{
        // 長押しの処理}
        //}

        switch (Direction)
        {
            case "right":
                Debug.Log("右フリック");//右フリックされた時の処理
                animator.SetTrigger("unchp");
                break;

            //case "left":
            //    Debug.Log("左フリック");//左フリックされた時の処理
            //    break;

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
                rigidbody2D.simulated = true;
                break;
        }
    }
    public void Wait()
    {
        animator.SetTrigger("wait");
        RigidbodyOn();
    }
    public void RigidbodyOn()
    {
        rigidbody2D.simulated = false;
    }
}