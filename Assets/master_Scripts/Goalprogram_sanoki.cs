using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goalprogram_sanoki : MonoBehaviour {

    SceneFader_sanoki sf;
    public TrainMove_sanoki TrainMove;

    void Start()
    {
        sf = FindObjectOfType<SceneFader_sanoki>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Goal")
        {
            Debug.Log("当たった");
            TrainMove.buttonFlg = false;
            sf.StageSelect("Rank_Murata");
        }
    }
}
