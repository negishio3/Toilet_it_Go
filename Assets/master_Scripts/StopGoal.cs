using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopGoal : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        StartCoroutine("stop");
    }

    public IEnumerator stop()
    {
        // ログ出力  
        Debug.Log("1");

        // 1秒待つ  
        yield return new WaitForSeconds(1.0f);

        // ログ出力  
        Debug.Log("2");

        // 2秒待つ  
        yield return new WaitForSeconds(2.0f);

        // ログ出力  
        Debug.Log("3");
    }
}

