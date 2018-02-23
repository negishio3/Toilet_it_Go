using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchAnimationController_mase : MonoBehaviour
{

   public Animator animator;
   public float speed;


	// Use this for initialization
	void Start ()
    {
        animator = GetComponent<Animator>();
        animator.speed = speed;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
        {
            animator.SetBool("walk", true);
            //animator.SetTrigger("walk 0");
            Debug.Log("うごくちゃんだうー");
        }
        else if (Input.GetMouseButtonUp(0) || Input.touchCount < 0)
        {
            animator.SetBool("walk", false);
            //animator.SetBool("stand",true);
            Debug.Log("とまるちゃんだお");
        }
    }
}
