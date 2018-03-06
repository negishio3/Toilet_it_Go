using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartEfect_chikazawa : MonoBehaviour {

    public GameObject start_button;


	// Use this for initialization
	void Start () {

        //start_button = GetComponent<GameObject>().;
        start_button.SetActive(false);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void BUTTON_ON()
    {
        if (Input.GetMouseButtonDown(0))
        {

            start_button.SetActive(true);
        }
        if (Input.GetMouseButtonUp(0))
        {
            start_button.SetActive(false);
        }
    }
}
