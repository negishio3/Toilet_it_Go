using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartEffect_chikazawa : MonoBehaviour {

    public GameObject start_button;


	// Use this for initialization
	void Start () {

        start_button.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonUp(0))
        {
            start_button.SetActive(false);
        }

    }

    public void BUTTON_DOWN()
    {
        start_button.SetActive(true);
    }
}
