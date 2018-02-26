using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flick_nishiwaki : MonoBehaviour
{
    bool turikawa;

    public bool Turikawa
    {
        get { return turikawa; }
        set { turikawa = value; }
    }

    private Vector3 touchStartPos; // タッチ開始座標
    private Vector3 touchEndPos; // タッチ終了座標

    //public GameObject gameObject;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Flick();
    }

    // タッチした位置、離した位置を取得
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
                Debug.Log("右フリック");
            }
            else if (-30 > directionX)
            {
                //左向きにフリック
                Direction = "left";
                Debug.Log("左フリック");
            }
        }
        else if (Mathf.Abs(directionX) < Mathf.Abs(directionY))
        {
            if (30 < directionY)
            {
                //上向きにフリック
                Direction = "up";
            }
            else if (-30 > directionY)
            {
                //下向きのフリック
                Direction = "down";
            }
            else
            {
                Direction = "touch";
                Debug.Log("タッチ");
            }

            switch (Direction)
            {
                case "right":
                    Debug.Log("右フリック");//右フリックされた時の処理
                    turikawa = true;
                    break;

                case "left":
                    Debug.Log("左フリック");//左フリックされた時の処理
                    break;

                case "up":
                    Debug.Log("上フリック");//上フリックされた時の処理
                    break;

                case "down":
                    Debug.Log("下フリック");//下フリックされた時の処理
                    break;

                case "touch":
                    Debug.Log("タッチ");//タッチした時の処理
                    break;
            }
        }
    }
}