using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArchivManager : MonoBehaviour
{
    public GameObject[] panel;
    GameManager gm;
    

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        loadPanel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadPanel()
    {
        for (int i=0; i < panel.Length; i++)
        {
            if(gm.achive[i] == 1)
            {
                if(panel[i]!=null)
                   panel[i].SetActive(false);
            }
            else if(gm.achive[i] == 0)
            {
                if (panel[i] != null)
                    panel[i].SetActive(true);
            }
        }
    }

    public void playSFX()
    {
        gm.playSFX();
    }
}
