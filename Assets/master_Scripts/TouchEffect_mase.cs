using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchEffect_mase : MonoBehaviour
{
    [SerializeField]
    ParticleSystem toucheffect;
    [SerializeField]
    Camera _camera;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var pos = _camera.ScreenToWorldPoint(Input.mousePosition + _camera.transform.forward * 10);
            toucheffect.transform.position = pos;
            toucheffect.Emit(1);
        }
	}
}
