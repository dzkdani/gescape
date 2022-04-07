using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    float speed;
    float rotation;
    // Start is called before the first frame update
    void Start()
    {
        rotation = Random.Range(-120, 120);
        speed = Random.Range(-1,4);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate((Vector3.forward * speed),rotation*Time.deltaTime);
    }

}
