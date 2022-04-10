using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitGameModePanel2 : MonoBehaviour
{
    [SerializeField] int Mode;//何の機能のパネルか
    [SerializeField] int ModeNum;//何番か

    private ChangeQuantityMode _change;

    private void Awake()
    {
        _change = GetComponentInParent<ChangeQuantityMode>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            _change.changeGameMode(Mode, ModeNum);
        }
    }
}
