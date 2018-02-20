using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainMove_sanoki : MonoBehaviour {

    public TimeCount_murata TimeCount_m;//村田パイセンのスクリプトを取得
    public GameObject UNKOman;//キャラクター
    float UNKOman_Speed = 4;  //キャラクターの移動速度
    
    //スクロールの速度
    float scrollSpeed = 0.5f;//ステージ
    float BackImage_scrollSpeed = 4;//背景
    float Pole_scrollSpeed = 16;//電柱

    bool moveFlg;//背景を止めるか否か

    public GameObject[] TrainPrefab;//ステージのプレハブ
    public GameObject BackImagePrefab;//背景のプレハブ
    public GameObject PolePrefab;//電柱のプレハブ
    new SpriteRenderer renderer; //ゲームシーン上でのサイズを取得する用

    //画像サイズを保存する
    float TrainSizeX;//電車のサイズを保存する
    float BackImageSizeX;//背景のサイズを保存する
    float PoleSizeX;//電柱のサイズを保存する
    
    //初期生成位置
    Vector3 TrainInstansPos;//ステージ
    Vector3 BackImageInstansPos;//背景
    Vector3 PoleInstansPos;//電柱
    
    //生成したステージを管理する
    GameObject[] TrainImage = new GameObject[2];
    GameObject[] BackImage = new GameObject[2];
    GameObject[] Pole = new GameObject[2];

    public int stageCount = 0;//生成された背景のカウンター

    int ImageSelector;

    public int maxScrollNum;//生成する背景の最大値
    public float maxScrollTime;//生成し続ける時間

    public float timer;
    bool isCountDown;
    public bool buttonFlg;
    public bool isGame;

    Vector2 StartPos_first;
    Vector2 ScrollPos_first;

    Vector2 StartPos_second;
    Vector2 ScrollPos_second;

    /// <summary>
    /// ステージプレファブ用
    /// </summary>
    enum TrainState
    {
        FirstInstans,//初期生成
        Loop,//ループ生成
        Goal//ゴール生成
    }

    /// <summary>
    /// 背景用
    /// </summary>
    enum BackImageState
    {
        FirstInstans,//初期生成
        Loop//ループ生成
    }

    void Start() {
        //サイズの取得---------------------------------------------------------------------------------------
        renderer = TrainPrefab[0].GetComponent<SpriteRenderer>();//BackImagePrefab[0]のSpriteRendererを取得
        TrainSizeX = renderer.bounds.size.x;//生成したときの画像サイズを取得
        renderer = BackImagePrefab.GetComponent<SpriteRenderer>();
        BackImageSizeX = renderer.bounds.size.x;//生成したときの画像サイズを取得
        renderer = PolePrefab.GetComponent<SpriteRenderer>();
        PoleSizeX = renderer.bounds.size.x;//生成したときの画像サイズを取得

        //生成位置の登録-------------------------------------------------------------------------------------
        TrainInstansPos = new Vector2(TrainSizeX, 0);//生成位置の更新
        BackImageInstansPos = new Vector2(BackImageSizeX, 0);
        PoleInstansPos = new Vector2(PoleSizeX, 0);

        //初期生成-------------------------------------------------------------------------------------------
        TrainImageInstans(TrainState.FirstInstans);//初期背景の生成
        BackImageInstans(BackImageState.FirstInstans);
        PoleInstans(BackImageState.FirstInstans);

        buttonFlg = false;
    }
	
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TimeCount_m.SetTime();
            GameStart();
        }
            
        if (TrainImage[0].transform.position.x <= -TrainSizeX || TrainImage[1].transform.position.x <= -TrainSizeX )
        {
            if (stageCount == maxScrollNum-1)
            {
                TrainImageInstans(TrainState.Goal);
            }
            else
            {
                TrainImageInstans(TrainState.Loop);
            }
        }
        if(BackImage[0].transform.position.x <= -BackImageSizeX || BackImage[1].transform.position.x <= -BackImageSizeX)
        {
            BackImageInstans(BackImageState.Loop);
        }
        if (Pole[0].transform.position.x <= -PoleSizeX || Pole[1].transform.position.x <= -PoleSizeX)
        {
            PoleInstans(BackImageState.Loop);
        }
        //if (stageCount >= maxScrollNum && (TrainImage[1].transform.position.x <= 0 || TrainImage[0].transform.position.x <= 0))
        //{
        //    Debug.Log("よべた");
        //    moveFlg = false;
        //}
        //if (isGame && Input.GetMouseButton(0))
        //{
        //    moveFlg = false;
        //    scrollSpeed = 0;
        //    //moveFlg = false;
        //}
        //else if( isGame && Input.GetMouseButtonUp(0))
        //{
        //    moveFlg = true;
        //    scrollSpeed = 6;
        //    StartCoroutine(Timer(maxScrollTime));
        //}
        StartCoroutine(BackImageMoving());
        UNKOman.transform.position += new Vector3(Time.deltaTime * Input.GetAxisRaw("Horizontal") * UNKOman_Speed,0);
	}

    /// <summary>
    /// ゲームを開始する簡易メソッド
    /// </summary>
    public void GameStart()
    {
        moveFlg = true;
        isGame = true;
        scrollSpeed = 6;
        BackImage_scrollSpeed = 2;
        Pole_scrollSpeed = 11;
        StartCoroutine(Timer(maxScrollTime));
    }

    /// <summary>
    /// ステージの生成方法の選択
    /// </summary>
    /// <param name="ImageNum">番号によって生成方法を変える(整数)</param>
    void TrainImageInstans(TrainState State)
    {
        System.Random r = new System.Random();//乱数ジェネレータ
        ImageSelector = r.Next(TrainPrefab.Length-1);//最後のプレハブがゴールプレハブに当たるので最大値-１する

        switch (State)
        {
            case TrainState.FirstInstans: //初期生成
                TrainImage[0] = Instantiate(   //image[0]に生成したオブジェクトを登録
                    TrainPrefab[ImageSelector],
                    Vector2.zero,
                    Quaternion.identity);
                stageCount++;
                ImageSelector = r.Next(TrainPrefab.Length - 1);
                TrainImage[1] = Instantiate(
                        TrainPrefab[ImageSelector],
                        TrainInstansPos,
                        Quaternion.identity);
                StartPos_first = TrainImage[0].transform.position;//スクロールの開始位置を設定
                StartPos_second = TrainImage[1].transform.position;
                ScrollPos_first = new Vector2(                    //スクロール先の位置を設定
                                    TrainImage[0].transform.position.x - scrollSpeed,
                                    TrainImage[0].transform.position.y);
                ScrollPos_second = new Vector2(
                                    TrainImage[1].transform.position.x - scrollSpeed,
                                    TrainImage[1].transform.position.y);
                break;
            case TrainState.Loop: //ループ生成
                if (TrainImage[0].transform.position.x <= -TrainSizeX)//画面外に出たら削除して生成し直す処理
                {
                    Destroy(TrainImage[0]);
                    TrainImage[0] = Instantiate(
                        TrainPrefab[ImageSelector],
                        TrainInstansPos,
                        Quaternion.identity);
                    TrainImage[0].transform.position = new Vector2(TrainImage[1].transform.position.x + TrainSizeX,0);//隙間の調整
                }
                if (TrainImage[1].transform.position.x <= -TrainSizeX)
                {
                    Destroy(TrainImage[1]);
                    TrainImage[1] = Instantiate(
                        TrainPrefab[ImageSelector],
                        TrainInstansPos,
                        Quaternion.identity);
                    TrainImage[1].transform.position = new Vector2(TrainImage[0].transform.position.x + TrainSizeX, 0);
                }
                break;
            case TrainState.Goal: //ゴール生成
                if (TrainImage[0].transform.position.x <= -TrainSizeX)
                {
                    Destroy(TrainImage[0]);
                    TrainImage[0] = Instantiate(
                      TrainPrefab[TrainPrefab.Length-1],
                      TrainInstansPos,
                      Quaternion.identity);
                    TrainImage[0].transform.position = new Vector2(TrainImage[1].transform.position.x + TrainSizeX, 0);
                }
                if (TrainImage[1].transform.position.x <= -TrainSizeX)
                {
                    Destroy(TrainImage[1]);
                    TrainImage[1] = Instantiate(
                      TrainPrefab[TrainPrefab.Length-1],
                      TrainInstansPos,
                      Quaternion.identity);
                    TrainImage[1].transform.position = new Vector2(TrainImage[0].transform.position.x + TrainSizeX, 0);
                }
                break;
        }
        stageCount++;
    }

    /// <summary>
    /// 背景画像の生成用
    /// </summary>
    /// <param name="state">生成方法</param>
    void BackImageInstans(BackImageState state)
    {
        switch (state)
        {
            case BackImageState.FirstInstans:
                BackImage[0] = Instantiate(   //BackImage[0]に生成したオブジェクトを登録
                  BackImagePrefab,
                  Vector2.zero,
                  Quaternion.identity);
                BackImage[1] = Instantiate(
                        BackImagePrefab,
                        BackImageInstansPos,
                        Quaternion.identity);
                break;
            case BackImageState.Loop:
                if (BackImage[0].transform.position.x <= -BackImageSizeX)//画面外に出たら削除して生成し直す処理
                {
                    Destroy(BackImage[0]);
                    BackImage[0] = Instantiate(
                        BackImagePrefab,
                        BackImageInstansPos,
                        Quaternion.identity);
                    BackImage[0].transform.position = new Vector2(BackImage[1].transform.position.x + BackImageSizeX, 0);//隙間の調整
                }
                if (BackImage[1].transform.position.x <= -BackImageSizeX)
                {
                    Destroy(BackImage[1]);
                    BackImage[1] = Instantiate(
                        BackImagePrefab,
                        BackImageInstansPos,
                        Quaternion.identity);
                    BackImage[1].transform.position = new Vector2(BackImage[0].transform.position.x + BackImageSizeX, 0);
                }
                break;
        }
    }
    /// <summary>
    /// 電信柱の生成用
    /// </summary>
    /// <param name="state">生成方法</param>
    void PoleInstans(BackImageState state)
    {
        switch (state)
        {
            case BackImageState.FirstInstans:
                Pole[0] = Instantiate(   //BackImage[0]に生成したオブジェクトを登録
                  PolePrefab,
                  Vector2.zero,
                  Quaternion.identity);
                Pole[1] = Instantiate(
                        PolePrefab,
                        PoleInstansPos,
                        Quaternion.identity);
                break;
            case BackImageState.Loop:
                if (Pole[0].transform.position.x <= -PoleSizeX)//画面外に出たら削除して生成し直す処理
                {
                    Destroy(Pole[0]);
                    Pole[0] = Instantiate(
                        PolePrefab,
                        PoleInstansPos,
                        Quaternion.identity);
                    Pole[0].transform.position = new Vector2(Pole[1].transform.position.x + PoleSizeX, 0);//隙間の調整
                }
                if (Pole[1].transform.position.x <= -PoleSizeX)
                {
                    Destroy(Pole[1]);
                    Pole[1] = Instantiate(
                        PolePrefab,
                        PoleInstansPos,
                        Quaternion.identity);
                    Pole[1].transform.position = new Vector2(Pole[0].transform.position.x + PoleSizeX, 0);
                }
                break;
        }
    }

    /// <summary>
    /// 背景を動かす
    /// </summary>
    /// <returns></returns>
    public IEnumerator BackImageMoving()
    {
        BackImage[0].transform.position -= new Vector3(Time.deltaTime * BackImage_scrollSpeed, BackImage[0].transform.position.y, 0);
        BackImage[1].transform.position -= new Vector3(Time.deltaTime * BackImage_scrollSpeed, BackImage[1].transform.position.y, 0);

        Pole[0].transform.position -= new Vector3(Time.deltaTime * Pole_scrollSpeed, Pole[0].transform.position.y, 0);
        Pole[1].transform.position -= new Vector3(Time.deltaTime * Pole_scrollSpeed, Pole[1].transform.position.y, 0);
        yield return null;
    }

    public void TrainMoving()
    {
        if (!buttonFlg)
        { 
            ScrollPos_first = new Vector2(ScrollPos_first.x - scrollSpeed, TrainImage[0].transform.position.y);//スクロール先の位置を更新
            ScrollPos_second = new Vector2(ScrollPos_second.x - scrollSpeed, TrainImage[1].transform.position.y);
            StartCoroutine(TrainScroll(0.05f));
            buttonFlg = true;
        }
    }

    public IEnumerator TrainScroll(float seconds)
    { 

        float time = 0;
        while (time <= 1.0f)
        {
            time += Time.deltaTime / seconds;
            TrainImage[0].transform.position = Vector2.Lerp(StartPos_first, ScrollPos_first, time);
            TrainImage[1].transform.position = Vector2.Lerp(StartPos_second, ScrollPos_second, time);
            yield return null;
        }
        StartPos_first = TrainImage[0].transform.position;
        ScrollPos_first = new Vector2(TrainImage[0].transform.position.x - scrollSpeed, TrainImage[0].transform.position.y);
        StartPos_second = TrainImage[1].transform.position;
        ScrollPos_second = new Vector2(TrainImage[1].transform.position.x - scrollSpeed, TrainImage[1].transform.position.y);
        buttonFlg = false;
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
    public void moveving()
    {
        moveFlg = true;
        //scrollSpeed = 6;
    }

    public void Stop()
    {
        moveFlg = false;
    }

    /// <summary>
    /// ボタン用のmoveFlgを切り替える
    /// </summary>
   public void ButtonFlgChange()
    {
        buttonFlg = !buttonFlg;
    }
}
