/*created by Rahmat MPR*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;
	public int BestScore;
    public int Coins;
	public AudioSource SfxAu,BGM;
	public float SoundVal;
	public int Chara, BG, Obs;
	public int ADS;
	public int[] achive = new int[12];
	public int[] pressedAchive = new int[12];
	public int[] buyedChara = new int [9];
	public int[] buyedObs = new int[9];
	public int[] buyedBG = new int[9];
	//check this instance
	void Awake()
	{
		if (instance == null)
		{
			DontDestroyOnLoad(this.gameObject);
			instance = this;
		}

		else if (instance != this)
		{
			Destroy(gameObject);
			return;
		}
		loadAll();
	}
	// Start is called before the first frame update
	void Start()
    {
		
	}
	// Update is called once per frame
	void Update()
    {
		if (Input.GetKeyDown(KeyCode.Escape) || Input.backButtonLeavesApp)
		{
			saveSound();
			saveADS();
			saveChar();
			saveCoins();
			saveBG();
			saveObs();
			Application.Quit();
		}
		
	}

	public void loadAll()
    {
		loadBestScore();
		loadSound();
		loadCoins();
		loadBG();
		loadChar();
		loadObs();
		loadADS();
		loadAchive();
		loadPressedAchive();
		loadBuyedChara();
		loadBuyedObs();
		loadBuyedBG();
	}
	public void saveADS()
	{
		PlayerPrefs.SetInt("ADS", ADS);
	}
	public void loadADS()
	{
		ADS = PlayerPrefs.GetInt("ADS", 0);
	}
	public void saveChar()
	{
		PlayerPrefs.SetInt("Chara", Chara);
	}
	public void loadChar()
	{
		 Chara = PlayerPrefs.GetInt("Chara", 0);
	}
	public void saveBG()
	{
		PlayerPrefs.SetInt("BG", BG);
	}
	public void loadBG()
	{
		BG = PlayerPrefs.GetInt("BG", 0);
	}
	public void saveObs()
	{
		PlayerPrefs.SetInt("Obs", Obs);
	}
	public void loadObs()
	{
		Obs = PlayerPrefs.GetInt("Obs", 0);
	}
	public void saveCoins()
    {
        PlayerPrefs.SetInt("Coin", Coins);
		CheckCoins();
    }
	public void CheckCoins()
	{
		if (Coins >= 1000)
		{
			saveAchive(9, 1);
		}
		if (Coins >= 5000)
		{
			saveAchive(10, 1);
		}
		if (Coins >= 10000)
		{
			saveAchive(11, 1);
		}
	}
	public void loadCoins()
    {
        Coins = PlayerPrefs.GetInt("Coin", 0);
    }
	//load The Best Score
	public void loadBestScore()
    {
		BestScore = PlayerPrefs.GetInt("BestScore", 0);
	}
	//save the Best Score
	public void saveBestScore(int val)
    {
		PlayerPrefs.SetInt("BestScore",val);
    }
    public void loadSound()
    {
		SoundVal = PlayerPrefs.GetFloat("Sound", 1);
		SfxAu.volume = SoundVal;
		BGM.volume = SoundVal;
	}
	public void saveSound()
    {
		PlayerPrefs.SetFloat("Sound", SoundVal);
	}
	public void setSound(float set)
    {
		SoundVal = set;
		SfxAu.volume = SoundVal;
		BGM.volume = SoundVal;
	}
    public void playSFX()
    {
		SfxAu.Play();
    }

	public void loadAchive()
    {
		for(int i = 0; i < achive.Length; i++)
        {
			achive[i] = PlayerPrefs.GetInt("achive" + i, 0);
			//Debug.Log(achive[i]);
        }
    }

	public void saveAchive(int urutan, int val)
    {
		PlayerPrefs.SetInt("achive"+urutan, val);
    }

	public void loadPressedAchive()
	{
		for (int i = 0; i < pressedAchive.Length; i++)
		{
			pressedAchive[i] = PlayerPrefs.GetInt("pressedAchive" + i, 0);
			//Debug.Log(pressedAchive[i]);
		}
	}
	public void savepressedAchive(int urutan, int val)
	{
		Debug.Log("ges");
		PlayerPrefs.SetInt("pressedAchive" + urutan, val);
	}

	public void loadBuyedChara()
	{
		for (int i = 0; i < buyedChara.Length; i++)
		{
            if (i == 0)
            {
				buyedChara[0] = PlayerPrefs.GetInt("buyedChara" + 0, 1);

			}
            else if (i != 0)
            {
				buyedChara[i] = PlayerPrefs.GetInt("buyedChara" + i, 0);
			}
		}
	}
	public void saveBuyedChara(int urutan, int val)
    {
		Debug.Log("ges");
		PlayerPrefs.SetInt("buyedChara" + urutan, val);
	}

	public void loadBuyedObs()
	{
		for (int i = 0; i < buyedObs.Length; i++)
		{
			if (i == 0)
			{
				buyedObs[0] = PlayerPrefs.GetInt("buyedObs" + 0, 1);

			}
			else if (i != 0)
			{
				buyedObs[i] = PlayerPrefs.GetInt("buyedObs" + i, 0);
			}
		}
	}
	public void saveBuyedObs(int urutan, int val)
	{
		PlayerPrefs.SetInt("buyedObs" + urutan, val);
	}
	public void loadBuyedBG()
	{
		for (int i = 0; i < buyedBG.Length; i++)
		{
			if (i == 0)
			{
				buyedBG[0] = PlayerPrefs.GetInt("buyedBG" + 0, 1);

			}
			else if (i != 0)
			{
				buyedBG[i] = PlayerPrefs.GetInt("buyedBG" + i, 0);
			}
		}
	}
	public void saveBuyedBG(int urutan, int val)
	{
		PlayerPrefs.SetInt("buyedBG" + urutan, val);
	}

	public void resetSave()
    {
		PlayerPrefs.DeleteAll();
    }
}
