using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjSizeController : MonoBehaviour
{

    public float lowRange, highRange;
    // Start is called before the first frame update
    void Start()
    {
        float randomScale = Random.Range(lowRange,highRange);
        transform.localScale = new Vector2(randomScale, randomScale);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
