using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punk_nishiwaki : MonoBehaviour {

    private static readonly int hashPunch = Animator.StringToHash("furyou_Punch");
    private static readonly int hashWalk = Animator.StringToHash("furyou_walk");

    public GameObject unko;

    // Use this for initialization
    void Start () {
        StartCoroutine("test");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private IEnumerator Punk()
    {
        Animator animator = GetComponent<Animator>();
        animator.Play(hashWalk);
        yield return null;

    }
    
    public IEnumerator test()
    {
        Vector2 startPos = Vector2.zero;
        //Vector2 endPos = new Vector2(unko.transform.position.x, unko.transform.position.y);

        float seconds = 5.0f;
        float time = 0;
        while(time < 1.0f)
        {
            time += Time.deltaTime/seconds;
            //unko.transform.position = Vector2.Lerp(startPos,endPos,time);
            yield return null;
        }
    }
}
