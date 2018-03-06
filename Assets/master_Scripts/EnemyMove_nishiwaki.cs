using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove_nishiwaki : MonoBehaviour
{
    public float move;//移動スピード
    TrainMove_sanoki trainMove;
    // Use this for initialization
    void Start()
    {
        trainMove = FindObjectOfType<TrainMove_sanoki>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!trainMove.PauseFlg)
        gameObject.transform.position -= new Vector3(move, 0, 0);

        //左に行って削除老害
        if (gameObject.transform.position.x <= -15)
        {
            //Debug.Log("削除");
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
