using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Test_murata : MonoBehaviour
{

    public Animator animator;
    public float speed;

    private Vector3 touchStartPos; // タッチ開始座標
    private Vector3 touchEndPos; // タッチ終了座標

    Rigidbody2D rigidbody2D;

    public float longPressIntevalSeconds = 1.0f;//長押しの1秒の間で判断
    public float pressingSeconds = 0.0f;//押されている時間

    //private bool isEnabledLongPress = true;//長押し
    //private bool isPressing = false;//タップ

    public float GageCount = 0;//ゲージ

    public float Dame = 10;

    void Start()
    {
            animator = GetComponent<Animator>();
            animator.speed = speed;

            rigidbody2D = GetComponent<Rigidbody2D>();
    }

 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.SetBool("walk", true);
            dameje();
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            animator.SetBool("walk", false);
            pressingSeconds = 0.0f;
        }
        Flick();
        longtoch();
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
        //    x の差分
        float directionX = touchEndPos.x - touchStartPos.x;
        //    y の差分
        float directionY = touchEndPos.y - touchStartPos.y;
        string Direction = "touch";

        if (Input.touchCount <= 1)
        {
           // isPressing = true;
            if (Mathf.Abs(directionY) < Mathf.Abs(directionX))
            {
                if (60 < directionX)
                {
                    //右向きにフリック
                    Direction = "right";
                }
            }
            else if (Mathf.Abs(directionX) < Mathf.Abs(directionY))
            {
                if (60 < directionY)
                {
                    //上向きにフリック
                    Direction = "up";
                }
            }
        }
        else if(pressingSeconds<=longPressIntevalSeconds)
        {
            Direction = "touch";
        }
        

        switch (Direction)
        {
            case "right":
                GageCount ++;
                Debug.Log("右フリック");//右フリックされた時の処理
                break;

            case "up":
                Debug.Log("上フリック");//上フリックされた時の処理
                animator.SetTrigger("wait");
                GageCount++;
                rigidbody2D.simulated = false;
                break;

            case "touch":
                Debug.Log("タッチ");//タッチした時の処理
                rigidbody2D.simulated = true;
                break;
        }
    }

    //長押し
    void longtoch()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            pressingSeconds += Time.deltaTime;
            if (pressingSeconds >= longPressIntevalSeconds)
            {
                pressingSeconds = longPressIntevalSeconds;
                Debug.Log("長押し");
                GageCount -=0.1f;
                Debug.Log("-"+GageCount);
                animator.SetBool("walk", false);
                animator.SetBool("unko_s", true);
                //ゲージ
                if (GageCount <= 0)
                {
                    GageCount = 0f;
                    Debug.Log("復活");
                }
            }
        }
    }

    //ダメージ
    void dameje()
    {
        GageCount++;
        Debug.Log(GageCount);
        if (GageCount<=50)
        {
            Debug.Log("通常");
        }
        if (GageCount>=70)
        {
            Debug.Log("かなり");
        }
        if (GageCount>=80)
        {
            Debug.Log("激痛");
        }

        if (GageCount>=100)
        {
            GageCount = 100;
            Debug.Log("限界");
        }
    }

    //衝突した時
    public void OnTriggerEnter2D(Collider2D collision)
    {
        GageCount += Dame;
        Debug.Log("ダメージ");
        Debug.Log(GageCount);
    }
}