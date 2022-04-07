using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenuController : MonoBehaviour
{
    int play;
    public Text ScoreText;
    public Text CoinText;
    public GameObject SoundOn, SoundOff;
    GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        gm.loadBestScore();
        loadTheScore();
        gm.loadAll();
        play = PlayerPrefs.GetInt("play",0);
        Debug.Log("play : " + play);

        if (gm.SoundVal == 1)
        {
            SoundOn.SetActive(true);
            SoundOff.SetActive(false);
        }
        else if(gm.SoundVal == 0)
        {
            SoundOn.SetActive(false);
            SoundOff.SetActive(true);
        }

    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void loadTheScore()
    {
        ScoreText.text = ""+gm.BestScore+"";
        CoinText.text = "" + gm.Coins + "";
    }

    public void SetSound(float val)
    {
        gm.setSound(val);
        gm.saveSound();
    }

    public void playSFX()
    {
        gm.playSFX();
    }
}
