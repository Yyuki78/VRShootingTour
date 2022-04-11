using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TargetBreak : MonoBehaviour
{
    private bool Hit = false;
    private ShootingGameManager _manager;

    private void Start()
    {
        _manager = GetComponentInParent<ShootingGameManager>();
        transform.LookAt(_manager.gameObject.transform.position);
        var rotation= Random.Range(0, 360);
        transform.Rotate(new Vector3(0, 0, rotation));
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
            r.gameObject.layer = 8;
            var vect = new Vector3(random.Next(min, max), random.Next(0, max), random.Next(min, max));
            r.AddForce(vect, ForceMode.Impulse);
            r.AddTorque(vect, ForceMode.Impulse);
        });
        this.gameObject.AddComponent<AutoDestroy>().time = 2f;
        if (Hit == false)
        {
            Hit = true;
            Debug.Log("Hit");
            _manager.HitTarget();
        }
        //Destroy(gameObject);
    }
}
