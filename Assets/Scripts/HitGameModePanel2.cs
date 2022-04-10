using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitGameModePanel2 : MonoBehaviour
{
    [SerializeField] int Mode;//���̋@�\�̃p�l����
    [SerializeField] int ModeNum;//���Ԃ�

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
