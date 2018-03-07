using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove_nishiwaki : MonoBehaviour
{
    public float move;//移動スピード
    public GameObject Barrier;//バリアオブジェクト

    [SerializeField]
    TrainMove_sanoki trainmove;

    Animator anima;

    // Use this for initialization
    void Start()
    {
        Barrier.SetActive(false);
        trainmove = FindObjectOfType<TrainMove_sanoki>();
        anima = GetComponent<Animator>();
        anima.SetBool("start_rougai", false);
    }

    // Update is called once per frame
    void Update()
    {

        if (!trainmove.PauseFlg)
        {
            gameObject.transform.position -= new Vector3(move, 0, 0);
            anima.SetBool("start_rougai", true);
        }

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
