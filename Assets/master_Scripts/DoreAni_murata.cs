using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoreAni_murata : MonoBehaviour {

    Animator anim;//アニメーション扉

	void Start () {
        anim = GetComponent<Animator>();
        GetComponent<Animator>().SetBool("Open", true);//最初に扉開く
    }

    //扉閉まります
    public void CloseDore()
    {
        GetComponent<Animator>().SetTrigger("Close");
    }
}
