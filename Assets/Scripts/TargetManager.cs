using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    [SerializeField] GameObject TartgetRed;
    [SerializeField] GameObject TartgetBlue;
    [SerializeField] GameObject TartgetBlack;

    public int d = 10;//ê∂ê¨ãóó£
    private int n = 0;

    public void GenerateTartget(float size)
    {
        
        var theta = Random.Range(0, Mathf.PI);
        var p = Random.Range(0f, 1f);
        var phi = Mathf.Asin(Mathf.Pow(p, 1f / (n + 1f)));
        /*
        var theta = Random.Range(-Mathf.PI, Mathf.PI);
        var p = Random.Range(0f, 1f);
        var phi = Mathf.Asin((2f * p) - 1f);
        */
        int x = Random.Range(0, 2);
        if (x == 0)
        {
            phi = -phi;
        }
        var Transform = new Vector3(
                    Mathf.Cos(phi) * Mathf.Cos(theta) * d,
                    Mathf.Cos(phi) * Mathf.Sin(theta) * d + 1.5f,
                    Mathf.Sin(phi) * d - 10);
        var Rotation = Quaternion.identity;

        int color = Random.Range(0, 3);
        GameObject ins;
        switch (color)
        {
            case 0:
                ins = Instantiate(TartgetRed, Transform, Rotation, this.gameObject.transform);
                ins.transform.localScale = new Vector3(size / 10f, size / 10f, size / 10f);
                break;
            case 1:
                ins = Instantiate(TartgetBlue, Transform, Rotation, this.gameObject.transform);
                ins.transform.localScale = new Vector3(size / 10f, size / 10f, size / 10f);
                break;
            case 2:
                ins = Instantiate(TartgetBlack, Transform, Rotation, this.gameObject.transform);
                ins.transform.localScale = new Vector3(size / 10f, size / 10f, size / 10f);
                break;
            default:
                Debug.Log("TargetÇÃcoloråàÇﬂÇ™èoóàÇƒÇ‹ÇπÇÒ");
                break;
        }
        
    }
}
