using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainMove_sanoki : MonoBehaviour {

    public TimeCount_murata TimeCount_m;
    public GameObject UNKOman;//キャラクター
    float UNKOman_Speed = 4;  //キャラクターの移動速度

    public float scrollSpeed;//スクロールの速度
    bool moveFlg;//背景を止めるか否か

    public GameObject[] BackImagePrefab;//ステージのプレハブ
    new SpriteRenderer renderer; //ゲームシーン上でのサイズを取得する用
    float sizeX;//サイズを保存する

    Vector3 InstansPos;//初期生成位置
    GameObject[] image = new GameObject[2];//生成したステージを管理する
    public int stageCount = 0;//生成された背景のカウンター

    int ImageSelector;

    public int maxScrollNum;//生成する背景の最大値
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
        renderer = BackImagePrefab[0].GetComponent<SpriteRenderer>();
        sizeX = renderer.bounds.size.x;
        InstansPos = new Vector2(sizeX, 0);//生成位置
        isCountDown = false;
        moveFlg = false;
        TrainImageInstans(TrainState.FirstInstans);//初期背景の生成
    }
	
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TimeCount_m.SetTime();
            GameStart();
        }
            
        if (image[0].transform.position.x <= -sizeX || image[1].transform.position.x <= -sizeX)
        {
            if (stageCount == maxScrollNum)
            //if (timer >= maxScrollTime)
            {
                TrainImageInstans(TrainState.Goal);
            }
            else
            {
                TrainImageInstans(TrainState.Loop);
            }
        }
        //if (timer >= maxScrollTime && image[1].transform.position.x <= 0)
        //            moveFlg = false;
        if (Input.GetMouseButton(0))
        {
            //scrollSpeed = 0;
            moveFlg = false;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            //moveFlg = true;
            MoveChange();
            scrollSpeed = 6;
            StartCoroutine(Timer(maxScrollTime));
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
        scrollSpeed = 6;
        StartCoroutine(Timer(maxScrollTime));
    }

    /// <summary>
    /// ステージの生成方法の選択
    /// </summary>
    /// <param name="ImageNum">番号によって生成方法を変える(整数)</param>
    void TrainImageInstans(TrainState State)
    {
        moveFlg = false;
        System.Random r = new System.Random();//乱数ジェネレータ
        ImageSelector = r.Next(BackImagePrefab.Length-1);//最後のプレハブがゴールプレハブに当たるので最大値-１する
        switch (State)
        {
            case TrainState.FirstInstans: //初期生成
                image[0] = Instantiate(
                    BackImagePrefab[ImageSelector],
                    Vector2.zero,
                    Quaternion.identity);
                stageCount++;
                ImageSelector = r.Next(BackImagePrefab.Length - 1);
                image[1] = Instantiate(
                        BackImagePrefab[ImageSelector],
                        InstansPos,
                        Quaternion.identity);
                break;
            case TrainState.Loop: //ループ生成
                if (image[0].transform.position.x <= -sizeX)//画面外に出たら削除して生成し直す処理
                {
                    Destroy(image[0]);
                    image[0] = Instantiate(
                        BackImagePrefab[ImageSelector],
                        InstansPos,
                        Quaternion.identity);
                }
                if (image[1].transform.position.x <= -sizeX)
                {
                    Destroy(image[1]);
                    image[1] = Instantiate(
                        BackImagePrefab[ImageSelector],
                        InstansPos,
                        Quaternion.identity);
                }
                break;
            case TrainState.Goal: //ゴール生成
                if (image[0].transform.position.x <= -sizeX)
                {
                    Destroy(image[0]);
                    image[0] = Instantiate(
                      BackImagePrefab[BackImagePrefab.Length-1],
                      InstansPos,
                      Quaternion.identity);
                }
                if (image[1].transform.position.x <= -sizeX)
                {
                    Destroy(image[1]);
                    image[1] = Instantiate(
                      BackImagePrefab[BackImagePrefab.Length-1],
                      InstansPos,
                      Quaternion.identity);
                }
                break;
        }
        stageCount++;
        moveFlg = true;
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
    /// 時間経過をカウントする(デバッグ用)
    /// </summary>
    /// <param name="seconds">指定した秒数カウントする</param>
    /// <returns></returns>
    public IEnumerator Timer(float seconds)
    {
        if (isCountDown) yield break;
        isCountDown = true;
        timer = 0;//経過時間をリセット
        float time = 0;

        while (time < seconds)
        {
            time += Time.deltaTime;
            timer += Time.deltaTime;
            yield return null;
        }
        isCountDown = false;
    }

    /// <summary>
    /// 外部からmoveFlgをtrueに変更する
    /// </summary>
    public void MoveChange()
    {
        moveFlg = true;
    }
}
