using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteController : MonoBehaviour
{
    SpriteRenderer thisSprite;
    GameManager GM;
    public Sprite[] sprites;
    public bool BG = false;
    // Start is called before the first frame update
    void Start()
    {
        GM = FindObjectOfType<GameManager>();
        thisSprite = GetComponent<SpriteRenderer>();
        if(BG == false)
        {
            changeObsSprite();
        }
        else
        {
            changeBGSprite();
        }
    }

    public void changeBGSprite()
    {
        if(sprites[GM.BG] != null)
            thisSprite.sprite = sprites[GM.BG];
    }

    public void changeObsSprite()
    {
        if(sprites[GM.Obs] != null)
            thisSprite.sprite = sprites[GM.Obs];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
