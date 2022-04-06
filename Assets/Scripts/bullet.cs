using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class bullet : MonoBehaviour
{
    [SerializeField] float speed = 20f; //�e��[m/s]

    private float limit = 5.0f;

    [SerializeField] ParticleSystem hitParticlePrefab;//���e�����o�v���n�u

    //private Rigidbody _rigid;

    // Start is called before the first frame update
    void Start()
    {
        /*
        //�Q�[���I�u�W�F�N�g�O�����̑��x�x�N�g�����v�Z
        var velocity = speed * transform.forward;
        Debug.Log(transform.forward);

        //Rigidbody�R���|�[�l���g���擾
        _rigid = GetComponent<Rigidbody>();

        //Rigidbody�R���|�[�l���g���g���ď�����^����
        _rigid.AddForce(velocity, ForceMode.VelocityChange);

        //���Ԍo�ߌ�ɔ�A�N�e�B�u�ɂ���
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
        //�Q�[���I�u�W�F�N�g�O�����̑��x�x�N�g�����v�Z
        var velocity = speed * transform.forward;
        //var velocity = speed * forward;

        //Rigidbody�R���|�[�l���g���g���ď�����^����
        _rigid.AddForce(velocity, ForceMode.VelocityChange);

        //���Ԍo�ߌ�ɔ�A�N�e�B�u�ɂ���
        Invoke(nameof(Invisible), 2.0f);
    }*/

    //�g���K�[�̈�i�����ɌĂяo�����
    private void OnCollisionEnter(Collision collision)
    {
        //���e���ɉ��o�����Đ��̃Q�[���I�u�W�F�N�g�𐶐�
        Instantiate(hitParticlePrefab, transform.position, transform.rotation);

        //���g�̃Q�[���I�u�W�F�N�g���A�N�e�B�u�ɂ���
        Invisible();
    }

    private void Invisible()
    {
        //var velocity = speed * transform.forward;
        //_rigid.AddForce(-velocity, ForceMode.VelocityChange);
        //�����ɏՓ˂���or�������Ԃ𒴂������A�N�e�B�u�ɂ���
        gameObject.SetActive(false);
    }
}
