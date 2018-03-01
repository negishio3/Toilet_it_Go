using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoreAni_murata : MonoBehaviour {

    Animator anim;

	void Start () {
        anim = GetComponent<Animator>();
        GetComponent<Animator>().SetBool("Open", true);
    }

    public void OpenDore()
    {
        GetComponent<Animator>().SetBool("Open", true);
    }
    public void CloseDore()
    {
        GetComponent<Animator>().SetBool("Close", true);
    }
}
