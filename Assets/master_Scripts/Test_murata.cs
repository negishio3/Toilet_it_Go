using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_murata : MonoBehaviour
{
    TrainMove_sanoki trainMove_s;//佐野木スクリプト背景移動

    public Animator animator;//キャラクターアニメーション
    public float speed;//アニメーションスピード

    private Vector3 touchStartPos; // タッチ開始座標
    private Vector3 touchEndPos; // タッチ終了座標

    private bool Event = true;//キャラクターイベント処理

    Rigidbody2D rigidbody2D;

    public float longPressIntevalSeconds = 1.0f;//長押しの1秒の間で判断
    public float pressingSeconds = 0.0f;//押されている時間

    public float GageCount = 0;//ゲージ

    public float Dame = 10;

    void Start()
    {
        trainMove_s = FindObjectOfType<TrainMove_sanoki>();
        animator = GetComponent<Animator>();
        animator.speed = speed;

        rigidbody2D = GetComponent<Rigidbody2D>();
    }

 
    void Update()
    {
        ////基盤
        //if (Input.GetKeyDown(KeyCode.Mouse0))
        //{
        //    animator.SetBool("walk", true);
        //    dameje();
        //}
        //if (Input.GetKeyUp(KeyCode.Mouse0))
        //{
        //    animator.SetBool("walk", false);
        //    pressingSeconds = 0.0f;
        //}

        so();
        //フリック
       // Flick();
        //長押し
        longtoch();
    }

    //フリック
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

    //アクションイベント
    void GetDirection()
    {
        if (Event == true)
        {
            //    x の差分
            float directionX = touchEndPos.x - touchStartPos.x;
            //    y の差分
            float directionY = touchEndPos.y - touchStartPos.y;
            string Direction = "touch";

            if (Input.touchCount <= 1)
            {
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
            else if (pressingSeconds <= longPressIntevalSeconds)
            {
                Direction = "touch";
            }


            switch (Direction)
            {
                case "right":
                    GageCount++;
                    Debug.Log("右フリック");//右フリックされた時の処理
                    animator.SetTrigger("unchp");
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
            trainMove_s.Pause();
            GageCount = 100;
            Debug.Log("限界");
            animator.SetBool("unko_l", true);
        }
        if (GageCount<=90)
        {
            Debug.Log("背景動く");
            trainMove_s.Action();
        }
    }

    //衝突した時
    public void OnTriggerEnter2D(Collider2D collision)
    {
        GageCount += Dame;
        Debug.Log("ダメージ");
        Debug.Log(GageCount);
    }

    //操作一覧アニメ―ション
    public void sousa()
    {

        //長い
        animator.SetBool("unko_l", true);
        animator.SetBool("unko_l",false);

        //中
        animator.SetBool("unko_m", true);
        animator.SetBool("unko_m", false);

        //小
        animator.SetBool("unko_s", true);
        animator.SetBool("unko_s", false);

        //普通
        animator.SetBool("wait", true);
        animator.SetBool("wait", false);

        //スタート
        animator.SetBool("stand", true);
        animator.SetBool("stand", false);

        //殴る
        animator.SetTrigger("unchp");

        //つり革
        animator.SetTrigger("wait");
    }

    public void so()
    {
        //普通に歩く
        if (GageCount < 50)
        {
            animator.SetBool("unko_l", false);
            animator.SetBool("unko_m",false);
            animator.SetBool("unko_s", false);
            Flick();
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                GageCount++;
                animator.SetBool("unko_s",false);
                animator.SetBool("walk", true);
                animator.SetBool("stand", true);
            }
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                animator.SetBool("walk", false);
                animator.SetBool("stand",false);
                pressingSeconds = 0.0f;
            }
        }
        //小
        if (GageCount>50)
        {
            animator.SetBool("unko_l", false);
            Flick();
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                GageCount++;
                animator.SetBool("unko_s", true);
                animator.SetBool("walk", false);
                animator.SetBool("stand", false);
                animator.SetBool("unko_m", false);
            }
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                animator.SetBool("unko_s", false);
                pressingSeconds = 0.0f;
            }
        }

        //中
        if (GageCount > 80)
        {
            animator.SetBool("unko_l", false);
            Flick();
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                GageCount++;
                animator.SetBool("unko_m", true);
                animator.SetBool("unko_s", false);
            }
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                animator.SetBool("unko_m", false);
                pressingSeconds = 0.0f;
            }
        }

        //長い
        if (GageCount>=100)
        {
            GageCount = 100f;
            trainMove_s.Pause();
            Event = false;
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                animator.SetBool("unko_l", true);
                animator.SetBool("unko_m", false);
            }
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                pressingSeconds = 0.0f;
            }
        }

        //背景が動く
        if (GageCount<=90)
        {
            Event = true;//スワイプをON
            trainMove_s.Action();
           // animator.SetBool("unko_m", true);
            animator.SetBool("unko_l", false);
        }
        //if (GageCount<=80)
        //{
        //    animator.SetBool("unko_s", true);
        //    animator.SetBool("unko_m",false);
        //}
        //if (GageCount <= 50)
        //{
        //    animator.SetBool("stand", true);
        //    animator.SetBool("unko_s", false);
        //}
    }
}