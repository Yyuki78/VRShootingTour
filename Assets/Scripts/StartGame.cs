using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] GameObject gameStateController;
    private GameStateController _state;

    private void Awake()
    {
        _state = gameStateController.GetComponent<GameStateController>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            _state.StartGame = true;
        }
    }
}
