using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSter : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("HitSter"); // ���O��\������
        destroyObject();
    }

    public void destroyObject()
    {
        Destroy(gameObject);
    }
}
