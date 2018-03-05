using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartWaitAlqa_chikazawa : MonoBehaviour {

    float alqa = 0;
    float FadeSpd = 3;
    public bool stop = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update ()
    {
        GetComponent<Image>().color = new Color(0, 0, 0, alqa / 255.0f);
        if (!stop)
        {
            alqa += FadeSpd;// * Time.deltaTime;
        }
        if (alqa >= 120.0f)
        {
            alqa = 120.0f;
            stop = true;
        }
        else if (Input.GetMouseButtonDown(0))
        {
            alqa = 120.0f;
        }
    }
}
