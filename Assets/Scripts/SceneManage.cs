/*created by Rahmat MPR*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class SceneManage : MonoBehaviour
{
    public GameObject FadeLayer;
    GameManager gm;
    public void GoToScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void retryRound()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Start()
    {
        gm = FindObjectOfType<GameManager>();
        fadeIn();
    }

    public void fadeIn()
    {
        RawImage img = FadeLayer.GetComponent<RawImage>();
        img.DOColor(new Vector4(0, 0, 0, 0), 0.5f);
        StartCoroutine(waitOffFade());
    }
    public IEnumerator waitOffFade()
    {
        yield return new WaitForSeconds(0.55f);
        FadeLayer.SetActive(false);
    }
    public void fadeOut(string SceneName)
    {
        Debug.Log("change");
        FadeLayer.SetActive(true);
        RawImage img = FadeLayer.GetComponent<RawImage>();
        img.DOColor(new Vector4(0, 0, 0, 1), 0.5f);
        StartCoroutine(waitTime(SceneName));
        
    }
    public void clickBtn()
    {
        gm.playSFX();
    }
     public IEnumerator waitTime(string SceneName)
    {
        yield return new WaitForSeconds(0.6f);
        GoToScene(SceneName);
    }
    
    public void addCoin(int uang)
    {
        gm.Coins += uang;
        gm.saveCoins();
    }


}
