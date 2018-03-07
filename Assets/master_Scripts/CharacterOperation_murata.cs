using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterOperation_murata : MonoBehaviour {

    TrainMove_sanoki trainMove_s;//佐野木スクリプト背景移動

    public Animator animator;//キャラクターアニメーション
    public float speed=0.3f;//アニメーションスピード

    private Vector3 touchStartPos;//タッチ開始座標
    private Vector3 touchEndPos;//タッチ終了座標

    private bool Event = true;//キャラクターアクション処理

    Rigidbody2D pl_rigidbody2D;//キャラクター当たり判定

    public float longPressIntevalSeconds = 1.0f;//長押しの1秒の間で判断
    public float pressingSeconds = 0.0f;//押されている時間

    public float GageCount = 0;//ゲージ

    public float GageDame = 2;//回復

    public float Dame = 10;//ダメージ当たったら
    string Anis = "";


    public GameObject Kenatu;

    void Start ()
    {
        trainMove_s = FindObjectOfType<TrainMove_sanoki>();
        animator = GetComponent<Animator>();
        animator.speed = speed;
        pl_rigidbody2D = GetComponent<Rigidbody2D>();
    }
	
	
	void Update ()
    {
        GetController();//操作
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
            touchEndPos= new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
            GatDirection();
        }
    }

    //フリック内処理
    void GatDirection()
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
                    if (GageCount >= 99)
                    {
                        GageCount = 99;
                    }
                    trainMove_s.Pause();
                    animator.SetTrigger("unchp");//殴るアニメーション
                    Yankee_nishiwaki.Hit = true;
                    Instantiate(Kenatu);
                    break;

                case "up":
                    GageCount++;
                    if (GageCount >= 99)
                    {
                        GageCount = 99;
                    }
                    trainMove_s.Pause();
                    animator.SetTrigger("wait");//つり革アニメーション
                    pl_rigidbody2D.simulated = false;
                    break;

                case "touch":
                    pl_rigidbody2D.simulated = true;
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
    public void GetController()
    {
        Flick();//フリック
        //タップダウン
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //trainMove_s.Action();//背景動く
            GageCount++;//ゲージに１加算
            
            if (GageCount<50)
            {
                Anis = "Normal_dw";//通常運転
            }
            if(GageCount>=50)
            {
                Anis = "Mode1_dw";//第1段階
            }
            if (GageCount>=80)
            {
                Anis = "Mode2_dw";//第2段階
            }
            if (GageCount>=100)
            {
                trainMove_s.Pause();
                Anis = "Mode3_dw";//第3段階
            }
        }
        //タップアップ
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            //trainMove_s.Action();//背景動く
            pressingSeconds = 0.0f;//長押しの時間をリセット
            if (GageCount<50)
            {
                Anis = "Normal_up";//通常運転
            }
            if (GageCount>=50)
            {
                Anis = "Mode1_up";//第1段階
            }
            if (GageCount>=80)
            {
                Anis = "Mode2_up";//第2段階
            }
            if (GageCount>=100)
            {
                trainMove_s.Pause();
                Anis = "Mode3_up";//第3段階
            }
        }
        //長押し（ロングタップ）
        if (Input.GetKey(KeyCode.Mouse0))
        {
            pressingSeconds += Time.deltaTime;//押している時間
            if (pressingSeconds>=longPressIntevalSeconds)//一定以上超えた
            {
                trainMove_s.Pause();//背景の移動停止
                pressingSeconds = longPressIntevalSeconds;//値を同じへ
                GageCount -= GageDame;//ゲージに1減算
                if (GageCount < 50)
                {
                    Anis = "Normal";//通常運転
                }
                if (GageCount>=50)
                {
                    Anis = "Mode1";//第1段階 
                }
                if (GageCount>=80)
                {
                    Anis = "Mode2";//第2段階
                }
                if (GageCount>=100)
                {
                    Anis = "Mode3";//第3段階
                }
            }
        }
        //第2段階へ
        if (GageCount <= 90)
        {
           // trainMove_s.Action();
            Event = true;//フリック可能
            animator.SetBool("unko_l", false);//3段階を戻す
        }
        switch (Anis)
        {
            case "Normal_dw"://通常アニメーション
                animator.SetBool("walk", true);
                animator.SetBool("stand", true);
                animator.SetBool("unko_l", false);
                animator.SetBool("unko_m", false);
                animator.SetBool("unko_s", false);
                break;
            case "Mode1_dw"://第1段階アニメーション
                animator.SetBool("unko_s", true);
                animator.SetBool("walk", false);
                animator.SetBool("stand", false);
                animator.SetBool("unko_m", false);
                break;
            case "Mode2_dw"://第2段階アニメーション
                animator.SetBool("unko_m", true);
                animator.SetBool("unko_s", false);
                break;
            case "Mode3_dw"://第3段階アニメーション
                GageCount = 100f;
                trainMove_s.Pause();
                Event = false;
                animator.SetBool("unko_l", true);
                animator.SetBool("unko_m", false);
                break;

            case "Normal_up"://通常運転アニメモーション
                animator.SetBool("walk", false);
                animator.SetBool("stand", false);
                animator.SetBool("unko_s", false);
                break;
            case "Mode1_up"://第1段階アニメーション
                animator.SetBool("unko_s", false);
                animator.SetBool("unko_l", false);
                animator.SetBool("unko_m", false);
                break;
            case "Mode2_up"://第2段階アニメーション
                animator.SetBool("unko_m", false);
                break;
            case "Mode3_up"://第3段階アニメーション
                animator.SetBool("unko_l", true);
                break;

            case "Normal"://通常運転長押し処理
                if (GageCount <= 0)
                {
                    GageCount = 0.0f;
                }
                if(GageCount>0)
                {
                    animator.SetBool("stand", true);
                    animator.SetBool("unko_s", false);
                }
                break;
            case "Mode1"://第1段階長押し処理
                if (GageCount <= 0)
                {
                    GageCount = 0.0f;
                }
                if (GageCount>=50)
                {
                    animator.SetBool("unko_s", true);
                    animator.SetBool("unko_m", false);
                }
                break;
            case "Mode2"://第2段階長押し処理
                if (GageCount >= 80)
                {
                    animator.SetBool("unko_m", true);
                    animator.SetBool("unko_l", false);
                }
                if (GageCount <= 0)
                {
                    GageCount = 0.0f;
                }
                break;
            case "Mode3"://第3段階長押し処理
                if (GageCount>=90)
                {
                    animator.SetBool("unko_l", true);
                    trainMove_s.Pause();
                }
                if (GageCount <= 0)
                {
                    GageCount = 0.0f;
                    pressingSeconds = 0.0f;
                }
                break;
        }
    }
}
