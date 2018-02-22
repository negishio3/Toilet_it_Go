using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoreAni_murata : MonoBehaviour {

    Animator anim;

	void Start () {
        anim = GetComponent<Animator>();
	}
	
	
	void Update ()
    {
        GetComponent<Animator>().SetBool("Open", true);
    }
    public void OpenDore()
    {
        
    }
    public void CloseDore()
    {
        GetComponent<Animator>().SetBool("Clos", true);
    }
}
