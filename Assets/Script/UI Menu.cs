using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMenu : MonoBehaviour
{
    [SerializeField] private Button startBtn;
    [SerializeField] private Button levelBtn;
    [SerializeField] private GameObject menuLevel;

    private void Start()
    {
        startBtn.onClick.AddListener (() => {

            gameObject.SetActive (false);
            continueLevel();

        });
        levelBtn.onClick.AddListener(() => {
            
            gameObject.SetActive(false);
            menuLevel.SetActive (true);
            CreateLevel.instance.GenerateLevelPages();


        });
    }

    private void continueLevel()
    {
        for (int i = 0;i < GameManager.instance.levelGame.Length; i++)
        {
            
            if (GameManager.instance.levelGame[i].Complete == false && GameManager.instance.levelGame[i].Unlock  )
            { 
                GameManager.instance.StartLevelGame(i);
                break;
            }
            
            
        }
        
    }
}
