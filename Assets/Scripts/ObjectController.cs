using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using DG.Tweening;

public class ObjectController : MonoBehaviour
{

    GameplayManager gm;
    public int ID;
    float sped;
    [SerializeField] GameObject Pivot;
    bool kananOn = false;
    public bool BG = false;
    float rot = 2;
    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameplayManager>();
        int randRot = Random.Range(0, 1000);
        sped = gm.AsteroidSpeed;
        if (randRot < 500)
        {
            rot = -rot;
        }
        else
        {
        }

        int randGo = Random.Range(0,1000);
        if (randGo < 500)
        {
            sped = -sped;
        }
        else
        {

        }

        if (BG)
        {
            int x = Random.Range(0, 100);
            if (x <= 50)
            {
                gameObject.transform.DOScale(1.5f, 1).SetLoops(-1, LoopType.Yoyo);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (!gm.pause)
        {
            if (ID == 0)
            {
                transform.Translate(new Vector2(0, gm.AsteroidSpeed * Time.deltaTime));
            }
            else if (ID == 1)
            {
                transform.Translate(new Vector2(0, gm.bg1Speed * Time.deltaTime));
            }
            else if (ID == 2)
            {
                transform.Translate(new Vector2(0, gm.bg2Speed * Time.deltaTime));
            }
            else if (ID == 3)
            {
                transform.RotateAround(Pivot.transform.localPosition, Vector3.forward, rot);
            }
            else if (ID == 4)
            {
                
                transform.Translate(new Vector2(sped * Time.deltaTime, 0));
                if (transform.position.x <= -2.6f)
                {
                    sped = -sped;
                }
                else if (transform.position.x >= 2.6f)
                {
                    Debug.Log("ngentod");
                    sped = -sped;
                }
            }
            if (transform.position.y <= -6.9f)
            {
                Destroy(gameObject);
            }
        }
    }
}
