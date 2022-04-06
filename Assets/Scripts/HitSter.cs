using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSter : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("HitSter"); // ÉçÉOÇï\é¶Ç∑ÇÈ
        destroyObject();
    }

    public void destroyObject()
    {
        Destroy(gameObject);
    }
}
