using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController_mase : MonoBehaviour {

    Animator animator;
    bool push = false;

    // Use this for initialization
    void Start () {

        animator = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void wait_action()
    {
            animator.SetTrigger("wait");//歩く
    }

    public void punch_action()
    {
        animator.SetTrigger("unchｐ");//ぱんち
    }

}
