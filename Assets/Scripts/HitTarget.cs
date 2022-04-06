using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HitTarget : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hit"); // ÉçÉOÇï\é¶Ç∑ÇÈ
        destroyObject();
    }

    public void destroyObject()
    {
        var random = new System.Random();
        var min = -1;
        var max = 1;
        gameObject.GetComponentsInChildren<Rigidbody>().ToList().ForEach(r => {
            r.isKinematic = false;
            r.transform.SetParent(null);
            r.gameObject.AddComponent<AutoDestroy>().time = 2f;
            var vect = new Vector3(random.Next(min, max), random.Next(0, max), random.Next(min, max));
            r.AddForce(vect, ForceMode.Impulse);
            r.AddTorque(vect, ForceMode.Impulse);
        });
        //Destroy(gameObject);
    }
}
