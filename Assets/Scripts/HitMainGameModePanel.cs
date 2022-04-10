using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitMainGameModePanel : MonoBehaviour
{
    [SerializeField] int Mode;//‰½”Ô‚Ìƒpƒlƒ‹‚©
    private ChangeGameMode _change;
    private void Awake()
    {
        _change = GetComponentInParent<ChangeGameMode>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            _change.changeGameMode(Mode);
        }
    }
}
