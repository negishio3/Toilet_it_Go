using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goalprogram_sanoki : MonoBehaviour {

    SceneFader_sanoki sf;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Goal")
        {
            Debug.Log("当たった");
            sf.StageSelect("sanoki_Title");
        }
    }
}
