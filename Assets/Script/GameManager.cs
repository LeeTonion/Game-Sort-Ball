using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public List<Tube> tubes = new List<Tube>();

    public GameObject prefabTube;
    public GameObject prefabBall;
    public Sprite[] spriteBalls;
    public GameObject listTubeGO;
    public Tube currentTube;
    public LevelData[] levelGame;
    private int numlever = 0;
    public GameObject NextLever;
    public bool canmove = false;
    public GameObject prefabListTube, listRowGO;
    [SerializeField] private GameObject menuGamePlay;
    [SerializeField] private GameObject menu;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
    public void StartLevelGame(int Value)
    {
        numlever = Value;
        levelGame[Value].CreateLevel();
        menuGamePlay.GetComponentInChildren<TextMeshProUGUI>().text = "LEVEL " + (Value+1);
        menuGamePlay.SetActive(true);
    }


    public bool IsWin()
    {
        for (int i = 0; i < tubes.Count; i++)
        {
            if (tubes[i].isTubeNull)
            {
                continue;
            }
            if (!tubes[i].isFullTube)
            {
                return false;
            }
            else
            {
                Sprite spriteCompare = tubes[i].balls[0].GetComponent<Image>().sprite;
                for (int j = 1; j < tubes[i].balls.Count; j++)
                {
                    if (tubes[i].balls[j].GetComponent<Image>().sprite != spriteCompare)
                    {
                        return false;
                    }
                }
            }
        }
        Win();
        return true;
    }
    private void Win()
    {
        
        NextLever.SetActive(true);    
        levelGame[numlever].Complete = true;
        Clean();
    }
    public void Nextlever()
    {   
        
        NextLever.SetActive(false);
        numlever++;
        StartLevelGame(numlever);
        levelGame[numlever].Unlock = true;

    }
    public void Clean()
    {
        foreach (Transform child in listRowGO.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        
        tubes.Clear();
        menuGamePlay.SetActive(false);
    }

    public void ButtonHome()
    {
        Clean();
        menuGamePlay.SetActive(false );
        menu.SetActive(true);
    }
}