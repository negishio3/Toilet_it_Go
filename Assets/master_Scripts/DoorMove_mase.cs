using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMove_mase : MonoBehaviour
{
    public GameObject Door;
    public float ClauseSpeed;
    Vector2 StartPos;
    Vector2 EndPos;


    // Use this for initialization
    void Start ()
    {
        StartPos = Door.transform.position;
        EndPos = new Vector2(9.62f,-0.48f);
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    public void move()
    {
        StartCoroutine(Close(ClauseSpeed));
    }

    IEnumerator Close(float seconds)
    {
        float time = 0;
        while (time < 1.0f)
        {
            time += Time.deltaTime / seconds;
            Door.transform.position = Vector2.Lerp(StartPos,EndPos, time);
            yield return null;
            Debug.Log("コルーチン");
        }
    }

}
