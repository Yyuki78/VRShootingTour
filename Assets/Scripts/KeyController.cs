using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// キーによるコントローラ
public class KeyController : MonoBehaviour
{
    Main main;

    // スタート時の処理
    void Start()
    {
        this.main = GetComponent<Main>();
    }

    // フレーム毎の処理
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal") * 1f;
        float v = Input.GetAxis("Vertical") * 20f;
        this.main.SetAction(h, v);
    }
}
