using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMove_mase : MonoBehaviour
{
    //public GameObject Door;
    //public GameObject endpos;
    //public float ClauseSpeed;
    //Vector2 StartPos;
    //Vector2 EndPos;
    Animator animator;
    public GameObject SE_GO;//SE


    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //StartCoroutine(Close(ClauseSpeed));
            animator.SetTrigger("goal");
            Debug.Log("ヒット");
            SE_GO.SetActive(true);//se
        }
    }

    //public void on()
    //{
    //    StartCoroutine(Close(ClauseSpeed));
    //}
    //IEnumerator Close(float seconds)
    //{
    //    float time = 0;
    //    while (time < 1.0f)
    //    {
    //        time += Time.deltaTime / seconds;
    //        Door.transform.position = Vector2.Lerp(StartPos,EndPos, time);
    //        yield return null;
    //        Debug.Log("コルーチン");
    //    }
    //}
    //public void SetPos()
    //{
    //    StartPos = Door.transform.position;
    //    EndPos = endpos.transform.position;
    //}

}
