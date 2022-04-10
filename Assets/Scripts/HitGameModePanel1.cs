using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitGameModePanel1 : MonoBehaviour
{
    [SerializeField] int Mode;//���̋@�\�̃p�l����
    [SerializeField] int ModeNum;//���Ԃ�

    private ChangeRapidGameMode _change;

    private void Awake()
    {
        _change = GetComponentInParent<ChangeRapidGameMode>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            _change.changeGameMode(Mode, ModeNum);
        }
    }
}
