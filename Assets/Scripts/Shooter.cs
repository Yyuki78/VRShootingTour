using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab; //弾のプレハブ
    [SerializeField] Transform Bullets; //弾を保持（プーリング）する空のオブジェクト
    Transform bullets;
    bullet _shoot;
    [SerializeField] Transform gunBarrelEnd;  //銃口(弾の発射位置)

    [SerializeField] ParticleSystem gunParticle;//発射時演出
    [SerializeField] AudioSource gunAudioSource;//発射時の音源

    private float shotInterval;

    //連射機能
    public bool Auto = false;

    private void Start()
    {
        //弾を保持する空のオブジェクトを生成
        bullets = gunBarrelEnd.transform;
        Auto = false;
    }

    void Update()
    {
        if (Auto == false)
        {
            //入力に応じて弾を発射する
            if (Input.GetButtonDown("Fire1") && shotInterval < 0)
            {
                shotInterval = 5;
                Shoot(bullets.position, bullets.rotation);
            }
            shotInterval--;
        }
        else
        {
            //bullets = gunBarrelEnd.transform;
            shotInterval += 1;
            if (shotInterval % 5 == 0)
            {
                //入力に応じて弾を発射する
                if (Input.GetButton("Fire1"))
                {
                    Shoot(bullets.position, bullets.rotation);
                }
            }
        }
    }

    void Shoot(Vector3 pos, Quaternion rotation)
    {
        //発射時演出を再生
        gunParticle.Play();

        //発射時の音を再生
        gunAudioSource.Play();

        //アクティブでないオブジェクトをbulletsの中から探索
        foreach (Transform t in Bullets)
        {
            if (!t.gameObject.activeSelf)
            {
                //非アクティブなオブジェクトの位置と回転を設定
                t.SetPositionAndRotation(pos, rotation);
                //アクティブにする
                t.gameObject.SetActive(true);
                
                _shoot = t.gameObject.GetComponent<bullet>();
                //StartCoroutine(_shoot.TimeOver());
                _shoot.SetForward();
                return;
            }
        }
        //非アクティブなオブジェクトがない場合新規生成

        //生成時にbulletsの子オブジェクトにする
        Instantiate(bulletPrefab, pos, rotation, Bullets);

        //プレハブを元に、シーン上に弾を生成
        //Instantiate(bulletPrefab, gunBarrelEnd.position, gunBarrelEnd.rotation);

    }
}
