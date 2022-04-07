/*created by Rahmat MPR*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using DG.Tweening.Plugins;

public class PlayerController : MonoBehaviour
{
    public float speed;
    GameplayManager gpm;
    public bool onMoveRight= true, onMoveLeft = true; 
    public GameObject left, right;
    public float limit;
    public int damageVal;
    public int healVal;
    public int health;
    public Slider sliderHealth;
    public GameObject Target;
    public RawImage img;
    public GameObject Explotion;
    public GameObject PickUp;
    public Text tutorialText;

    GameManager GM;
    SpriteRenderer Playerspr;
    Animator PlayerAnimator;
    public Sprite[] sprite;
    public RuntimeAnimatorController[] anim;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(tutorial());
        sliderHealth.maxValue = health;
        sliderHealth.value = sliderHealth.maxValue;
        Debug.Log(""+sliderHealth.maxValue+"/"+sliderHealth.value);
        gpm = FindObjectOfType<GameplayManager>();
        GM = FindObjectOfType<GameManager>();
        Playerspr = GetComponent<SpriteRenderer>();
        PlayerAnimator = GetComponent<Animator>();
        changeCharacter();
        Debug.Log("sekarang anim :" + anim[GM.Chara]);
    }
    public void changeCharacter()
    {
        if (sprite[GM.Chara] != null) {
            Playerspr.sprite = sprite[GM.Chara];
            PlayerAnimator.runtimeAnimatorController = anim[GM.Chara];
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!gpm.pause)
        {
            //check when game isn't Over, Game can be played
            if (!gpm.GameOver)
            {
                //when Started
                if (gpm.start)
                {
                    //get mouse position
                    Vector3 mouse = Input.mousePosition;
                    Vector3 MousePos = Camera.main.ScreenToWorldPoint(mouse);

                    //can move left when onMoveLeft is true
                    if (onMoveLeft)
                        if (Input.GetMouseButton(0) && MousePos.x < 0)
                        {
                         
                            transform.Translate(new Vector2(-speed * Time.deltaTime, 0));
                        }
                    //can move Right when onMoveRight is true
                    if (onMoveRight)
                        if (Input.GetMouseButton(0) && MousePos.x > 0)
                        {
                          
                            transform.Translate(new Vector2(speed * Time.deltaTime, 0));
                        }
                }
                //check the position of meteor
                if (transform.position.x >= limit)
                {
                    onMoveRight = false;
                }
                else if (transform.position.x <= limit)
                {
                    onMoveRight = true;
                }
                if (transform.position.x <= -limit)
                {
                    onMoveLeft = false;
                }
                else if (transform.position.x >= -limit)
                {
                    onMoveLeft = true;
                }
            }
            //when GameEnded or GameOver
            else if (gpm.GameOver)
            {
                sliderHealth.gameObject.SetActive(false);
                gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "HealthOrb")
        {
            SpriteRenderer spr = coll.gameObject.GetComponent<SpriteRenderer>();
            spr.sortingOrder = 101;
            StartCoroutine(ADDhealth());
            StartCoroutine(destroyObj(coll.gameObject));
            Instantiate(PickUp, coll.gameObject.transform);
            moveObj(coll.gameObject);
        }
        if (coll.gameObject.tag == "Asteroid")
        {
            StartCoroutine(decreaseHealth());
            StartCoroutine(Damaged());
            Instantiate(Explotion, coll.gameObject.transform);
            AsteroController astero = coll.GetComponent<AsteroController>();
            astero.cracked();
        }
    }


    public void checkHealth()
    {
        if (health <= 0)
        {
            gpm.GameOver = true;
        }
        
    }

    public void moveObj(GameObject obj)
    {
        obj.transform.DOMove(new Vector2( Target.gameObject.transform.position.x, Target.gameObject.transform.position.y), 0.5f, false);
    }

    IEnumerator decreaseHealth()
    {
        health -= damageVal;
        checkHealth();
        for (int i = 0; i < damageVal; i++)
        {
            sliderHealth.value -= 1;
            yield return new WaitForSeconds(0.005f);
        }
        
    }

    IEnumerator Damaged()
    {
        if (!gpm.pause)
        {
            Sequence sq = DOTween.Sequence();
            sq.Prepend(img.DOColor(new Vector4(1, 0, 0, 1), 0.2f));
            sq.Append(img.DOColor(new Vector4(0, 0, 0, 0), 0.2f));
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator ADDhealth()
    {
        if (!gpm.pause)
        {
            if (sliderHealth.value >= sliderHealth.maxValue)
            {
                sliderHealth.value = sliderHealth.maxValue;
            }
            else
            {
                for (int i = 0; i < healVal; i++)
                {
                    health = health + 1;
                    sliderHealth.value = health;
                    yield return new WaitForSeconds(0.005f);
                }
            }
        }
          
    }
    public IEnumerator destroyObj(GameObject obj)
    {
        if (!gpm.pause)
        {

            yield return new WaitForSeconds(0.5f);
            Destroy(obj.gameObject);
        }
    }

    public IEnumerator tutorial()
    {
        yield return new WaitForSeconds(2f);
        left.GetComponent<RawImage>().DOColor(new Vector4(0, 0, 0, 0), 0.5f);
        right.GetComponent<RawImage>().DOColor(new Vector4(0, 0, 0, 0), 0.5f);
        tutorialText.DOColor(new Vector4(0, 0, 0, 0), 0.5f);
        
    }
}
