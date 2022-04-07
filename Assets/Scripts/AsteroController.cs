using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroController : MonoBehaviour
{
    public GameObject crack;
    SpriteRenderer sr;
    PlayerController pl;
    public void cracked()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.color = new Vector4(0, 0, 0, 0);
        Collider2D objcoll = GetComponent<Collider2D>();
        objcoll.enabled = false;
        crack.SetActive(true);
        StartCoroutine(pl.destroyObj(gameObject));
    }
    // Start is called before the first frame update
    void Start()
    {
        pl = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
