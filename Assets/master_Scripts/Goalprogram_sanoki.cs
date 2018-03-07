using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goalprogram_sanoki : MonoBehaviour {

    SceneFader_sanoki sf;
    public TrainMove_sanoki TrainMove;
    public float GoalWaitTime;//待ち時間

    void Start()
    {
        sf = FindObjectOfType<SceneFader_sanoki>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Goal")
        {
               //Debug.Log("当たった");
            //TrainMove.Pause();
            //sf.StageSelect("Rank_Murata");
            StartCoroutine("stop");

        }
    }


    IEnumerator stop()
    {
        yield return new WaitForSeconds(GoalWaitTime);
        TrainMove.Pause();
        sf.StageSelect("Rank_Murata");
    }
}
