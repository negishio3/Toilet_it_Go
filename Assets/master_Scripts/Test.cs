using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    public Animator animator;//キャラクター
    public float speed;

    private Vector3 touchStartPos; // タッチ開始座標
    private Vector3 touchEndPos; // タッチ終了座標

    bool walkanim;//歩くときの

    Rigidbody2D rigidbody2D;

    public float longPressIntervaISeconds = 1.0f;//長押し1秒以上で長押し
    public float pressingSeconds = 0.0f;//タプした時間
    private bool isEnabledLongPress = true;//長押し
    private bool isPressing = false;//タップ

    public int Gagecount=100;

    public int Dame=10;

    private bool anza=true;


    void Start()
    {
        animator = GetComponent<Animator>();//アニメ―ション
        animator.speed = speed;//スピード

        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            pressingSeconds += Time.deltaTime;
            if (pressingSeconds >= 5)
            {
                Gagecount+=1;
                Debug.Log("治ってく");
                if (Gagecount >= 100)
                {
                    Gagecount = 100;
                    Debug.Log("増えないよ");
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
                Gagecount --;

                if (Gagecount <= 50)
                {
                    Debug.Log("少々腹痛");
                }
                if (Gagecount <= 30)
                {
                    Debug.Log("かなり腹痛");
                }
                if (Gagecount <= 20)
                {
                    Debug.Log("激痛");
                }
                if (Gagecount <= 0)
                {
                    Gagecount += 100;
                    Debug.Log("復活");
                }

            Debug.Log(Gagecount);
            animator.SetBool("walk", true);//歩く        
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            pressingSeconds = 0;
            animator.SetBool("walk", false);//歩かない
        }
        Flick();//フリック
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

    //タッチした場所
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
                Gagecount -= 5;
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
                Gagecount -= 5;
            }

        }
        else
        {
            Direction = "touch";
        }
        if (isEnabledLongPress == true ||pressingSeconds>=longPressIntervaISeconds)
        {
            Direction = "longtouch";
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
                rigidbody2D.simulated = false;//なくすよ
                break;

            case "touch":
                Debug.Log("タッチ");//タッチした時の処理
                break;

            case "longtouch":
                Debug.Log("長押し");//長押し
              
                isEnabledLongPress = true;
                if (isEnabledLongPress==true)
                {
                    pressingSeconds = 0.0f;
                }
                break;
        }
    }
}