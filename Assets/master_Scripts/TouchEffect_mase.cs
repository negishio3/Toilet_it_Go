using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchEffect_mase : MonoBehaviour
{
    [SerializeField]
    ParticleSystem toucheffect;//ここに再生させるエフェクトを入れる
    [SerializeField]
    Camera _camera;//再生させるカメラを入れる

    Vector2 pos;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)//マウスクリック・タップで反応
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //複数個所タッチしたときのそれぞれの座標
            for (int i = 0; i < Input.touchCount; i++)
            {
                Vector2 pos_t = Input.touches[i].position;
                Vector2 pos = _camera.ScreenToWorldPoint(Input.touches[i].position);

                toucheffect.transform.position = pos;
                toucheffect.Emit(1);
            }
        }

        //if (Input.touchCount <= 1)
        //{
        //    //if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)//マウスクリック・タップで反応
        //    if(Input.GetKeyDown(KeyCode.Mouse0))
        //    {
        //        // マウス・タップのワールド座標までパーティクルを移動し、パーティクルエフェクトを1つ生成する
        //        pos = _camera.ScreenToWorldPoint(Input.mousePosition + _camera.transform.forward * 10);
        //        toucheffect.transform.position = pos;
        //        toucheffect.Emit(1);
        //    }
        //}
    }
}
