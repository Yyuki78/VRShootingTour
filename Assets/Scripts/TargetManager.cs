using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    [SerializeField] GameObject TartgetRed;
    [SerializeField] GameObject TartgetBlue;
    [SerializeField] GameObject TartgetBlack;

    public int GeneNum = 100;//“I‚ğ¶¬‚·‚é”

    public int d = 10;//¶¬‹——£
    private int n = 0;

    // Start is called before the first frame update
    void Awake()
    {
        for(int i = 0; i < GeneNum; i++)
        {
            GenerateTartget();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateTartget()
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
        switch (color)
        {
            case 0:
                Instantiate(TartgetRed, Transform, Rotation, this.gameObject.transform);
                break;
            case 1:
                Instantiate(TartgetBlue, Transform, Rotation, this.gameObject.transform);
                break;
            case 2:
                Instantiate(TartgetBlack, Transform, Rotation, this.gameObject.transform);
                break;
            default:
                Debug.Log("Target‚ÌcolorŒˆ‚ß‚ªo—ˆ‚Ä‚Ü‚¹‚ñ");
                break;
        }
    }
}
