using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchiveButton : MonoBehaviour
{
    public int Id;
    public GameObject ClaimedText;
    Button thisbtn;
    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        thisbtn = GetComponent<Button>();
        LoadAchiveButton();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadAchiveButton()
    {
        Debug.Log("ID : "+ gm.achive[Id] + " pressed : " + gm.pressedAchive[Id]);
       
        if (gm.achive[Id] == 0 && gm.pressedAchive[Id] == 0)
        {
            thisbtn.interactable = false;
            ClaimedText.SetActive(false);
        }
        else if(gm.achive[Id] == 1 && gm.pressedAchive[Id] == 0)
        {
            thisbtn.interactable = true;
            ClaimedText.SetActive(false);
        }
        else if(gm.achive[Id] == 1 && gm.pressedAchive[Id] == 1)
        {
            thisbtn.interactable = false;
            ClaimedText.SetActive(true);
        }
    }
    public void savePressedBtn(int IDnum)
    {
        Debug.Log("oy");
        gm.pressedAchive[IDnum] = 1;
        gm.savepressedAchive(IDnum, 1);
        LoadAchiveButton();
        thisbtn.interactable = false;
    }
}
