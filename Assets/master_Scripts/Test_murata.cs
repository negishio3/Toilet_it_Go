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

    public Yankee_nishiwaki yankee;

    public float longPressIntevalSeconds = 1.0f;//長押しの1秒の間で判断
    public float pressingSeconds = 0.0f;//押されている時間

    public float GageCount = 0;//ゲージ

    public float Dame = 10;//ダメージ

    void Start()
    {
        trainMove_s = FindObjectOfType<TrainMove_sanoki>();
        animator = GetComponent<Animator>();
        animator.speed = speed;
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

 
    void Update()
    {
        so();//操作
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

    //アクションイベント（つり革、殴り）
    void GetDirection()
    {
        if (Event == true)//フリックしてもいいか？
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
                    if (GageCount>=99)
                    {
                        GageCount = 99;

                    }
                    trainMove_s.Pause();
                    animator.SetTrigger("unchp");
                    Yankee_nishiwaki.Hit = true;
                    break;

                case "up":
                    GageCount++;
                    if (GageCount >= 99)
                    {
                        GageCount = 99;
                    }
                    trainMove_s.Pause();
                    animator.SetTrigger("wait");
                    rigidbody2D.simulated = false;
                    break;

                case "touch":
                    rigidbody2D.simulated = true;
                    break;
            }
        }
    }

    //衝突した時
    public void OnTriggerEnter2D(Collider2D collision)
    {
        GageCount += Dame;//ゲージに10加算
    }

    //ゲージと操作関連
    public void so()
    {
        //普通に歩く
        if (GageCount < 50)
        {
            animator.SetBool("unko_l", false);
            animator.SetBool("unko_m",false);
            animator.SetBool("unko_s", false);
            Flick();

            //押す
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                trainMove_s.Action();
                GageCount++;
                animator.SetBool("unko_s",false);
                animator.SetBool("walk", true);
                animator.SetBool("stand", true);
            }

            //放す
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                trainMove_s.Action();
                animator.SetBool("walk", false);
                animator.SetBool("stand",false);
                pressingSeconds = 0.0f;
            }

            //長押し
            if (Input.GetKey(KeyCode.Mouse0))
            {
                pressingSeconds += Time.deltaTime;
                if (pressingSeconds >= longPressIntevalSeconds)
                {
                    trainMove_s.Pause();
                    pressingSeconds = longPressIntevalSeconds;
                    GageCount -= 0.1f;
                    if (GageCount <= 0)
                    {
                        GageCount = 0.0f;
                    }
                }
            }
        }

        //小
        if (GageCount>=50)
        {
            animator.SetBool("unko_l", false);
            Flick();

            //押す
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                trainMove_s.Action();
                GageCount++;
                animator.SetBool("unko_s", true);
                animator.SetBool("walk", false);
                animator.SetBool("stand", false);
                animator.SetBool("unko_m", false);
            }

            //放す
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                trainMove_s.Action();
                animator.SetBool("unko_s", false);
                pressingSeconds = 0.0f;
            }

            //長押し
            if (Input.GetKey(KeyCode.Mouse0))
            {
                pressingSeconds += Time.deltaTime;
                if (pressingSeconds>=longPressIntevalSeconds)
                {
                    trainMove_s.Pause();
                    pressingSeconds = longPressIntevalSeconds;
                    GageCount -= 0.1f;
                    if (GageCount < 50)
                    {
                        animator.SetBool("stand", true);
                        animator.SetBool("unko_s", false);
                    }
                    if (GageCount <= 0)
                    {
                        GageCount = 0.0f;
                    }
                }
            }
        }

        //中
        if (GageCount >= 80)
        {
            animator.SetBool("unko_l", false);
            Flick();

            //押す
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                trainMove_s.Action();
                GageCount++;
                animator.SetBool("unko_m", true);
                animator.SetBool("unko_s", false);
            }

            //放す
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                trainMove_s.Action();
                animator.SetBool("unko_m", false);
                pressingSeconds = 0.0f;
            }

            //長押し
            if (Input.GetKey(KeyCode.Mouse0))
            {
                pressingSeconds += Time.deltaTime;
                if (pressingSeconds >= longPressIntevalSeconds)
                {
                    trainMove_s.Pause();
                    pressingSeconds = longPressIntevalSeconds;
                    GageCount -= 0.1f;
                    if (GageCount < 80)
                    {
                        animator.SetBool("unko_s", true);
                        animator.SetBool("unko_m", false);
                    }
                    if (GageCount <= 0)
                    {
                        GageCount = 0.0f;
                    }
                }
            }
        }

        //第3形態（動けない）
        //ゲージが100で動けない
        if (GageCount>=100)
        {
            GageCount = 100f;//ゲージを100以上あげさせない
            trainMove_s.Pause();//背景が止まる
            Event = false;//つり革、殴るができない

            //押す
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                animator.SetBool("unko_l", true);//キャラクターモーション第3形態へ
                animator.SetBool("unko_m", false);//第2形態は終了
            }

            //放す
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                pressingSeconds = 0.0f;//長押しの値リセット
            }

            //長押し
            if (Input.GetKey(KeyCode.Mouse0))
            {
                pressingSeconds += Time.deltaTime;//長押しの時判定
                if (pressingSeconds >= longPressIntevalSeconds)
                {
                    pressingSeconds = longPressIntevalSeconds;//同じの間の処理
                    GageCount -= 0.1f;//ゲージ減少

                    //第2形態までの長押し
                    if (GageCount < 90&&GageCount>=80)
                    {
                        animator.SetBool("unko_m", true);
                        animator.SetBool("unko_l", false);
                        pressingSeconds = 0.0f;
                    }

                    //第1形態までの長押し
                    if (GageCount < 80&&GageCount>=50)
                    {
                        animator.SetBool("unko_s", true);
                        animator.SetBool("unko_m", false);
                        pressingSeconds = 0.0f;
                    }

                    //普通までの長押し
                    if (GageCount < 50&&GageCount>=0)
                    {
                        animator.SetBool("stand", true);
                        animator.SetBool("walk", true);
                        animator.SetBool("unko_s", false);
                        pressingSeconds = 0.0f;
                    }

                    //ゲージ減少0以下にしない
                    if (GageCount <= 0)
                    {
                        GageCount = 0.0f;
                        pressingSeconds = 0.0f;
                    }
                }
            }
        }

        //背景が動く
        if (GageCount<=90)
        {
            Event = true;//スワイプをON
            animator.SetBool("unko_l", false);//第3形態戻す
        }
    }
}