using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove_nishiwaki : MonoBehaviour
{
    public float move;//移動スピード
    public GameObject Barrier;//バリアオブジェクト
    public SE_murata SE_Rou;//SE

    [SerializeField]
    TrainMove_sanoki trainmove;

    Animator anima;

    Count_chika check;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(ba_Walk());
        Barrier.SetActive(false);
        //  trainmove = FindObjectOfType<TrainMove_sanoki>();
        check = FindObjectOfType<Count_chika>();
        anima = GetComponent<Animator>();
        anima.SetBool("start_rougai", false);
    }

    // Update is called once per frame
    void Update()
    {

        if (!check.Swait)
        {
            gameObject.transform.position -= new Vector3(move, 0, 0);
            //SE_Rou.SE_Play(0);
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
    IEnumerator ba_Walk()
    {
        SE_Rou.SE_Play(0);
        yield return new WaitForSeconds(0.5f);
        yield return StartCoroutine(ba_Walk());
    }
}
