using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

    float move = 0.1f;
    GameObject[] Enemys=new GameObject[2];
    public GameObject[] Enemy;
    public float time=0.0f;

    void Start()
    {
       // Debug.Log("スタート");
        //this.transform.position = new Vector3(10f, 0, 0);
    }


    void Update()
    {
        time += Time.deltaTime;
        if (time >= 5)
        {
            Enemys[0] = Instantiate(Enemy[0], new Vector3(10f, 0, 0), Quaternion.identity);
            Enemys[1] = Instantiate(Enemy[1], new Vector3(10f, 0, 0), Quaternion.identity);

            time = 0;
        }

        if (Enemys[0] != null)
        {
            //Debug.Log("移動");

            Enemys[0].transform.position -= new Vector3(move, 0, 0);

            if (Enemys[0].transform.position.x <= -10)
            {
                Debug.Log("削除");
                Destroy(Enemys[0]);
            }
        }

        if (Enemys[1] != null)
        {
            //Debug.Log("移動");

            Enemys[1].transform.position -= new Vector3 (move,0,0);

            if (Enemys[1].transform.position.x <= -10)
            {
                Debug.Log("削除");
                Destroy(Enemys[1]);
            }
        }

    }
}
