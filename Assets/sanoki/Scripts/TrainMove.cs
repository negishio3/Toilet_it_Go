using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainMove : MonoBehaviour {

    public GameObject UNKOman;
    float UNKOman_Speed = 4;
    public GameObject[] BackImagePrefab;//ステージのプレハブ
    Vector3 StartPos = new Vector2(60,0);//生成位置
    public float scrollSpeed = 1;//スクロールの速度
    GameObject[] image = new GameObject[2];//生成したステージを管理する
    bool moveFlg= true;
    public int stageCount = 0;
    public int maxScrollNum;

	void Start () {

        TrainImageInstans(2);//初期背景の生成
        TrainImageInstans(1);
        //image[1] = Instantiate(
        //    BackImagePrefab[1],
        //    StartPos,
        //    Quaternion.identity);
    }
	
	void Update () {

        if (image[0].transform.position.x <= -60)
        {
            if (stageCount == maxScrollNum)
            {
                
            }
            TrainImageInstans(0);
        }
        if (image[1].transform.position.x <= -60)
        {
            TrainImageInstans(1);
        }
        if (Input.GetMouseButtonDown(0))
        {
            scrollSpeed = 3;
        }
        if(Input.GetMouseButtonUp(0))
        {
            scrollSpeed = 10;
        }
        if (stageCount==maxScrollNum)
        {
            scrollSpeed = 3;
            //moveFlg = false;
        }
        StartCoroutine(TrainMoving());
        UNKOman.transform.position += new Vector3(Time.deltaTime * Input.GetAxisRaw("Horizontal") * UNKOman_Speed,0);
	}
    /// <summary>
    /// ステージの生成
    /// </summary>
    void TrainImageInstans(int ImageNum)
    {
        switch (ImageNum)
        {
            case 0:
                Destroy(image[0]);
                image[0] = Instantiate(
                    BackImagePrefab[0],
                    StartPos,
                    Quaternion.identity);
                break;
            case 1:
                Destroy(image[1]);
                image[1] = Instantiate(
                    BackImagePrefab[1],
                    StartPos,
                    Quaternion.identity);
                break;
            case 2:
                image[0] = Instantiate(
                    BackImagePrefab[0],
                    Vector2.zero,
                    Quaternion.identity);
                break;
        }
        stageCount++;
        //if(!image[1]==null)
            
    }
    /// <summary>
    /// 背景を動かす
    /// </summary>
    /// <returns></returns>
    public IEnumerator TrainMoving()
    {
        if (!moveFlg)//moveFlgがfalseなら中断
            yield break;
        image[0].transform.position -= new Vector3(Time.deltaTime * scrollSpeed, image[0].transform.position.y, 0);
        image[1].transform.position -= new Vector3(Time.deltaTime * scrollSpeed, image[1].transform.position.y, 0);
        yield return null;
    }
}
