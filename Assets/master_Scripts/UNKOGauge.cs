using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UNKOGauge : MonoBehaviour {

    Animator animator;

    public float UnkoGauge;//うんこゲージ

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (UnkoGauge >= 5)
        {
            animator.SetBool("unkos",true);
        }
    }

    /// <summary>
    /// うんこゲージを増やす
    /// </summary>
    /// <param name="GaugeIncrease">増加量</param>
    public void GaugeUp(float GaugeIncrease)
    {
        UnkoGauge += GaugeIncrease * Time.deltaTime;
    }

    /// <summary>
    /// うんこゲージを減らす
    /// </summary>
    /// <param name="GaugeDecrease">減少量</param>
    public void GaugeDown(float GaugeDecrease)
    {
        UnkoGauge -= GaugeDecrease * Time.deltaTime;
    }



}
