using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettingManager : MonoBehaviour
{
    //�����Ƃ���ێ�����
    //����Script�ŕύX���������c��
    //ChangeRapidGameMode,ChangeGameMode
    public int GameMode;//1=������,2=������,3=����

    [SerializeField] GameObject RapidPanel;
    [SerializeField] GameObject QuantityPanel;
    [SerializeField] GameObject InfinityPanel;

    //�������p
    public int LimitTime;
    public int MaxAppearances;
    public int TargetSize;

    //�������p
    public int LimitNum;
    public int MaxAppearances2;
    public int TargetSize2;

    //�����p
    public bool Cheat;
    public int MaxAppearances3;
    public int TargetSize3;

    // Start is called before the first frame update
    void Awake()
    {
        GameMode = 1;
        LimitTime = 30;
        MaxAppearances = 10;
        TargetSize = 10;

        LimitNum = 30;
        MaxAppearances2 = 10;
        TargetSize2 = 10;

        Cheat = false;
        MaxAppearances3 = 10;
        TargetSize3 = 10;
    }

    public void changePanel(int mode)
    {
        switch (mode)
        {
            case 1:
                RapidPanel.SetActive(true);
                QuantityPanel.SetActive(false);
                InfinityPanel.SetActive(false);
                break;
            case 2:
                RapidPanel.SetActive(false);
                QuantityPanel.SetActive(true);
                InfinityPanel.SetActive(false);
                break;
            case 3:
                RapidPanel.SetActive(false);
                QuantityPanel.SetActive(false);
                InfinityPanel.SetActive(true);
                break;
            default:
                Debug.Log("�p�l���؂�ւ��Ɏ��s���܂���");
                break;
        }
    }
}
