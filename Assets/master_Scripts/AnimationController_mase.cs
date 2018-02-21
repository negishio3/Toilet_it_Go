using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController_mase : MonoBehaviour
{

    Animator animator;
    bool stop = false;
    bool Walk = false;

    // Use this for initialization
    void Start()
    {

        animator = GetComponent<Animator>();

    }


    void Update()
    {
        //if (stop == true)
        //{
        //    animator.SetTrigger("wait");
        //    Debug.Log("俺が時を止めた");
        //}


    }

    public void OnDown()
    {
        //stop = true;
        //Walk = false;
        GetComponent<Animator>().SetBool("walk", false);//ボタン押したらWalkのアニメーションfalse
        animator.SetTrigger("wait");//waitのアニメーション再生
       // Debug.Log("俺が時を止めた");
    }

    public void OnUp()
    {
        //stop = false;
        //Walk = true;
        GetComponent<Animator>().SetBool("walk", true);//ボタン離したらWalkのアニメーションtrue
    }

    public void punch_Event()
    {
       // Debug.Log("おらおらおら");
        animator.SetTrigger("unchp");//ぱんち
    }
}