using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class TestController : MonoBehaviour
{
    // フレーム毎に呼ばれる
    void Update()
    {
        // 左手コントローラの取得
        var leftHandDevices = new List<InputDevice>();
        var desiredCharacteristics =
            InputDeviceCharacteristics.HeldInHand |
            InputDeviceCharacteristics.Left |
            InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(desiredCharacteristics, leftHandDevices);
        foreach (var device in leftHandDevices)
        {
            // ジョイスティックの位置の取得時の処理
            if (device.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 position))
            {
                Debug.Log("ジョイスティック : " + position.x.ToString("N2") + "," + position.y.ToString("N2"));
            }

            // トリガーボタン押下時の処理
            bool triggerValue;
            if (device.TryGetFeatureValue(CommonUsages.triggerButton, out triggerValue) && triggerValue)
            {
                Debug.Log("トリガーボタン押下");
            }
        }
    }
}
