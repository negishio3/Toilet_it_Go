using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainMove_sanoki : MonoBehaviour {

    public GameObject UNKOman;//キャラクター
    float UNKOman_Speed = 4;  //キャラクターの移動速度
    public GameObject[] BackImagePrefab;//ステージのプレハブ
    Vector3 InstansPos = new Vector2(60,0);//生成位置
    public float scrollSpeed = 1;//スクロールの速度
    GameObject[] image = new GameObject[2];//生成したステージを管理する
    bool moveFlg;//背景を止めるか否か
    public int stageCount = 0;//生成された背景のカウンター
    public int maxScrollNum;//生成する背景の最大値
    public float maxScrollTime;//生成し続ける時間

    public float timer;
    bool isCountDown;

	void Start () {
        isCountDown = false;
        TrainImageInstans(0);//初期背景の生成
    }
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameStart();
        }
        if (image[0].transform.position.x <= -60)
        {
            if (stageCount >= maxScrollNum)
            {
                TrainImageInstans(2);
            }
            else
            {
                TrainImageInstans(1);
            }
        }
        if (image[1].transform.position.x <= -60)
        {
            if (stageCount >= maxScrollNum)
            {
                TrainImageInstans(2);
            }
            else
            {
                TrainImageInstans(1);
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            scrollSpeed = 3;
        }
        if(Input.GetMouseButtonUp(0))
        {
            scrollSpeed = 10;
        }
        //if (stageCount>maxScrollNum)
        if(timer > maxScrollTime)
        {
            scrollSpeed = 3;
            //moveFlg = false;
        }
        StartCoroutine(TrainMoving());
        UNKOman.transform.position += new Vector3(Time.deltaTime * Input.GetAxisRaw("Horizontal") * UNKOman_Speed,0);
	}

    /// <summary>
    /// ゲームを開始する簡易メソッド
    /// </summary>
    public void GameStart()
    {
        moveFlg = true;
        StartCoroutine(Timer(maxScrollTime));
    }

    /// <summary>
    /// ステージの生成
    /// </summary>
    /// <param name="ImageNum">番号によって生成方法を変える(整数)</param>
    void TrainImageInstans(int ImageNum)
    {
        switch (ImageNum)
        {
            case 0: //初期生成
                image[0] = Instantiate(
                    BackImagePrefab[0],
                    Vector2.zero,
                    Quaternion.identity);
                stageCount++;
                image[1] = Instantiate(
                        BackImagePrefab[1],
                        InstansPos,
                        Quaternion.identity);
                break;
            case 1: //ループ生成
                if (image[0].transform.position.x <= -60)
                {
                    Destroy(image[0]);
                    image[0] = Instantiate(
                        BackImagePrefab[0],
                        InstansPos,
                        Quaternion.identity);
                }
                if (image[1].transform.position.x <= -60)
                {
                    Destroy(image[1]);
                    image[1] = Instantiate(
                        BackImagePrefab[1],
                        InstansPos,
                        Quaternion.identity);
                }
                break;
            case 2: //ゴール生成
                if (BackImagePrefab.Length <= ImageNum)
                {
                    Debug.LogError("ゴールプレハブが登録されてないよ");
                    break;
                }
                if (image[0].transform.position.x <= -60)
                {
                    Destroy(image[0]);
                    image[0] = Instantiate(
                      BackImagePrefab[2],
                      InstansPos,
                      Quaternion.identity);
                }
                if (image[1].transform.position.x <= -60)
                {
                    Destroy(image[1]);
                    image[1] = Instantiate(
                      BackImagePrefab[2],
                      InstansPos,
                      Quaternion.identity);
                }
                break;
        }
        stageCount++;
    }
    /// <summary>
    /// 背景を動かす
    /// </summary>
    /// <returns></returns>
    public IEnumerator TrainMoving()
    {
        if (!moveFlg)//moveFlgがfalseなら中断
            yield break;
        image[0].transform.position -= new Vector3(Time.deltaTime * scrollSpeed, image[0].transform.position.y, 0);//ひたすら左に進む
        image[1].transform.position -= new Vector3(Time.deltaTime * scrollSpeed, image[1].transform.position.y, 0);
        yield return null;
    }

    /// <summary>
    /// 時間経過をカウントする
    /// </summary>
    /// <param name="seconds">指定した秒数カウントする</param>
    /// <returns></returns>
    public IEnumerator Timer(float seconds)
    {
        if (isCountDown) yield break;
        isCountDown = true;
        timer = 0;
        float time = 0;

        while (time < 1.0f)
        {
            time += Time.deltaTime / seconds;
            timer += Time.deltaTime;
            yield return null;
        }
        isCountDown = false;
    }
}
