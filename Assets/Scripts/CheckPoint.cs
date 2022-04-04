using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// チェックポイント
public class CheckPoint : MonoBehaviour
{
    // チェックポイントエンター時に呼ばれる
    void OnTriggerEnter(Collider collider)
    {
        //「checkpoint<数字>」から<数字>を取得
        int checkPointNo = int.Parse(this.gameObject.name.Substring(10));

        // MyGameにイベント通知
        Main main = GameObject.Find("Main").GetComponent<Main>();
        main.OnCheckPointEnter(checkPointNo);
    }
}
