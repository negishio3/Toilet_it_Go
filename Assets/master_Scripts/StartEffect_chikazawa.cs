using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartEffect_chikazawa : MonoBehaviour {

    public Image start_button;
    bool flg = false;
    float spd = 0.05f;
    float alqa = 1;

    // Use this for initialization
    void Start () {
        start_button.GetComponent<RectTransform>();
        start_button.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonUp(0))
        {
            flg = true;
            //start_button.gameObject.SetActive(false);
        }
        if (flg)
        {
            start_button.rectTransform.localScale += new Vector3(spd,spd);
            start_button.color = new Color(0, 0, 0, alqa);
            alqa -= spd;
        }
    }

    public void BUTTON_DOWN()
    {
        start_button.gameObject.SetActive(true);
    }
}
