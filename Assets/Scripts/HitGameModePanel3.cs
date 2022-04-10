using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitGameModePanel3 : MonoBehaviour
{
    [SerializeField] int Mode;//���̋@�\�̃p�l����
    [SerializeField] int ModeNum;//���Ԃ�

    private ChangeInfinityMode _change;

    private void Awake()
    {
        _change = GetComponentInParent<ChangeInfinityMode>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            _change.changeGameMode(Mode, ModeNum);
        }
    }
}
