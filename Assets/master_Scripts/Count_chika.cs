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
    public Image start;           //スタート待機Image
    public Image TTS;
    public Text Stxt;            //スタート前のテキスト

    bool startflg = false;         //開始フラグ
    bool startOK = false;
    bool textset = false; 


    //文字送り用変数
    public string[] scenarios = new string[1];

    [SerializeField]
    [Range(0.001f, 0.3f)]
    float intervalTxt = 0.05f;

    private string currentText = string.Empty;
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

    }

    void flgCahnge()
    {
        startflg = !startflg;
    }

    // Update is called once per frame
    void Update () {
        if (!SceneFader_sanoki.isFade)
            startflg = true;
        if (startflg)
        {
            // 待機Imageをアクティブに
            start.gameObject.SetActive(true);


            // 文字送り(ほとんど引用ママ)
            if (textset == true)//文字送り開始
            {
                SetNextLine();
                textset = false;
            }

            // 文字の表示が完了してるならクリック時に次の行を表示する
            if (IsCompleteDisplayText)
            {   // 
                if (currentLine < scenarios.Length && Input.GetMouseButtonDown(0))
                {
                    startOK = true;
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
                Stxt.text = currentText.Substring(0, TextCount);
                lastUpdateCharacter = TextCount;
            }
            //*文字送りここまで

            if (startOK == true)
            {
                //タップで邪魔な待機Imageを削除してゲームスタート
                if (Input.GetMouseButtonUp(0))
                {
                    start.gameObject.SetActive(false);
                    GameObject.Destroy(start);
                    Train_game.GameStart();
                    startflg = false;
                }
            }

        }

    }
    //型呼び出し
    void SetNextLine()
    {
        currentText = scenarios[0];
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
