using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCount_mase : MonoBehaviour
{
    public float time;//この中に数字入れるー

    // Use this for initialization
    void Start ()
    {
        GetComponent<Text>().text = ((int)time).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time < 0) time = 0;//0より下にならない
        {
            GetComponent<Text>().text = ((int)time).ToString();
        }
    }
}
