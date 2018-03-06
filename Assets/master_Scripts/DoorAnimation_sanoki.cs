using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorAnimation_sanoki : MonoBehaviour {

    TutorialSlide_Murata slide;

    public Image[] Door;

    public float OpenSpeed;

    Vector2 StartPos_right;
    Vector2 EndPos_right;
    Vector2 StartPos_left;
    Vector2 EndPos_left;

    bool isOpen;

    enum door
    {
        Right,
        Left
    }

    void Start () {

        //for (int i = 0; i < Door.Length; i++) {
            //Door[i].rectTransform.sizeDelta.x                                  
                

        slide = FindObjectOfType<TutorialSlide_Murata>();
        StartPos_right = Door[(int)door.Right].transform.localPosition;
        StartPos_left = Door[(int)door.Left].transform.localPosition;
        EndPos_right = new Vector2(
            (Door[(int)door.Right].transform.localPosition.x + Door[(int)door.Right].rectTransform.sizeDelta.x)* Door[(int)door.Right].rectTransform.localScale.x, 
            Door[(int)door.Right].transform.localPosition.y);
        EndPos_left = new Vector2(
            (Door[(int)door.Left].transform.localPosition.x - Door[(int)door.Left].rectTransform.sizeDelta.x)* Door[(int)door.Left].rectTransform.localScale.x,
            Door[(int)door.Left].transform.localPosition.y);
        Door_Open("Open");
    }

    public void Door_Open(string door)
    {
        if (!isOpen)
        {
            isOpen = true;
            switch (door)
            {
                case "Open":
                case "open":
                    StartCoroutine(DoorOpen(OpenSpeed));
                    break;
                case "Close":
                case "close":
                    StartCoroutine(DoorClose(OpenSpeed,false));
                    break;
                case "Close_and_Open_Right":
                    slide.Direction = "right";
                    StartCoroutine(DoorClose(OpenSpeed,true));
                    break;
                case "Close_and_Open_Left":
                    slide.Direction = "left";
                    StartCoroutine(DoorClose(OpenSpeed, true));
                    break;
                default:
                    Debug.LogError("Open,Close意外の引数が入力されました");
                    break;
            }
        }
    }
    public IEnumerator DoorOpen(float seconds)
    {
        float time = 0;

        while (time < 1.0f)
        {
            time += Time.deltaTime / seconds;
            Door[(int)door.Left].transform.localPosition = Vector2.Lerp(StartPos_left, EndPos_left, time);
            Door[(int)door.Right].transform.localPosition = Vector2.Lerp(StartPos_right, EndPos_right, time);
            yield return null;
        }
        isOpen = false;
    }

    public IEnumerator DoorClose(float seconds, bool andOpen)
    {
        float time = 0;


        while (time < 1.0f)
        {
            time += Time.deltaTime / seconds;
            Door[(int)door.Left].transform.localPosition = Vector2.Lerp(EndPos_left, StartPos_left, time);
            Door[(int)door.Right].transform.localPosition = Vector2.Lerp(EndPos_right, StartPos_right, time);
            yield return null;
        }
        switch (slide.Direction) {
            case "left":
                slide.Slide(true);
                break;
            case "right":
                slide.Slide(false);
                break;
            default:
                Debug.LogError("右左どっちにスライドすればええねん");
                break;
        }
        if (andOpen)
        {
            yield return new WaitForSeconds(0.5f);
            yield return DoorOpen(OpenSpeed);
        }
        isOpen = false;
    }
}
