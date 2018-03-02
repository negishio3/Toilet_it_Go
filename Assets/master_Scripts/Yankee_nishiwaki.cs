using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yankee_nishiwaki : MonoBehaviour {

    public Animator animator;

    public GameObject yankee; // 不良
    public GameObject player; // プレイヤー

    //public float move;
    bool Punch;

    // Use this for initialization
    void Start ()
    {
        Punch = true;
        StartCoroutine(Walk());
	}
	
	// Update is called once per frame
	void Update ()
    {
        //gameObject.transform.position -= new Vector3(move, 0, 0);

        Vector2 Ypos = yankee.transform.position;
        Vector2 Ppos = player.transform.position;
        float dis = Vector2.Distance(Ypos, Ppos);
        //Debug.Log("Distance : " + dis);

        if (Punch)
        {
            if (dis <= 4.5)
            {
                PunkPunch();
            }
        }
        else if (Punch == false)
        {
        }
    }
    void PunkPunch()
    {
        //move = 0.0f;
        animator.SetTrigger("Punk_Punch");
        Punch = false;
    }

    private IEnumerator Walk()
    {
        float move = 0.02f;

        while (gameObject.transform.position.x >= -12)
        {
            gameObject.transform.position -= new Vector3(move, 0, 0);
            yield return null;
        }
        
    }
}
