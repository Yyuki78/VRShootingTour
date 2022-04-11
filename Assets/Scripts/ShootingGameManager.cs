using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingGameManager : MonoBehaviour
{
    [SerializeField] GameObject GameState;
    private GameStateController _state;

    [SerializeField] GameObject GameSetting;
    private GameSettingManager _manager;

    private TargetManager _target;

    private int GameMode;

    private float LimitTime = 0;
    private int LimitNum = 0;
    private int GeneNum = 10;//的を一度に生成する数
    private int Size = 10;//的のサイズ

    //無限モード時に自動なら射撃モードを切り替える用
    [SerializeField] GameObject PlayerGunRight;
    [SerializeField] GameObject PlayerGunLeft;
    private Shooter _shooter1;
    private Shooter _shooter2;

    //それぞれのゲームの終了条件用の変数
    [SerializeField] private float timer = 0f;//経過時間

    private int breakNum = 0;//壊した的の数
    private int maxNum = 0;//出現した的の数
    private bool stopGenerate = false;

    private int gameStop = 5;

    // Start is called before the first frame update
    void Start()
    {
        _state = GameState.GetComponent<GameStateController>();
        _manager = GameSetting.GetComponent<GameSettingManager>();
        _target = GetComponent<TargetManager>();
        GameMode = _manager.GameMode;
        switch (GameMode)
        {
            case 1:
                LimitTime = _manager.LimitTime;
                GeneNum = _manager.MaxAppearances;
                Size = _manager.TargetSize;
                break;
            case 2:
                LimitNum = _manager.LimitNum;
                GeneNum = _manager.MaxAppearances2;
                Size = _manager.TargetSize2;
                break;
            case 3:
                if (_manager.Cheat)
                {
                    _shooter1 = PlayerGunRight.GetComponent<Shooter>();
                    _shooter2 = PlayerGunLeft.GetComponent<Shooter>();
                    _shooter1.Auto = true;
                    _shooter2.Auto = true;
                }
                GeneNum = _manager.MaxAppearances3;
                Size = _manager.TargetSize3;
                break;
            default:
                Debug.Log("ゲームモードが不明です");
                break;
        }
        //的を生成
        for (int i = 0; i < GeneNum; i++)
        {
            _target.GenerateTartget(Size);
        }
    }

    // Update is called once per frame
    void Update()
    {
        updateGame();

        if (GameMode == 1)
        {
            updateRapidGame();
        }
        else if (GameMode == 2)
        {
            updateQuantityGame();
        }
        else
        {
            updateInfinityGame();
        }

        updateQuitGame();
    }

    private void updateGame()
    {
        timer += Time.deltaTime;
    }

    private void updateRapidGame()
    {
        if (timer >= LimitTime)
        {
            //ゲーム終了
            _state.FinishGame = true;
        }
    }

    private void updateQuantityGame()
    {
        if (breakNum >= LimitNum - GeneNum)
        {
            stopGenerate = true;
        }
        if (breakNum >= LimitNum)
        {
            //ゲーム終了
            _state.FinishGame = true;
        }
    }

    private void updateInfinityGame()
    {

    }

    private void updateQuitGame()
    {
        if (timer >= 3600)
        {
            //ゲーム終了
            _state.FinishGame = true;
        }
        if (gameStop <= 0)
        {
            //ゲーム終了
            _state.FinishGame = true;
        }
    }

    //的にヒットしたときに呼ばれる
    public void HitTarget()
    {
        breakNum++;
        if (stopGenerate) return;
        _target.GenerateTartget(Size);
    }

    //ゲーム終了ゾーンにヒットしたときに呼ばれる
    public void HitQuitPanel()
    {
        gameStop--;
    }
}
