using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class bullet : MonoBehaviour
{
    [SerializeField] float speed = 20f; //弾速[m/s]

    private float limit = 5.0f;

    [SerializeField] ParticleSystem hitParticlePrefab;//着弾時演出プレハブ

    //private Rigidbody _rigid;

    // Start is called before the first frame update
    void Start()
    {
        /*
        //ゲームオブジェクト前方向の速度ベクトルを計算
        var velocity = speed * transform.forward;
        Debug.Log(transform.forward);

        //Rigidbodyコンポーネントを取得
        _rigid = GetComponent<Rigidbody>();

        //Rigidbodyコンポーネントを使って初速を与える
        _rigid.AddForce(velocity, ForceMode.VelocityChange);

        //時間経過後に非アクティブにする
        Invoke(nameof(Invisible), 2.0f);
        
        var forward = transform.forward;
        _rigid = GetComponent<Rigidbody>();
        //Shooting();
        */
        Invoke(nameof(Invisible), limit);
    }

    private void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    public IEnumerator TimeOver()
    {
        yield return new WaitForSeconds(limit);
        Invisible();
        yield break;
    }
    /*
    public void Shooting()
    {
        //ゲームオブジェクト前方向の速度ベクトルを計算
        var velocity = speed * transform.forward;
        //var velocity = speed * forward;

        //Rigidbodyコンポーネントを使って初速を与える
        _rigid.AddForce(velocity, ForceMode.VelocityChange);

        //時間経過後に非アクティブにする
        Invoke(nameof(Invisible), 2.0f);
    }*/

    //トリガー領域進入時に呼び出される
    private void OnCollisionEnter(Collision collision)
    {
        //着弾時に演出自動再生のゲームオブジェクトを生成
        Instantiate(hitParticlePrefab, transform.position, transform.rotation);

        //自身のゲームオブジェクトを非アクティブにする
        Invisible();
    }

    private void Invisible()
    {
        //var velocity = speed * transform.forward;
        //_rigid.AddForce(-velocity, ForceMode.VelocityChange);
        //何かに衝突するor制限時間を超えたら非アクティブにする
        gameObject.SetActive(false);
    }
}
