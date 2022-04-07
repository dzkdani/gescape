using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class SpawnerController : MonoBehaviour
{
    public float timer;
    public float lowRange, highRange;
    GameplayManager gpm;
    public float limit = 2.2f;
    public GameObject[] spawnObj;
    public bool mainMenu = false;
    public bool obstacle = false;
    // Start is called before the first frame update
    void Start()
    {
        gpm = FindObjectOfType<GameplayManager>();
        StartCoroutine(decreaseSpawnTime());
      

    }

    // Update is called once per frame
    void Update()
    {
        if (!gpm.pause)
        {
            if (!gpm.MainMenu)
            {
                if (!gpm.GameOver)
                {
                    timer -= Time.deltaTime;
                    if (timer <= 0)
                    {
                        //spawn
                        instaceObj();
                    }
                }

            }
            else if (gpm.MainMenu)
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    //spawn
                    instaceObj();
                }
            }
        }
    }
    void instaceObj()
    {
        if (obstacle)
        {
            int rand = Random.Range(0, 1000);
            Debug.Log(rand);
            if (rand <= 200)
            {
                
                Instantiate(spawnObj[Random.Range(0, 4)], new Vector2(Random.Range(-limit, limit), transform.position.y), Quaternion.identity);
                timer = Random.Range(lowRange, highRange);
            }
            else
            {
                Instantiate(spawnObj[Random.Range(5, spawnObj.Length)], new Vector2(Random.Range(-limit, limit), transform.position.y), Quaternion.identity);
                timer = Random.Range(lowRange, highRange);
            }
        }
        else
        {
            Instantiate(spawnObj[Random.Range(0, spawnObj.Length)], new Vector2(Random.Range(-limit, limit), transform.position.y), Quaternion.identity);
            timer = Random.Range(lowRange, highRange);
        }

    }

    IEnumerator decreaseSpawnTime()
    {
        if(!gpm.pause)
            while (!gpm.MainMenu)
            {
                yield return new WaitForSeconds(30);
                if (lowRange > (lowRange / 4))
                {
                    lowRange -= 0.2f;

                }
                if (highRange > (highRange / 4))
                {
                    highRange -= 0.2f;
                }
            }
    }
}
