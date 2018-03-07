using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove_nishiwaki : MonoBehaviour
{
    public float move;//移動スピード
    public GameObject Barrier;//バリアオブジェクト

    // Use this for initialization
    void Start()
    {
        Barrier.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
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
        Barrier.SetActive(true);
    }
}
