using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yankee_nishiwaki : MonoBehaviour {

    public Animator animator; // アニメーション

    GameObject yankee; // 不良
    GameObject player; // プレイヤー

    TrainMove_sanoki trainMove;

    float dis; // 不良とプレイヤーの距離

    float move = 0.02f; // 不良のスピード

    bool Punch;
    bool PunchMove = false;
    public static bool Hit; // プレイヤーのパンチ判定
    bool Die; // 不良にパンチが当たったか

    public SE_murata SE_pa;//パンチ
    // Use this for initialization
    void Start ()
    {
        StartCoroutine(yankee_Walk());
        trainMove = FindObjectOfType<TrainMove_sanoki>();
        Punch = true;
        //PunchMove = false;
        Hit = false;
        Die = false;
        StartCoroutine(Walk());
        StartCoroutine(PunkDes());
    }

    // Update is called once per frame
    void Update ()
    {
        // 不良とプレイヤーの距離を求める
        Vector2 Ypos = gameObject.transform.position;
        Vector2 Ppos = GameObject.Find("character_walk01").transform.position;
        dis = Vector2.Distance(Ypos, Ppos);

        if (Punch)
        {
            if (dis <= 3)
            {
                PunchMove = true;
                trainMove.Yankeepunch = true;
            }
        }

        // 左端もしくは右端についたら消滅
        if (gameObject.transform.position.x <= -14)
        {
            Destroy(gameObject);
        }
        else if(gameObject.transform.position.x >= 14)
        {
            Destroy(gameObject);
        }

        // プレイヤーから殴られたら右に飛んでいく
        if (Die)
        {
            if(gameObject.transform.position.x <= 15)
            {
                gameObject.transform.position += new Vector3(0.2f, 0, 0);
            }
        }

        //Debug.Log(PunchMove);
    }

    private IEnumerator Walk()
    {
        while (gameObject.transform.position.x >= -15)
        {
            gameObject.transform.position -= new Vector3(move, 0, 0); // 不良移動

            if (PunchMove)
            {
                move = 0.0f; // 動きを止める

                animator.SetTrigger("Punk_Punch"); // アニメーション「パンチ」

                SE_pa.SE_Play(2);//SE殴る

                Punch = false;

                yield return new WaitForSeconds(1.1f);

                PunchMove = false;
                trainMove.Yankeepunch = false;

                move = 0.02f; // また歩き始める
            }

            yield return null;
        }
    }

    private IEnumerator PunkDes()
    {
        while (gameObject.transform.position.x >= -14)
        {
            if (Hit) // プレイヤーから殴られたとき
            {
                if (dis <= 5)
                {
                    SE_pa.SE_Play(1);//SE殴られた
                    yield return new WaitForSeconds(0.5f);

                    animator.SetTrigger("Punk_Die");

                    move = 0.0f;

                    Die = true;
                }
                yield return new WaitForSeconds(0.1f);

                Hit = false;
            }
            yield return null;
        }
    }

    public bool punchMove
    {
        get { return PunchMove; }
    }

    IEnumerator yankee_Walk()
    {
        SE_pa.SE_Play(0);
        yield return new WaitForSeconds(0.5f);
        yield return StartCoroutine(yankee_Walk());
    }
}
