using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SwipeController : MonoBehaviour, IEndDragHandler
{

    private int currentPage;
    Vector3 targetPos;

    [SerializeField] private Vector3 pageStep;
    [SerializeField] RectTransform levelPagesRect;
    [SerializeField] private LeanTweenType tweenType;

    [SerializeField] private float tweenTime;
    [SerializeField] Button previousBtn,nextBtn;

    private float dragThreshound;

    private void Awake()
    {
        currentPage = 1;
        targetPos = levelPagesRect.localPosition;
        dragThreshound = Screen.width / 15;
        UpdateArrowButton();
    }

    public void Next()
    {
        if (currentPage < CreateLevel.instance.maxPage)
        {
            currentPage++;
            targetPos += pageStep;
            MovePage();
        }
    }
    public void Previous() 
    {
        if(currentPage > 1)
        {
            currentPage--;
            targetPos -= pageStep;
            MovePage();
        }
    }
    void MovePage()
    {
        levelPagesRect.LeanMoveLocal(targetPos,tweenTime).setEase(tweenType);
        UpdateArrowButton();

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (Mathf.Abs(eventData.position.x - eventData.position.x) < dragThreshound)
        {
            if (eventData.position.x > eventData.position.x)
            {
                Previous();
            }
            else { Next();}
        }
        else
        {
            MovePage();
        }
    }
    private void UpdateArrowButton()
    {
        nextBtn.interactable = true;
        previousBtn.interactable = true;
        if(currentPage == 1)
        {
            previousBtn.interactable = false;
        }
        else if(currentPage == CreateLevel.instance.maxPage)
        {
            nextBtn.interactable = false;
        }
    }
}
