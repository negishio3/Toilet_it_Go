using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainMove_sanoki : MonoBehaviour
{
    DoorMove_mase doorMase;

    public int MethodCounter;

    public Yankee_nishiwaki yankee;
    bool yankeepunch = false;

    public TimeCount_murata TimeCount_m;//村田パイセンのスクリプトを取得
    public GameObject UNKOman;//キャラクター
    float UNKOman_Speed = 4;  //キャラクターの移動速度

    //スクロールの速度
    float scrollSpeed = 0.8f;//ステージ
    float BackImage_scrollSpeed = 4;//背景
    float Pole_scrollSpeed = 16;//電柱

    bool moveFlg;//背景を止めるか否か

    public GameObject[] TrainPrefab;//ステージのプレハブ
    public GameObject GoalTrainPrefab;
    public GameObject BackImagePrefab;//背景のプレハブ
    public GameObject PolePrefab;//電柱のプレハブ
    SpriteRenderer renderer; //ゲームシーン上でのサイズを取得する用

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



    public int maxScrollNum;//生成する背景の最大値
    public int stageCount = 0;//生成された背景のカウンター
    public int CountCounter;

    bool isCenter;
    public bool PauseFlg = true;
    bool isScroll;

    Vector2 StartPos_first;
    Vector2 ScrollPos_first;

    Vector2 StartPos_second;
    Vector2 ScrollPos_second;

    Vector2 StartPos_Character;
    Vector2 ScrollPos_Character;

    float maxDistance = 10;
    public LayerMask layerMask;

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

    enum SetPosName
    {
        First,
        Second,
        Character
    }
    void Start()
    {

        doorMase = FindObjectOfType<DoorMove_mase>();
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

        StartCoroutine(BackImageMoving());

        //GameStart();

    }

    void Update()
    {
        Ray ray = new Ray(Vector2.zero, transform.forward);
        RaycastHit2D hit;
        hit = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction, maxDistance, layerMask);
        if (hit.collider)
        {
            isCenter = true;
            //doorMase.SetPos();
        }

        if (TrainImage[0] == null || TrainImage[1] == null)
        {
            if (stageCount == maxScrollNum - 1)
            {
                TrainImageInstans(TrainState.Goal);
            }
            else
            {
                TrainImageInstans(TrainState.Loop);
            }
        }
        else if (TrainImage[0].transform.position.x <= -TrainSizeX || TrainImage[1].transform.position.x <= -TrainSizeX)
        {
            TrainDestry();
        }
        if (BackImage[0].transform.position.x <= -BackImageSizeX || BackImage[1].transform.position.x <= -BackImageSizeX)
        {
            BackImageInstans(BackImageState.Loop);
        }
        if (Pole[0].transform.position.x <= -PoleSizeX || Pole[1].transform.position.x <= -PoleSizeX)
        {
            PoleInstans(BackImageState.Loop);
        }
    }

    /// <summary>
    /// ゲームを開始する簡易メソッド
    /// </summary>
    public void GameStart()
    {
        Action();
        TimeCount_m.SetTime();
    }

    /// <summary>
    /// ステージの生成方法の選択
    /// </summary>
    /// <param name="ImageNum">番号によって生成方法を変える(整数)</param>
    void TrainImageInstans(TrainState State)
    {
        MethodCounter++;
        System.Random r = new System.Random();//乱数ジェネレータ;
        int ImageSelector = r.Next(TrainPrefab.Length);//ランダムでプレハブを選択する

        switch (State)
        {
            case TrainState.FirstInstans: //初期生成
                TrainImage[0] = Instantiate(   //image[0]に生成したオブジェクトを登録
                    TrainPrefab[ImageSelector],
                    Vector2.zero,
                    Quaternion.identity);
                ImageSelector = r.Next(TrainPrefab.Length - 1);
                TrainImage[1] = Instantiate(
                        TrainPrefab[ImageSelector],
                        TrainInstansPos,
                        Quaternion.identity);
                SetScrollPos(SetPosName.First, TrainImage[0].transform.position);//スクロール先の座標を設定
                SetScrollPos(SetPosName.Second, TrainImage[1].transform.position);
                CountCounter += 2;
                stageCount += 2;
                break;
            case TrainState.Loop: //ループ生成
                if (TrainImage[0] == null)
                {
                    TrainImage[0] = Instantiate(
                        TrainPrefab[ImageSelector],
                        TrainInstansPos,
                        Quaternion.identity);
                    TrainImage[0].transform.position = new Vector2(TrainImage[1].transform.position.x + TrainSizeX, 0);//隙間の調整
                }
                if (TrainImage[1] == null)
                {
                    TrainImage[1] = Instantiate(
                        TrainPrefab[ImageSelector],
                        TrainInstansPos,
                        Quaternion.identity);
                    TrainImage[1].transform.position = new Vector2(TrainImage[0].transform.position.x + TrainSizeX, 0);
                }
                stageCount++;
                break;
            case TrainState.Goal: //ゴール生成
                if (TrainImage[0] == null)
                {
                    TrainImage[0] = Instantiate(
                      GoalTrainPrefab,
                      TrainInstansPos,
                      Quaternion.identity);
                    TrainImage[0].transform.position = new Vector2(TrainImage[1].transform.position.x + TrainSizeX, 0);
                }
                if (TrainImage[1] == null)
                {
                    TrainImage[1] = Instantiate(
                      GoalTrainPrefab,
                      TrainInstansPos,
                      Quaternion.identity);
                    TrainImage[1].transform.position = new Vector2(TrainImage[0].transform.position.x + TrainSizeX, 0);
                }
                stageCount++;
                break;
        }
    }

    void TrainDestry()
    {
        if (TrainImage[0].transform.position.x <= -TrainSizeX)
        {
            Destroy(TrainImage[0]);
            SetScrollPos(SetPosName.First, TrainInstansPos);
        }
        if (TrainImage[1].transform.position.x <= -TrainSizeX)
        {
            Destroy(TrainImage[1]);
            SetScrollPos(SetPosName.Second, TrainInstansPos);
        }
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
        while (true)
        {
            BackImage[0].transform.position -= new Vector3(Time.deltaTime * BackImage_scrollSpeed, BackImage[0].transform.position.y, 0);
            BackImage[1].transform.position -= new Vector3(Time.deltaTime * BackImage_scrollSpeed, BackImage[1].transform.position.y, 0);

            Pole[0].transform.position -= new Vector3(Time.deltaTime * Pole_scrollSpeed, Pole[0].transform.position.y, 0);
            Pole[1].transform.position -= new Vector3(Time.deltaTime * Pole_scrollSpeed, Pole[1].transform.position.y, 0);

            yield return null;
        }
    }


    /// <summary>
    /// これが呼ばれることによって動く
    /// </summary>
    public void TrainMoving()
    {
        if (yankeepunch == false)
        {
            if (!PauseFlg && !isScroll)
            {
                isScroll = true;
                StartCoroutine(TrainScroll());
            }
        }
    }

    public IEnumerator TrainScroll()
    {
        float seconds = 0.05f;
        float time = 0;

        if (!isCenter)
        {
            while (time <= 1.0f)
            {
                time += Time.deltaTime / seconds;

                TrainImage[0].transform.position = Vector2.Lerp(StartPos_first, ScrollPos_first, time);
                TrainImage[1].transform.position = Vector2.Lerp(StartPos_second, ScrollPos_second, time);

                yield return null;
            }
            SetScrollPos(SetPosName.First, TrainImage[0].transform.position);
            SetScrollPos(SetPosName.Second, TrainImage[1].transform.position);
        }
        else
        {
            SetScrollPos(SetPosName.Character, UNKOman.transform.position);
            while (time <= 1.0f)
            {
                time += Time.deltaTime / seconds;
                UNKOman.transform.position = Vector2.Lerp(StartPos_Character, ScrollPos_Character, time);

                yield return null;
            }
            SetScrollPos(SetPosName.Character, UNKOman.transform.position);
        }
        isScroll = false;
    }

    public void Pause()
    {
        PauseFlg = true;
    }
    public void Action()
    {
        PauseFlg = false;
    }

    /// <summary>
    /// スクロールする座標を設定する
    /// </summary>
    /// <param name="Name">座標を設定したい方の番号</param>
    /// <param name="StartPos">設定する座標(移動先は自動設定)</param>
    void SetScrollPos(SetPosName Name, Vector2 StartPos)
    {
        switch (Name)
        {
            case SetPosName.First:
                StartPos_first = StartPos;
                ScrollPos_first = new Vector2(StartPos.x - scrollSpeed, StartPos.y);
                break;
            case SetPosName.Second:
                StartPos_second = StartPos;
                ScrollPos_second = new Vector2(StartPos.x - scrollSpeed, StartPos.y);
                break;
            case SetPosName.Character:
                StartPos_Character = StartPos;
                ScrollPos_Character = new Vector2(StartPos.x + scrollSpeed, StartPos.y);
                break;
        }
    }

    public bool Yankeepunch
    {
        get { return yankeepunch; }
        set { yankeepunch = value; }
    }
}
