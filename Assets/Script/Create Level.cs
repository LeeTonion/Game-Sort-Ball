using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CreateLevel : MonoBehaviour
{
    public static CreateLevel instance;
    [SerializeField] private Button prefabButtonLevel;
    [SerializeField] private GameObject prefabPageLevel;
    [SerializeField] private Transform pageContainer;
    [SerializeField] private Button lockButtonLevel;
    public int maxPage;
    [SerializeField] private GameObject menuLevel;
    [SerializeField] private GameObject menu;


    private void Awake()
    {
        
        instance = this;
        
    }


    public void GenerateLevelPages()
    {
        int totalLevels = GameManager.instance.levelGame.Length;
        int levelsPerPage = 6;
        maxPage = Mathf.CeilToInt((float)totalLevels / levelsPerPage);


        for (int i = 0; i < maxPage; i++)
        {
            GameObject page = Instantiate(prefabPageLevel, pageContainer);

            for (int j = 0; j < levelsPerPage; j++)
            {
                int levelIndex = i * levelsPerPage + j;
                if (levelIndex >= totalLevels) break;
                
                    GameObject button = Instantiate(prefabButtonLevel, page.transform).gameObject;
                    button.GetComponentInChildren<TextMeshProUGUI>().text = (levelIndex + 1).ToString();
                    button.GetComponent<Button>().onClick.AddListener(() => 
                    { 
                        GameManager.instance.StartLevelGame(levelIndex);
                        Clean();
                    });
                if (GameManager.instance.levelGame[levelIndex].Unlock == false )
                {
                    button.GetComponent<Button>().interactable = false;
                }
                else
                {
                    button.GetComponent<Button>().interactable = true;
                }
                

            }
        }
    }
    public void ButtonHome()
    {

        Clean();
        menu.SetActive(true);
    }
    private void Clean()
    {
    foreach (Transform child in pageContainer.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
            menuLevel.SetActive(false);
    }


}
