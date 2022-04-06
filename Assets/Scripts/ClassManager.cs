using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ClassManager : MonoBehaviour
{
    public static ClassManager instance;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}
