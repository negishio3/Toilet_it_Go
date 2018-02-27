using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Test_murata))]
public class Test_murata : Button
{
    public UnityEvent onLongPress = new UnityEvent();//長押し

    public float longPressIntervaISeconds = 1.0f;//長押し1秒以上で長押し

    private float pressingSeconds = 0.0f;//タプした時間
    private bool isEnabledLongPress = true;//長押し
    private bool isPressing = false;//タップ
	
    //デバック用
	void Start ()
    {
        onClick.AddListener(() => Debug.Log("タップ"));
        onLongPress.AddListener(() => Debug.Log("長押し"));
    }
	
	void Update ()
    {
        if (isPressing && isEnabledLongPress)//タプと長押し
        {
            pressingSeconds += Time.deltaTime;//タップした時間に加算する時間
            if (pressingSeconds>=longPressIntervaISeconds)//タップしている時間が1秒を超えたら
            {
                onLongPress.Invoke();//長押しを呼ぶ
                isEnabledLongPress = false;//今長押ししているからfalseにする
            }
        }
	}

    //ボタンが押されている
    public override void OnPointerDown(UnityEngine.EventSystems.PointerEventData eventData)
    {
        base.OnPointerDown(eventData);//ボタン押された
        isPressing = true;//タプされているからtrue
    }

    //ボタンが放された
    public override void OnPointerUp(UnityEngine.EventSystems.PointerEventData eventData)
    {
        base.OnPointerUp(eventData);//ボタン放された
        pressingSeconds = 0.0f;//タプした時間を0秒
        isEnabledLongPress = true;//長押し初期状態へ
        isPressing = false;//タプ初期状態へ
    }

}
