using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchEffect_mase : MonoBehaviour
{
    [SerializeField]
    ParticleSystem toucheffect;//ここに再生させるエフェクトを入れる
    [SerializeField]
    Camera _camera;//再生させるカメラを入れる

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
<<<<<<< HEAD
        if (Input.GetMouseButtonDown(0) || Input.touchCount>0)//マウスクリック・タップで反応
        {
            // マウス・タップのワールド座標までパーティクルを移動し、パーティクルエフェクトを1つ生成する
=======
        if (Input.GetMouseButtonDown(0) || Input.touchCount>0)
        {
            // マウスのワールド座標までパーティクルを移動し、パーティクルエフェクトを1つ生成する
>>>>>>> origin/nishiwaki0209
            var pos = _camera.ScreenToWorldPoint(Input.mousePosition + _camera.transform.forward * 10);
            toucheffect.transform.position = pos;
            toucheffect.Emit(1);
        }
	}
}
