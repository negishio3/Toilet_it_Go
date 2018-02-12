using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_chikazawa: MonoBehaviour {

    public float speed; //歩くスピード
    private new Rigidbody2D rigidbody2D;

    // Use this for initialization
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()
    {
        //左キー: -1、右キー: 1
        float x = Input.GetAxisRaw("Horizontal");
        //左か右を入力したら
        if (x != 0)
        {
            //入力方向へ移動
            rigidbody2D.velocity = new Vector2(x * speed, rigidbody2D.velocity.y);
            ////localScale.xを-1にすると画像が反転する、これで歩く方向に体が向く
            //Vector2 tempScl = transform.localScale;
            //transform.localScale = tempScl;
        }
        else
        {
            //横移動の速度を0にしてピタッと止まるようにする
            rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
        }
    }
}
