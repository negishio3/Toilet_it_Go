using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strap_Catch : MonoBehaviour
{

    Vector2 PlayerPos;

    List<Vector2> StrapPos = new List<Vector2>();

    void Start()
    {
        PlayerPos = transform.position;
    }

    public void StrapCatch()
    {
        StrapPos.Clear();
        
    }
}
