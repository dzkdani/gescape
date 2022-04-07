using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObj : MonoBehaviour
{
    public float timer = 0.06f;
    // Start is called before the first frame update
    
    
    void Start()
    {
        
    }
    
    IEnumerator Dest()
    {
        yield return new WaitForSeconds(timer);
        Destroy(gameObject);
    }
}
