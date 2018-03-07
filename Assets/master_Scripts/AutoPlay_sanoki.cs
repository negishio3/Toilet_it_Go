using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoPlay_sanoki : MonoBehaviour {

    TouchAnimationController_mase touchMase;
    TitlePurogram_sanoki TitlePro;

    public GameObject UNKOman;

    public bool isPlay;

    bool TapFlg;

    public float TapSpeed = 0.125f;

    void Start()
    {
        TitlePro = FindObjectOfType<TitlePurogram_sanoki>();
        touchMase = FindObjectOfType<TouchAnimationController_mase>();
        StartCoroutine(PlayerMove());
    }

    private IEnumerator PlayerMove()
    {
        if (!isPlay)
        {
            isPlay = true;
            Move();
        }
        yield return new WaitForSeconds(TapSpeed);
        yield return StartCoroutine(PlayerMove());
    }

    //void OnTriggerStay2D(Collider2D other)
    //{
    //    if (!isPlay)
    //    {
    //        isPlay = true;
    //        if (other.tag == "rougai")
    //        {
    //            Debug.Log("老害");
    //            touchMase.Wait();
    //        }
    //    }
    //}
    void OnTriggerExit2D(Collider2D Col)
    {
        isPlay = false;
    }

    void Move()
    {
        touchMase.RigidbodyOn();
        touchMase.animator.SetBool("walk", TapFlg);
        TapFlg = !TapFlg;
        TitlePro.TrainMoving();
        isPlay = false;
    }
}
