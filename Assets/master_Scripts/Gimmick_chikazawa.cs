using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimmick_chikazawa : MonoBehaviour {

    public TrainMove_sanoki TM;
	// Use this for initialization
	void Start () {
        TM = FindObjectOfType<TrainMove_sanoki>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if(TM.UNKOman==true || col.gameObject.name == "GimmickDestroyer")
        {
            Destroy(gameObject);
        }
    }
}
