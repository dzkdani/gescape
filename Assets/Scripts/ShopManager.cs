using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ShopManager : MonoBehaviour
{
    GameManager GM;
    public bool CharBool, EnemyBool, BgBool, IAPBool = false;
    public GameObject[] panel;
    public Button[] btn;
    public Text CoinShown;
    public int buyAchive;

    [Header("Characters Properties")]
    public GameObject[] CharabuyBtn;
    public GameObject[] usedCharaImg;
    
    [Header("Obstacle Properties")]
    public GameObject[] ObsbuyBtn;
    public GameObject[] usedObsImg;

    [Header("Background Properties")]
    public GameObject[] BGbuyBtn;
    public GameObject[] usedBGImg;



    // Start is called before the first frame update
    void Start()
    {
        GM = FindObjectOfType<GameManager>();
        CharBool = true;
        panel[0].SetActive(true);
        UpPosisition(0);
        UpdateCoin();
        buyedChara();
        usedOnChara();
        buyedObs();
        usedOnObs();
        buyedBG();
        usedOnBG();
        buyAchive = PlayerPrefs.GetInt("BuyAchieve", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateCoin()
    {
        CoinShown.text = "" + GM.Coins + "";
    }

    public void CharacterPanel()
    {
        CharBool = true;
        EnemyBool = false;
        BgBool = false;
        IAPBool = false;

        if(CharBool == true)
        {
            panel[0].SetActive(true);
            panel[1].SetActive(false);
            panel[2].SetActive(false);
            panel[3].SetActive(false);
        }

    }

    public void EnemyPanel()
    {
        CharBool = false;
        EnemyBool = true;
        BgBool = false;
        IAPBool = false;

        if (EnemyBool == true)
        {
            panel[0].SetActive(false);
            panel[1].SetActive(true);
            panel[2].SetActive(false);
            panel[3].SetActive(false);
        }
    }

    public void BackgroundPanel()
    {
        CharBool = false;
        EnemyBool = false;
        BgBool = true;
        IAPBool = false;

        if (BgBool == true)
        {
            panel[0].SetActive(false);
            panel[1].SetActive(false);
            panel[2].SetActive(true);
            panel[3].SetActive(false);
        }
    }

    public void IAPPanel()
    {
        CharBool = false;
        EnemyBool = false;
        BgBool = false;
        IAPBool = true;

        if (IAPBool == true)
        {
            panel[0].SetActive(false);
            panel[1].SetActive(false);
            panel[2].SetActive(false);
            panel[3].SetActive(true);
        }
    }

    public void BackPosisition(int val)
    {
       for (int i =0; i < btn.Length; i++)
        {
            if( i != val)
            {
                btn[i].transform.DOMoveY(15, 0.5f, false);
            } 
        }
    }
    public void UpPosisition(int val)
    {
        btn[val].transform.DOMoveY(30, 0.5f, false);
        BackPosisition(val);
    }

    public void CheckBuy()
    {
        buyAchive += 1;
        PlayerPrefs.SetInt("BuyAchieve", buyAchive);

        if (buyAchive >= 5 && buyAchive < 10)
        {
            GM.saveAchive(6, 1);
        }
        else if (buyAchive >= 10 && buyAchive < 15)
        {
            GM.saveAchive(7, 1);
        }
        else if (buyAchive >= 15)
        {
            GM.saveAchive(8, 1);
        }
    }

    public void buyChara(int id)
    {
        PriceManager PM = CharabuyBtn[id].GetComponent<PriceManager>();
        if (PM != null)
            if (GM.Coins >= PM.Price)
            {
                GM.Coins -= PM.Price;
                GM.saveCoins();
                UpdateCoin();
                GM.saveBuyedChara(id, 1);
                CharabuyBtn[id].SetActive(false);
                CheckBuy();
            }
            else
            {

            }

    }
    public void usedChara(int id)
    {
        GM.Chara = id;
        GM.saveChar();
        usedOnChara();
    }
    public void buyedChara()
    {
        for (int i=0; i < CharabuyBtn.Length; i++)
        {
            if(GM.buyedChara[i] == 1)
            {
                CharabuyBtn[i].SetActive(false);
            }
            else if (GM.buyedChara[i] == 0)
            {
                CharabuyBtn[i].SetActive(true);
            }
        }
    }
    public void usedOnChara()
    {
        for(int i=0; i < usedCharaImg.Length; i++)
        {
            if(GM.Chara == i)
            {
                usedCharaImg[i].SetActive(true);
            }
            else if(GM.Chara != i)
            {
                usedCharaImg[i].SetActive(false);
            }
        }
    }

    public void buyObs(int id)
    {
        PriceManager PM = ObsbuyBtn[id].GetComponent<PriceManager>();
        if(PM != null)
            if (GM.Coins >= PM.Price)
            {
                GM.Coins -= PM.Price;
                GM.saveCoins();
                UpdateCoin();
                GM.saveBuyedObs(id, 1);
                ObsbuyBtn[id].SetActive(false);
                CheckBuy();
            }
            else
            {

            }

    }
    public void usedObs(int id)
    {
        GM.Obs = id;
        GM.saveObs();
        usedOnObs();
    }
    public void buyedObs()
    {
        for (int i = 0; i < ObsbuyBtn.Length; i++)
        {
            if (GM.buyedObs[i] == 1)
            {
                ObsbuyBtn[i].SetActive(false);
            }
            else if (GM.buyedObs[i] == 0)
            {
                ObsbuyBtn[i].SetActive(true);
            }
        }
    }
    public void usedOnObs()
    {
        for (int i = 0; i < usedObsImg.Length; i++)
        {
            if (GM.Obs == i)
            {
                usedObsImg[i].SetActive(true);
            }
            else if (GM.Obs != i)
            {
                usedObsImg[i].SetActive(false);
            }
        }
    }

    public void buyBG(int id)
    {
        PriceManager PM = BGbuyBtn[id].GetComponent<PriceManager>();
        if (PM != null)
            if (GM.Coins >= PM.Price)
            {
                GM.Coins -= PM.Price;
                GM.saveCoins();
                UpdateCoin();
                GM.saveBuyedBG(id, 1);
                BGbuyBtn[id].SetActive(false);
                CheckBuy();
            }
            else
            {

            }

    }
    public void usedBG(int id)
    {
        GM.BG = id;
        GM.saveBG();
        usedOnBG();
    }
    public void buyedBG()
    {
        for (int i = 0; i < BGbuyBtn.Length; i++)
        {
            if (GM.buyedBG[i] == 1)
            {
                BGbuyBtn[i].SetActive(false);
            }
            else if (GM.buyedBG[i] == 0)
            {
                BGbuyBtn[i].SetActive(true);
            }
        }
    }
    public void usedOnBG()
    {
        for (int i = 0; i < usedBGImg.Length; i++)
        {
            if (GM.BG == i)
            {
                usedBGImg[i].SetActive(true);
            }
            else if (GM.BG != i)
            {
                usedBGImg[i].SetActive(false);
            }
        }
    }

    public void playSFX()
    {
        GM.playSFX();
    }

}
