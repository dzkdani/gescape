using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawning : MonoBehaviour
{
    public GameObject[] obj;
    public float rangeX, RangeY;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < Random.Range(8, 15); i++)
        {
            Instantiate(obj[Random.Range(0,obj.Length)], new Vector2(Random.Range(-rangeX,rangeX),Random.Range(-RangeY,RangeY)),Quaternion.identity);
        }        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
