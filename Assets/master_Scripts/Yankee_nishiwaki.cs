using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yankee_nishiwaki : MonoBehaviour {

    public Animator animator;

    public GameObject yankee; // 不良
    public GameObject player; // プレイヤー

    public float dis;

    float move = 0.02f;

    //public float move;
    bool Punch;
    bool PunchMove = true;
    public static bool Hit;

    // Use this for initialization
    void Start ()
    {
        Punch = true;
        Hit = false;
        StartCoroutine(Walk());
        StartCoroutine(PunkDes());
    }

    // Update is called once per frame
    void Update ()
    {
        Vector2 Ypos = yankee.transform.position;
        Vector2 Ppos = player.transform.position;
        dis = Vector2.Distance(Ypos, Ppos);

        //if (Punch)
        //{
        //    if (dis <= 4.5)
        //    {
        //        PunkPunch();
        //    }
        //}

        Debug.Log(PunchMove);

        if (gameObject.transform.position.x <= -12)
        {
            Destroy(gameObject);
        }
    }
    void PunkPunch()
    {
        move = 0.0f;

        animator.SetTrigger("Punk_Punch");
    }

    private IEnumerator Walk()
    {
        while (gameObject.transform.position.x >= -12)
        {
            gameObject.transform.position -= new Vector3(move, 0, 0);

            if (dis <= 4.5)
            {
                if (PunchMove)
                {
                    PunkPunch();

                    yield return new WaitForSeconds(1.1f);

                    move = 0.02f;

                    PunchMove = false;
                }
            }
            yield return null;
        }
    }

    private IEnumerator PunkDes()
    {
        while (gameObject.transform.position.x >= -12)
        {
            if (Hit)
            {
                if (dis <= 5)
                {
                    yield return new WaitForSeconds(0.5f);

                    Destroy(gameObject);

                    Debug.Log("やられる");
                }
                yield return new WaitForSeconds(0.1f);

                Hit = false;
                Debug.Log(Hit);
            }
            yield return null;
        }
    }
}
