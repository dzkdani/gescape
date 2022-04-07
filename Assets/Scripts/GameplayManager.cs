/*created by Rahmat MPR*/
using System.Collections;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour
{

    [Header("Increment Component")]
    public float ScoreInc = 0.1f;
    public float AsteroidSpeed = 2.0f;
    public float bg1Speed = 2.5f;
    public float bg2Speed = 1.0f;
    [Space(15)]

    GameManager Gm;
    public bool start = false;
    public bool GameOver = false;
    public int Score = 0;
    public int Coin = 0;
    public int BestScore;
    public Text ScoreText;
    public Text LoseScoreText;
    public GameObject newBestScore;
    bool hit = false;
    public int play;
    public Text text;
    public float theTime;
    public float speed = 1;

    public GameObject LosePanel;

    public bool MainMenu = false;
    public bool pause = false;
    bool Checked =false;

    // Start is called before the first frame update
    void Start()
    {
        if (!pause)
            if (!MainMenu)
            {
                Gm = FindObjectOfType<GameManager>();
                if (Gm != null)
                    BestScore = Gm.BestScore;
                StartCoroutine(incrementScore());
                StartCoroutine(IncrementScoreCond());
            }
    }

    // Update is called once per frame
    void Update()
    {
        if (!pause)
        {
            if (!MainMenu)
            {
                if (!GameOver)
                {
                    ScoreText.text = "" + Score + "";

                    theTime += Time.deltaTime;
                    string hours = Mathf.Floor((theTime % 216000) / 3600).ToString("00");
                    string minute = Mathf.Floor((theTime % 3600) / 60).ToString("00");
                    string second = (theTime % 60).ToString("00");
                    text.text = hours + ":" + minute + ":" + second;
                    checkAchieve();
                }
                if (GameOver)
                {
                    if (!Checked)
                    {
                        checktheScore();
                        LosePanel.SetActive(true);
                        Checked = true;
                        Debug.Log(theTime);
                    }

                }

            }
        }
            
    }

    public void setPause(bool set)
    {
        pause = set;
    }
    public void checktheScore()
    {
        if (Score > BestScore)
        {
            ScoreText.gameObject.SetActive(false);
            LoseScoreText.text = ""+Score+"";
            BestScore = Score;
            Gm.saveBestScore(BestScore);
            newBestScore.SetActive(true);
        //    checkAchieve();
        }
        else
        {
            ScoreText.gameObject.SetActive(false);
            LoseScoreText.text = "" + Score + "";
            newBestScore.SetActive(false);
        }
        Debug.Log(Gm.Coins);
        CalculateCoin(Score);
    }

    public void checkAchieve()
    {
        if (hit == false)
        {
            if (theTime >= 600)
            {
                Gm.saveAchive(3, 1);
            }
            if (theTime >= 1200)
            {
                Gm.saveAchive(4, 1);
            }
            if (theTime >= 1800)
            {
                Gm.saveAchive(5, 1);
            }
        }
    }

    public void CalculateCoin(float score)
    {
        int coin = 0;
        coin = (int)score / 10;
        Coin = coin;
        Gm.Coins += Coin;
        Gm.saveCoins();
    }

    IEnumerator incrementScore()
    {
        
            while (!GameOver)
            {
            yield return new WaitForSeconds(ScoreInc);
            Score += 1;
            }
        
    }

    IEnumerator IncrementScoreCond()
    {
        if (!GameOver)
        {
            bool stop = false;
            while (!stop)
            {
                yield return new WaitForSeconds(30);
                Debug.Log("incremented");
                AsteroidSpeed -= 0.3f;
                bg1Speed -= 0.15f;
                bg2Speed -= 0.2f;
                if (ScoreInc > 0.01f)
                {
                    ScoreInc -= 0.01f;
                }
            }
        }
    }
    public void cekPlay()
    {
        play += 1;
        PlayerPrefs.SetInt("play", play);

        if (play >= 10 && play < 20)
        {
            Gm.saveAchive(0, 1);
        }

        else if (play >= 20 && play < 30)
        {
            Gm.saveAchive(1, 1);
        }

        else if (play >= 30)
        {
            Gm.saveAchive(2, 1);
        }
    }
    public void playSFX()
    {
        Gm.playSFX();
    }
}
