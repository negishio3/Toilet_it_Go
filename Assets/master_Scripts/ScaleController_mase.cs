using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleController_mase : MonoBehaviour
{
    public GameObject Image;//選択画像
    bool isClick;

    public void Ontap()
    {
        if (!isClick)
        {
            isClick = true;
            StartCoroutine(ButtonClick());
        }
    }

    public IEnumerator ButtonClick()
    {
        Vector2 startSize = new Vector2(Image.transform.localScale.x, Image.transform.localScale.y);
        Vector2 endSize = new Vector2(Image.transform.localScale.x * 1.5f, Image.transform.localScale.y * 1.5f);

        float seconds = 0.2f;
        float time = 0;

        while (time <= 1.0f)
        {
            time += Time.deltaTime / seconds;
            Image.transform.localScale = Vector2.Lerp(startSize, endSize, time);
            yield return null;
        }
        time = 0;
        while (time <= 1.0f)
        {
            time += Time.deltaTime / seconds;
            Image.transform.localScale = Vector2.Lerp(endSize, startSize, time);
            yield return null;
        }
        isClick = false;

    }
}

