using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainMove_sanoki : MonoBehaviour {

    public GameObject UNKOman;//キャラクター
    float UNKOman_Speed = 4;  //キャラクターの移動速度

    public float scrollSpeed = 0;//スクロールの速度
    bool moveFlg;//背景を止めるか否か

    public GameObject[] BackImagePrefab;//ステージのプレハブ
    Vector3 InstansPos = new Vector2(60,0);//生成位置
    GameObject[] image = new GameObject[2];//生成したステージを管理する
    public int stageCount = 0;//生成された背景のカウンター

    int ImageSelector;

    //public int maxScrollNum;//生成する背景の最大値
    public float maxScrollTime;//生成し続ける時間

    public float timer;
    bool isCountDown;

    enum TrainState
    {
        FirstInstans,
        Loop,
        Goal
    }

	void Start () {
        isCountDown = false;
        moveFlg = true;
        TrainImageInstans(TrainState.FirstInstans);//初期背景の生成
    }
	
	void Update () {
        System.Random r = new System.Random();
        ImageSelector = r.Next((int)TrainState.Goal);
        if (image[0].transform.position.x <= -60)
        {
            //if (stageCount >= maxScrollNum)
            if (timer >= maxScrollTime)
            {
                TrainImageInstans(TrainState.Goal);
                if (image[0].transform.position.x <= 0)
                    moveFlg = false;
            }
            else
            {
                TrainImageInstans(TrainState.Loop);
            }
        }
        if (image[1].transform.position.x <= -60)
        {
            //if (stageCount >= maxScrollNum)
            if (timer >= maxScrollTime)
            {
                TrainImageInstans(TrainState.Goal);
                if (image[1].transform.position.x <= 0)
                    moveFlg = false;
            }
            else
            {
                TrainImageInstans(TrainState.Loop);
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            scrollSpeed = 6;
            StartCoroutine(Timer(maxScrollTime));

        }
        if (Input.GetMouseButtonUp(0))
        {
            scrollSpeed = 0;
        }
        //if (stageCount>maxScrollNum)
        //if(timer >= maxScrollTime)
        //{
        //    scrollSpeed = 3;
        //    //moveFlg = false;
        //}
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
    /// ステージの生成方法の選択
    /// </summary>
    /// <param name="ImageNum">番号によって生成方法を変える(整数)</param>
    void TrainImageInstans(TrainState State)
    {
        
        switch (State)
        {
            case TrainState.FirstInstans: //初期生成
                image[0] = Instantiate(
                    BackImagePrefab[ImageSelector],
                    Vector2.zero,
                    Quaternion.identity);
                stageCount++;
                image[1] = Instantiate(
                        BackImagePrefab[ImageSelector],
                        InstansPos,
                        Quaternion.identity);
                break;
            case TrainState.Loop: //ループ生成
                if (image[0].transform.position.x <= -60)
                {
                    Destroy(image[0]);
                    image[0] = Instantiate(
                        BackImagePrefab[ImageSelector],
                        InstansPos,
                        Quaternion.identity);
                }
                if (image[1].transform.position.x <= -60)
                {
                    Destroy(image[1]);
                    image[1] = Instantiate(
                        BackImagePrefab[ImageSelector],
                        InstansPos,
                        Quaternion.identity);
                }
                break;
            case TrainState.Goal: //ゴール生成
                if (BackImagePrefab.Length <= (int)TrainState.Goal)
                {
                    Debug.LogError("ゴールプレハブが登録されてないよ");
                    break;
                }
                if (image[0].transform.position.x <= -60)
                {
                    Destroy(image[0]);
                    image[0] = Instantiate(
                      BackImagePrefab[(int)TrainState.Goal],
                      InstansPos,
                      Quaternion.identity);
                }
                if (image[1].transform.position.x <= -60)
                {
                    Destroy(image[1]);
                    image[1] = Instantiate(
                      BackImagePrefab[(int)TrainState.Goal],
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
