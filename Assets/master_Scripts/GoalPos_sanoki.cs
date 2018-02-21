using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalPos_sanoki : MonoBehaviour {
    bool centerFlg;
    void Update()
    {
        if (transform.position.x <= 0) centerFlg = true;
    }
    public bool CenterFlg
    {
        get { return this.centerFlg; }
    }
}
