using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BGController : MonoBehaviour
{
    public Color[] BGcolor;
    GameManager GM;
    RawImage thisRaw;
    // Start is called before the first frame update
    void Start()
    {
        thisRaw = GetComponent<RawImage>();
        GM = FindObjectOfType<GameManager>();
        changeBGcolor();
    }

    public void changeBGcolor()
    {
            thisRaw.color = BGcolor[GM.BG];
    }
}
