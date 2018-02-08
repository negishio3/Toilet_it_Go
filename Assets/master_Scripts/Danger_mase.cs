using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Danger_mase : MonoBehaviour
{

    public GameObject Player;
    public ParticleSystem effect;

    // Use this for initialization
    void Start ()
    {
        effect = this.GetComponent<ParticleSystem>();

        effect.Stop();
	}
	
	// Update is called once per frame
	void Update ()
    {

    }


    public void OnClick()
    {
        effect.Play();
        Debug.Log("ごくつぶし");
    }
}
