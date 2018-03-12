using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goal_mase : MonoBehaviour
{
    public static bool toilet_hit = false;
    TrainMove_sanoki Stop;

    void Start()
    {
        Stop = FindObjectOfType<TrainMove_sanoki>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //Debug.LogError("Player当たった");
            Stop.GoalFlg = true;
        }
    }
}
