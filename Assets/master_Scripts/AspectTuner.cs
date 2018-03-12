using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AspectTuner : MonoBehaviour {

    public RectTransform CanvasSize;
    public Image ThisImage;

	// Use this for initialization
	void Start () {
		ThisImage.rectTransform.sizeDelta= new Vector2((ThisImage.sprite.bounds.size.x * CanvasSize.sizeDelta.y) / ThisImage.sprite.bounds.size.y, CanvasSize.sizeDelta.y);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
