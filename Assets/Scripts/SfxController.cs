using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxController : MonoBehaviour
{
    GameManager gm;
    AudioSource Au;
    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        Au = GetComponent<AudioSource>();

        Au.volume = gm.SoundVal;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
