using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotater : MonoBehaviour
{
    [SerializeField] float angularVelocity = 30f; //��]���x�̐ݒ�
    float horizontalAngle = 0f; //���������̉�]�ʂ�ۑ�
    float verticalAngle = 0f;   //���������̉�]�ʂ�ۑ�

    // Update is called once per frame
#if UNITY_EDITOR
    void Update()
    {
        //���͂ɂ���]�ʂ��擾
        var horizontalRotation = Input.GetAxis("Horizontal") *
            angularVelocity * Time.deltaTime;
        var verticalRotation = -Input.GetAxis("Vertical") *
            angularVelocity * Time.deltaTime;
        //��]�ʂ��X�V
        horizontalAngle += horizontalRotation;
        verticalAngle += verticalRotation;
        //���������͉�]���߂��Ȃ��悤�ɐ���
        verticalAngle = Mathf.Clamp(verticalAngle, -80f, 80f);
        //Transform�R���|�[�l���g�ɉ�]�ʂ�K�p����
        transform.rotation = Quaternion.Euler(verticalAngle, horizontalAngle, 0f);
    }
#endif
}
