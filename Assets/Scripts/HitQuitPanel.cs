using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitQuitPanel : MonoBehaviour
{
    private ShootingGameManager _manager;

    private void Awake()
    {
        _manager = GetComponentInParent<ShootingGameManager>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            _manager.HitQuitPanel();
        }
    }
}
