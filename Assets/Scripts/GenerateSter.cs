using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateSter : MonoBehaviour
{
    [SerializeField]
    GameObject SterPrefab;

    int pointCount = 200;
    GameObject[] points;

    private float phi, theta, scale;
    private int n = 750;

    private float rotatex, rotatey, rotatez;

    // Start is called before the first frame update
    void Awake()
    {
        points = new GameObject[pointCount];
        for (int i = 0; i < pointCount; i++)
        {
            phi = theta = 0f;

            theta = Random.Range(-Mathf.PI, Mathf.PI);
            var p = Random.Range(0f, 1f);
            phi = Mathf.Asin((2f * p) - 1f);
            
            points[i] = Instantiate(SterPrefab, transform, false);

            points[i].transform.localPosition = new Vector3(
                        Mathf.Cos(phi) * Mathf.Cos(theta) * n,
                        Mathf.Cos(phi) * Mathf.Sin(theta) * n,
                        Mathf.Sin(phi) * n);

            scale = Random.Range(5f, 20f);
            points[i].transform.localScale = new Vector3(scale, scale, scale);
        }
        rotatex = Random.Range(0f, 0.01f);
        rotatey = Random.Range(0f, 0.01f);
        rotatez = Random.Range(0f, 0.01f);
    }

    private void Update()
    {
        transform.Rotate(new Vector3(rotatex, rotatey, rotatez));
    }
}
