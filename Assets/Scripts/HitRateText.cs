using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HitRateText : MonoBehaviour
{
    [SerializeField]GameObject Target;
    private ShootingGameManager _manager;

    private TextMeshProUGUI hitRateText;

    // Start is called before the first frame update
    void Start()
    {
        _manager = Target.GetComponent<ShootingGameManager>();
        hitRateText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        hitRateText.text = "–½’†—¦:" + _manager.HitRate.ToString("f1") + "%";
    }
}
