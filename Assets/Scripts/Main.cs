using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//メイン
public class Main : MonoBehaviour
{
    // 状態定数
    enum State
    {
        Wait, // 待機
        Ready, // 準備
        Play, // プレイ
        Goal // ゴール
    };

    // 参照
    GameObject timer; // タイマー
    GameObject counter; // カウンタ
    GameObject goal; // ゴール
    GameObject car; // 車
    Rigidbody carRb; // 車Rigidbody

    // 情報
    State state; //状態
    float time; // 時間
    float count; // カウント
    float goalWaitTime; // ゴール待機時間
    float actionH; // 水平行動
    float actionV; // 垂直行動

    //チェックポイント
    const int CHECKPOINT_NUM = 3; // チェックポイント数
    int checkPointCount; // チェックポイント通過数
    int checkPointLastNo; // チェックポイント最終No

    // スタート時に呼ばれる
    void Start()
    {
        // 参照
        this.timer = GameObject.Find("Timer");
        this.counter = GameObject.Find("Counter");
        this.goal = GameObject.Find("Goal");
        this.car = GameObject.Find("Car");
        this.carRb = this.car.GetComponent<Rigidbody>();

        // 待機への遷移
        SetState(State.Wait);
    }

    // 状態の指定
    void SetState(State state)
    {
        this.state = state;

        // 待機
        if (this.state == State.Wait)
        {
            // 情報の初期化
            this.time = 0f;
            this.count = 3f;
            this.goalWaitTime = 0f;

            // チェックポイントの初期化
            this.checkPointCount = 0;
            this.checkPointLastNo = 0;

            // 参照の初期化
            this.timer.GetComponent<Text>().text = "ジョイスティック操作でスタート";
            this.counter.GetComponent<Text>().text = "" + (int)this.count;
            this.goal.GetComponent<Text>().text = "";

            // 車の初期化
            this.car.SetActive(false);
            this.car.SetActive(true);
            this.car.transform.position = new Vector3(-40f, 0f, 0f);
            this.car.transform.rotation = Quaternion.Euler(0, 0, 0);
            this.car.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            this.car.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
        }
        // 準備
        else if (this.state == State.Ready)
        {
            this.timer.GetComponent<Text>().text = "0'00\"00";
        }
        // プレイ
        else if (this.state == State.Play)
        {
            this.counter.GetComponent<Text>().text = "";
        }
        // ゴール
        else if (this.state == State.Goal)
        {
            this.goal.GetComponent<Text>().text = "GOAL";
            this.goalWaitTime = 0f;
        }
    }

    // 行動の指定
    public void SetAction(float h, float v)
    {
        this.actionH = h;
        this.actionV = v;
    }

    // フレーム毎に呼ばれる
    void FixedUpdate()
    {
        // 待機
        if (this.state == State.Wait)
        {
            // ジョイスティック操作で準備に遷移
            if (Mathf.Abs(this.actionH) > 0.01f || Mathf.Abs(this.actionV) > 0.01f)
            {
                SetState(State.Ready);
            }
        }
        // 準備
        else if (this.state == State.Ready)
        {
            // カウンタの更新
            UpdateCounter();

            // カウント後にプレイに遷移
            if (this.count < 1f)
            {
                SetState(Main.State.Play);
            }
        }
        // プレイ
        else if (this.state == State.Play)
        {
            //車の向きと加速度の更新
            if (this.actionV != 0f)
            {
                float dy = (this.actionV > 0) ? this.actionH : -this.actionH;
                this.car.transform.Rotate(0, dy, 0);
            }
            this.carRb.velocity = this.car.transform.rotation * new Vector3(0, 0, this.actionV);

            // カウンタの更新
            UpdateCounter();

            // タイマーの更新
            UpdateTimer();
        }
        // ゴール
        else if (this.state == State.Goal)
        {
            // 3秒後に待機に遷移
            this.goalWaitTime += Time.deltaTime;
            if (this.goalWaitTime > 3f)
            {
                SetState(State.Wait);
            }
        }
    }

    // カウンタの更新
    void UpdateCounter()
    {
        string text = "";
        if (this.count >= 0f)
        {
            this.count -= Time.deltaTime;
            text = "" + (int)this.count;
        }
        if (this.counter.GetComponent<Text>().text != text)
        {
            this.counter.GetComponent<Text>().text = text;
        }
    }

    // タイマーの更新
    void UpdateTimer()
    {
        this.time += Time.deltaTime;
        int minute = (int)(this.time / 60);
        int second = (int)(this.time % 60);
        int msecond = (int)(this.time * 100 % 60);
        string text =
            minute.ToString("0") + "'" +
            second.ToString("00") + "\"" +
            msecond.ToString("00");
        if (this.timer.GetComponent<Text>().text != text)
        {
            this.timer.GetComponent<Text>().text = text;
        }
    }

    // 車がチェックポイントに入った時に呼ばれる
    public void OnCheckPointEnter(int checkPointNo)
    {
        if (this.state == Main.State.Play)
        {
            // チェックポイントの位置の遷移
            if ((this.checkPointLastNo + 1) % CHECKPOINT_NUM == checkPointNo)
            {
                this.checkPointCount += 1;
            }
            if ((this.checkPointLastNo - 1 + CHECKPOINT_NUM) % CHECKPOINT_NUM == checkPointNo)
            {
                this.checkPointCount -= 1;
            }
            this.checkPointLastNo = checkPointNo;

            // ゴールに遷移
            if (this.checkPointCount == CHECKPOINT_NUM)
            {
                SetState(State.Goal);
            }
        }
    }
}
