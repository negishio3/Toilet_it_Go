using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kenatu : MonoBehaviour {

    float kenatu;
	// Use this for initialization
	void Start () {
        kenatu = 0.04f;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(kenatu, 0, 0);
	}
}
