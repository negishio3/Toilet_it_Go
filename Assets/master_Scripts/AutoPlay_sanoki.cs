using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoPlay_sanoki : MonoBehaviour {

    TouchAnimationController_mase touchMase;
    TitlePurogram_sanoki TitlePro;

    public GameObject UNKOman;
    bool isPlay;

    bool TapFlg;

    public LayerMask mask;
    public float Distans = 3 ;
    public float TapSpeed = 0.125f;

    Ray2D GimmickRay;
    Ray2D CancelRay;

    void Start()
    {
        TitlePro = FindObjectOfType<TitlePurogram_sanoki>();
        touchMase = FindObjectOfType<TouchAnimationController_mase>();
        GimmickRay = new Ray2D(UNKOman.transform.position, UNKOman.transform.right);
        CancelRay = new Ray2D(UNKOman.transform.position, -UNKOman.transform.right);
    }

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(GimmickRay.origin,GimmickRay.direction,Distans,mask);
        if (hit.collider)
        {
            isPlay = true;
            switch (hit.collider.gameObject.name)
            {   
                case "rougai":
                    touchMase.Wait();
                    break;
            }
        }
        else
        {
            isPlay = false;
            if(!isPlay){
                Invoke("Move", TapSpeed);
            }
            if(hit.collider)
            {
                switch (hit.collider.gameObject.name)
                {
                    case "rougai":
                        touchMase.Wait();
                        break;
                }
            }

           
        }
        Debug.DrawRay(GimmickRay.origin, GimmickRay.direction * Distans, Color.red);
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
