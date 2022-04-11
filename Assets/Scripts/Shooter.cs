using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab; //�e�̃v���n�u
    [SerializeField] Transform Bullets; //�e��ێ��i�v�[�����O�j�����̃I�u�W�F�N�g
    Transform bullets;
    bullet _shoot;
    [SerializeField] Transform gunBarrelEnd;  //�e��(�e�̔��ˈʒu)

    [SerializeField] ParticleSystem gunParticle;//���ˎ����o
    [SerializeField] AudioSource gunAudioSource;//���ˎ��̉���

    private float shotInterval;

    //�A�ˋ@�\
    public bool Auto = false;

    private void Start()
    {
        //�e��ێ������̃I�u�W�F�N�g�𐶐�
        bullets = gunBarrelEnd.transform;
        Auto = false;
    }

    void Update()
    {
        if (Auto == false)
        {
            //���͂ɉ����Ēe�𔭎˂���
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
                //���͂ɉ����Ēe�𔭎˂���
                if (Input.GetButton("Fire1"))
                {
                    Shoot(bullets.position, bullets.rotation);
                }
            }
        }
    }

    void Shoot(Vector3 pos, Quaternion rotation)
    {
        //���ˎ����o���Đ�
        gunParticle.Play();

        //���ˎ��̉����Đ�
        gunAudioSource.Play();

        //�A�N�e�B�u�łȂ��I�u�W�F�N�g��bullets�̒�����T��
        foreach (Transform t in Bullets)
        {
            if (!t.gameObject.activeSelf)
            {
                //��A�N�e�B�u�ȃI�u�W�F�N�g�̈ʒu�Ɖ�]��ݒ�
                t.SetPositionAndRotation(pos, rotation);
                //�A�N�e�B�u�ɂ���
                t.gameObject.SetActive(true);
                
                _shoot = t.gameObject.GetComponent<bullet>();
                //StartCoroutine(_shoot.TimeOver());
                _shoot.SetForward();
                return;
            }
        }
        //��A�N�e�B�u�ȃI�u�W�F�N�g���Ȃ��ꍇ�V�K����

        //��������bullets�̎q�I�u�W�F�N�g�ɂ���
        Instantiate(bulletPrefab, pos, rotation, Bullets);

        //�v���n�u�����ɁA�V�[����ɒe�𐶐�
        //Instantiate(bulletPrefab, gunBarrelEnd.position, gunBarrelEnd.rotation);

    }
}
