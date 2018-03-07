using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Count_chika : MonoBehaviour {


    //public Image countImg;      //カウントするImageオブジェクト
    //public Sprite[] imageList;  //切り替え用のスプライト

    //public int count;             //選択中のImage

    ///////////////////////////////////////////////////////////////////////

    public TrainMove_sanoki Train_game; //GameStart呼び出し
    public SceneFader_sanoki fadeflg;
    public StartWaitAlqa_chikazawa start_a;
    public Image start;           //スタート待機Image
    public Image TTS;
    public Text Stxt;            //スタート前のテキスト

    float TTS_alqa = 0.0f;

    bool startFade = false;        //
    public bool startflg = false;         //開始フラグ
    bool startOK = false;          //全準備完了
    bool TTS_Wait = true;          //TaptoStart点滅
    bool textset = false;          //テキスト取得
    bool SfadeComp = false;              

    //文字送り用変数
    public string[] scenarios = new string[5];//入力行数//全角10文字で改行
    int SerifPattern;

    [SerializeField]
    [Range(0.001f, 0.3f)]
    float intervalTxt = 0.05f;//表示速度

    private string currentText = string.Empty;//表示中テキスト
    private float timeUntilDisplay = 0;       
    private float timeElapsed = 1;            
    private int currentLine = 0;
    private int lastUpdateCharacter = -1;

    public bool IsCompleteDisplayText
    {
        get { return Time.time > timeElapsed + timeUntilDisplay; }
    }

    // Use this for initialization
    void Start () {
        //count = 0;
        //countImg.gameObject.SetActive(false);
        SerifPattern = Random.Range(0, 5);//セリフパターンからランダムに選択する
        Train_game.Pause();
    }
    // Update is called once per frame
    void Update () {
        if (fadeflg.FadeGame)//SceneFaderからフラグ情報を受け取る
        {
            startflg = true;
            Debug.Log("kakunin");
        }
        if (startflg)
        {
            // 待機Imageをアクティブに
            start.gameObject.SetActive(true);

            if (start_a.stop&& !SfadeComp)//半透明になったら文字を１回だけ取得する
            {
                textset = true;
                SfadeComp = true;
            }
            if (SfadeComp)
            {
                // 文字送り(ほとんど引用ママ)
                if (textset == true)//文字送り開始
                {
                    SetNextLine();
                    textset = false;     //取得後速やかにフラグを切る(何度も呼ぶといつまでもタイマーが動かない
                    //Debug.Log("取得完了");
                }

                // /*文字の表示が完了してるならクリック時に次の行を表示する
                if (IsCompleteDisplayText)
                {   // 
                    if (currentLine < scenarios.Length && Input.GetMouseButtonDown(0))
                    {
                        startOK = true;
                    }
                    if (TTS_Wait)
                    {
                        TTS.color = new Color(1.0f, 1.0f, 1.0f, TTS_alqa / 225.0f);
                        TTS_alqa += 150.0f * Time.deltaTime;
                    }
                    else if (!TTS_Wait)
                    {
                        TTS.color = new Color(1.0f, 1.0f, 1.0f, TTS_alqa / 225.0f);
                        TTS_alqa -= 150.0f * Time.deltaTime;
                    }
                    if (TTS_alqa >= 225.0f || TTS_alqa <= 0.0f)
                    {
                        TTS_Wait = !TTS_Wait;
                    }

                }
                else
                {
                    // 完了してないなら文字をすべて表示する
                    if (Input.GetMouseButtonDown(0))
                    {
                        timeUntilDisplay = 0;
                    }
                }
                // 文字表示カウント／何文字出すか
                int TextCount = (int)(Mathf.Clamp01((Time.time - timeElapsed)
                                                                / timeUntilDisplay) * currentText.Length);
                // 文字表示の更新
                if (TextCount != lastUpdateCharacter)
                {
                    //Debug.Log("文字入力");
                    Stxt.text = currentText.Substring(0, TextCount);
                    lastUpdateCharacter = TextCount;
                }
                // */文字送りここまで

                if (startOK == true)
                {

                    //タップで邪魔な待機Imageを削除してゲームスタート
                    if (Input.GetMouseButtonUp(0))
                    {
                        start.gameObject.SetActive(false);
                        GameObject.Destroy(start);
                        Train_game.GameStart();
                        //立っている確認用のフラグをオフにする(エラー回避)
                        fadeflg.FadeGame = false;
                        startflg = false;
                    }
                }
            }

        }

    }
    //型呼び出し
    void SetNextLine()
    {
        //Debug.Log("文字取得");
        currentText = scenarios[SerifPattern];
        //        Stxt.text = "あ・・・お腹痛い" ;

        // 想定表示時間と現在の時刻をキャッシュ
        timeUntilDisplay = currentText.Length * intervalTxt;
        timeElapsed = Time.time;

        ////文字列を初期化
        //lastUpdateCharacter = -1;
    }

    //public void OnClickButtonStart()
    //{
    //    //ボタンを押してスタート
    //    StartCoroutine(CountDown());
    //}
    ////カウントダウン
    //public IEnumerator CountDown()
    //{
    ////オブジェクトをアクティブにしてカウントスタート
    //countImg.gameObject.SetActive(true);
    //for (count = 0; count < 5 ; count++)//何回変えるか
    //{
    //    countImg.sprite = imageList[count];//画像切替
    //yield return new WaitForSeconds(1.0f);//1秒止める

    //}//終わったら非アクティブにする
    //countImg.gameObject.SetActive(false);

    //}

}
