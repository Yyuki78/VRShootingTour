using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeInfinityMode : MonoBehaviour
{
    [SerializeField] GameObject ShootingModeImage;
    [SerializeField] GameObject TargetNumImage;
    [SerializeField] GameObject TargetSizeImage;

    private GameSettingManager _manager;

    // Start is called before the first frame update
    void Awake()
    {
        _manager = GetComponentInParent<GameSettingManager>();
    }

    public void changeGameMode(int mode, int num)
    {
        switch (mode)
        {
            case 1:
                switch (num)
                {
                    case 1:
                        ShootingModeImage.transform.localPosition = new Vector3(-0.95f, 3.525f, 0);
                        _manager.Cheat = false;
                        break;
                    case 2:
                        ShootingModeImage.transform.localPosition = new Vector3(1f, 3.525f, 0);
                        _manager.Cheat = true;
                        break;
                    default:
                        Debug.Log("ÉQÅ[ÉÄÇÃì‡óeê›íË1Ç…é∏îsÇµÇ‹ÇµÇΩ");
                        break;
                }
                break;
            case 2:
                switch (num)
                {
                    case 1:
                        TargetNumImage.transform.localPosition = new Vector3(-2.3f, 1.6f, 0f);
                        _manager.MaxAppearances3 = 1;
                        break;
                    case 2:
                        TargetNumImage.transform.localPosition = new Vector3(-1.15f, 1.6f, 0f);
                        _manager.MaxAppearances3 = 5;
                        break;
                    case 3:
                        TargetNumImage.transform.localPosition = new Vector3(0f, 1.6f, 0f);
                        _manager.MaxAppearances3 = 10;
                        break;
                    case 4:
                        TargetNumImage.transform.localPosition = new Vector3(1.15f, 1.6f, 0f);
                        _manager.MaxAppearances3 = 25;
                        break;
                    case 5:
                        TargetNumImage.transform.localPosition = new Vector3(2.3f, 1.6f, 0f);
                        _manager.MaxAppearances3 = 50;
                        break;
                    default:
                        Debug.Log("ÉQÅ[ÉÄÇÃì‡óeê›íË2Ç…é∏îsÇµÇ‹ÇµÇΩ");
                        break;
                }
                break;
            case 3:
                switch (num)
                {
                    case 1:
                        TargetSizeImage.transform.localPosition = new Vector3(-1.3f, -0.2f, 0f);
                        _manager.TargetSize3 = 5;
                        break;
                    case 2:
                        TargetSizeImage.transform.localPosition = new Vector3(0f, -0.2f, 0f);
                        _manager.TargetSize3 = 10;
                        break;
                    case 3:
                        TargetSizeImage.transform.localPosition = new Vector3(1.3f, -0.2f, 0f);
                        _manager.TargetSize3 = 15;
                        break;
                    default:
                        Debug.Log("ÉQÅ[ÉÄÇÃì‡óeê›íË3Ç…é∏îsÇµÇ‹ÇµÇΩ");
                        break;
                }
                break;
            default:
                Debug.Log("ÉQÅ[ÉÄÇÃì‡óeê›íËÇ…é∏îsÇµÇ‹ÇµÇΩ");
                break;
        }
    }
}
