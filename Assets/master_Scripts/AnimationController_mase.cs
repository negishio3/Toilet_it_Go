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
<<<<<<< HEAD
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
    }

    public void OnUp()
    {
        //stop = false;
        //Walk = true;
        GetComponent<Animator>().SetBool("walk", true);//ボタン離したらWalkのアニメーションtrue
    }

=======
	}


    void Update()
    {
        if (stop == true)
        {
            animator.SetTrigger("wait");
            Debug.Log("俺が時を止めた");
        }


    }

    public void OnDown()
    {
        //stop = true;
        //Walk = false;
        GetComponent<Animator>().SetBool("walk", false);
        animator.SetTrigger("wait");
    }

    public void OnUp()
    {
        //stop = false;
        //Walk = true;
        GetComponent<Animator>().SetBool("walk", true);
    }

>>>>>>> origin/nishiwaki0220
    //    public void wait()
    //{
    //    animator.SetTrigger("wait");//待つ
    //}

    public void punch_Event()
    {
        Debug.Log("おらおらおら");
        animator.SetTrigger("unchp");//ぱんち
    }

}