using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTarget : MonoBehaviour
{
    private TargetBreak _break;

    private void Awake()
    {
        _break = GetComponentInParent<TargetBreak>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            _break.destroyObject();
        }
    }
}
