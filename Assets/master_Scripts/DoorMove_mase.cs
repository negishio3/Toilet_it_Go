using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMove_mase : MonoBehaviour
{
    Animator animator;
    public GameObject Player;
    public GameObject Goal;

    // Use this for initialization
    void Start ()
    {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 Ppos = Player.transform.position;
        Vector2 Gpos = Goal.transform.position;
        float dis = Vector2.Distance(Ppos, Gpos);
        Debug.Log("Distance : " + dis);
	}
}
