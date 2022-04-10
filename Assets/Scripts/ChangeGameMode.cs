using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGameMode : MonoBehaviour
{
    [SerializeField] GameObject GameSettingManager;
    private GameSettingManager _manager;

    [SerializeField] GameObject GameSelect1;
    [SerializeField] GameObject GameSelect2;
    [SerializeField] GameObject GameSelect3;
    [SerializeField] GameObject GameExplanation1;
    [SerializeField] GameObject GameExplanation2;
    [SerializeField] GameObject GameExplanation3;
    // Start is called before the first frame update
    void Start()
    {
        _manager = GameSettingManager.GetComponent<GameSettingManager>();
        changeGameMode(_manager.GameMode);
    }

    public void changeGameMode(int mode)
    {
        switch (mode)
        {
            case 1:
                GameSelect1.SetActive(true);
                GameSelect2.SetActive(false);
                GameSelect3.SetActive(false);
                GameExplanation1.SetActive(true);
                GameExplanation2.SetActive(false);
                GameExplanation3.SetActive(false);
                _manager.GameMode = 1;
                break;
            case 2:
                GameSelect1.SetActive(false);
                GameSelect2.SetActive(true);
                GameSelect3.SetActive(false);
                GameExplanation1.SetActive(false);
                GameExplanation2.SetActive(true);
                GameExplanation3.SetActive(false);
                _manager.GameMode = 2;
                break;
            case 3:
                GameSelect1.SetActive(false);
                GameSelect2.SetActive(false);
                GameSelect3.SetActive(true);
                GameExplanation1.SetActive(false);
                GameExplanation2.SetActive(false);
                GameExplanation3.SetActive(true);
                _manager.GameMode = 3;
                break;
            default:
                Debug.Log("ÉQÅ[ÉÄÉÇÅ[ÉhÇÃê›íËÇ…é∏îsÇµÇ‹ÇµÇΩ");
                break;
        }
        _manager.changePanel(mode);
    }
}
