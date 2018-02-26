using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turikawa_nishiwaki : MonoBehaviour {

    Rigidbody2D rigidbody;
    bool turikawa;

	// Use this for initialization
	void Start ()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            rigidbody.simulated = false;
        }
        else
        {
            rigidbody.simulated = true;
        }
	}
}
