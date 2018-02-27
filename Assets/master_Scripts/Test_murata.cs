using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Test_murata : MonoBehaviour
{
    public Animator animator;
    public float speed;

    private Vector3 touchStartPos;
    private Vector3 touchEndPos;

    bool walkanim;

    Rigidbody2D rigidbody2D;

   // public UnityEvent onLongPress = new UnityEvent();//長押し

    private float IntervalSecond=0.0f;
    
    public float longPressIntervaISeconds = 1.0f;//長押し1秒以上で長押し

    private float pressingSeconds = 0.0f;//タプした時間
    private bool isEnabledLongPress = true;//長押し
    private bool isPressing = false;//タップ
	
    //デバック用
	void Start ()
    {
        animator = GetComponent<Animator>();
        animator.speed = speed;

        rigidbody2D = GetComponent<Rigidbody2D>();

    //    onClick.AddListener(() => Debug.Log("タップ"));
    //    onLongPress.AddListener(() => Debug.Log("長押し"));
    }
	
	void Update ()
    {
        // if (isPressing && isEnabledLongPress)//タプと長押し
        //  {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            pressingSeconds += Time.deltaTime;
            animator.SetBool("walk", true);
            if (pressingSeconds >= longPressIntervaISeconds)
            {
                IntervalSecond += Time.deltaTime;
                Debug.Log("長押し");
                isEnabledLongPress = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            animator.SetBool("walk", false);
            pressingSeconds = 0.0f;
            IntervalSecond = 0.0f;
            isEnabledLongPress = true;
        }
            //pressingSeconds += Time.deltaTime;//タップした時間に加算する時間
            //if (pressingSeconds >= longPressIntervaISeconds)//タップしている時間が1秒を超えたら
            //{
                //onLongPress.Invoke();//長押しを呼ぶ
              //  Debug.Log("長押し");
        //        isEnabledLongPress = false;//今長押ししているからfalseにする
        //    }
        //}
        Flick();
	}

    //ボタンが押されている
    //public override void OnPointerDown(UnityEngine.EventSystems.PointerEventData eventData)
    //{
    //    base.OnPointerDown(eventData);//ボタン押された
    //    isPressing = true;//タプされているからtrue
    //}

    //ボタンが放された
    //public override void OnPointerUp(UnityEngine.EventSystems.PointerEventData eventData)
    //{
    //    base.OnPointerUp(eventData);//ボタン放された
    //    pressingSeconds = 0.0f;//タプした時間を0秒
    //    isEnabledLongPress = true;//長押し初期状態へ
    //    isPressing = false;//タプ初期状態へ
    //}

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
                //右向きフック
                Direction = "right";
            }
            else if (-30 > directionX)
            {
                //左向きにフック
                Direction = "left";
            }
        }
        else if (Mathf.Abs(directionX) < Mathf.Abs(directionY))
        {
            if (30 < directionY)
            {
                //上向きにフック
                Direction = "up";
            }
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

            case "touch":
                Debug.Log("タッチ");
                animator.SetBool("walk", true);
                walkanim = true;
                if (walkanim == true)
                {
                    animator.SetBool("walk", false);
                }
                break;
        }

    }

}
