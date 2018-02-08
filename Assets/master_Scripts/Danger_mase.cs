using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Danger_mase : MonoBehaviour
{
    public GameObject Player;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Player.SetActive(true);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Player.SetActive(false);
        }
    }

    public void OnClick()
    {
        Debug.Log("ごくつぶし");
    }
}
