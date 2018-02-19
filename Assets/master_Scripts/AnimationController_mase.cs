using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationController_mase : MonoBehaviour
{

    Animator animator;

    // Use this for initialization
    void Start ()
    {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void wait()
    {
        animator.SetTrigger("stop");
    }

    public void Punch_action()
    {

    }
}
