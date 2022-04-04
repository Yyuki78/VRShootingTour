using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

// Oculusによるコントローラ
public class OculusController : MonoBehaviour
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
        // 左手コントローラのジョイスティックの位置の取得
        var leftCharacteristics =
            InputDeviceCharacteristics.HeldInHand |
            InputDeviceCharacteristics.Left |
            InputDeviceCharacteristics.Controller;
        float h = GetJoystickAxis(leftCharacteristics).x * 1f;

        // 右手コントローラのジョイスティックの位置の取得
        var rightCharacteristics =
            InputDeviceCharacteristics.HeldInHand |
            InputDeviceCharacteristics.Right |
            InputDeviceCharacteristics.Controller;
        float v = GetJoystickAxis(rightCharacteristics).y * 20f;

        // アクションの指定
        this.main.SetAction(h, v);
    }

    // ジョイスティックの位置の取得
    Vector2 GetJoystickAxis(InputDeviceCharacteristics characteristics)
    {
        // コントローラの取得
        var handDevices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(characteristics, handDevices);
        foreach (var device in handDevices)
        {
            // ジョイスティックの位置の取得時の処理
            if (device.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 position))
            {
                return position;
            }
        }
        return Vector2.zero;
    }
}
