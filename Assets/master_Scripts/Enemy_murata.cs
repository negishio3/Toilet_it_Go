using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_murata : MonoBehaviour
{

    GameObject[] Enemys=new GameObject[2];//public老害、不良保存
    public GameObject[] Enemy;//老害、不良
    float move = 0.1f;//移動スピード

    public float Oldage_tim_sta=0.0f;//時間老害
    public float Bad_tim_sta = 0.0f;//時間不良

    public float Oldage_tim_end=1f;//生成時間老害
    public float Bad_tim_end = 1f;//生成時間不良

    void Start()
    {
      
    }


    void Update()
    {
       
        //時間で生成
        Oldage_tim_sta += Time.deltaTime;
        Bad_tim_sta += Time.deltaTime;

        //生成老害
        if (Oldage_tim_sta >= Oldage_tim_end)
        {
            Enemys[0] = Instantiate(Enemy[0], new Vector3(10f, -2.5f, 0), Quaternion.identity);
            //値を0にする
            Oldage_tim_sta = 0;
        }     
        
        //生成不良
        if (Bad_tim_sta >= Bad_tim_end)
        {
            Enemys[1] = Instantiate(Enemy[1], new Vector3(10f, -2.5f, 0), Quaternion.identity);
        }

        //移動老害
        if (Enemys[0] != null)
        {
            Enemys[0].transform.position -= new Vector3(move, 0, 0);

            //左に行って削除老害
            if (Enemys[0].transform.position.x <= -10)
            {
                Debug.Log("削除");
                Destroy(Enemys[0]);
                //値を0にする
                Bad_tim_sta = 0;
            }
        }
        
        //移動不良
        if (Enemys[1] != null)
        {
            Enemys[1].transform.position -= new Vector3 (move,0,0);

            //左に行って削除不良
            if (Enemys[1].transform.position.x <= -10)
            {
                Debug.Log("削除");
                Destroy(Enemys[1]);
            }
        }

    }
}
