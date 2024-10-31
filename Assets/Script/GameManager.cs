using System.Collections;
using System.Collections.Generic;
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
    }
    void Start()
    {
        levelGame[numlever].CreateLevel();
    }

    void Update()
    {

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

        foreach(Transform child in listRowGO.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        tubes.Clear();
        NextLever.SetActive(true);
    }
    public void Nextlever()
    {
        NextLever.SetActive(false);
        numlever++;
        levelGame[numlever].CreateLevel();
    }
}