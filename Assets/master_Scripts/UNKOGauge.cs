using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UNKOGauge : MonoBehaviour {

    float UnkoGauge;//うんこゲージ

    /// <summary>
    /// うんこゲージを増やす
    /// </summary>
    /// <param name="GaugeIncrease">増加量</param>
    public void GaugeUp(float GaugeIncrease)
    {
        UnkoGauge += GaugeIncrease;
    }

    /// <summary>
    /// うんこゲージを減らす
    /// </summary>
    /// <param name="GaugeDecrease">減少量</param>
    public void GaugeDown(float GaugeDecrease)
    {
        UnkoGauge -= GaugeDecrease;
    }

}
