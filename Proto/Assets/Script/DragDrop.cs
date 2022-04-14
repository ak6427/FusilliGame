using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class DragDrop : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IBeginDragHandler, IEndDragHandler, IDragHandler  {
    [SerializeField] private Canvas canvas;
    [SerializeField] public int rankFood; //ruoka ranking
    [SerializeField] public int correct; //0 = false, 1 = true
    [SerializeField] public string targetPyramid;

    private RectTransform rectTransform;
    public CanvasGroup canvasGroup;
    private GameScore gameScore;
    public TargetPyramid foodsTargetPyramid;
    public Vector2 lastCoords;
    public GameObject button;
    private RectTransform buttonRectTransform;
    private RectTransform canvasRectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup=GetComponent<CanvasGroup>();
        gameScore=FindObjectOfType<GameScore>();
        foodsTargetPyramid = FindObjectOfType<TargetPyramid>();
        foodsTargetPyramid = foodsTargetPyramid.GetComponent<TargetPyramid>();
        button = GameObject.Find("Main Menu - button");
        buttonRectTransform = button.GetComponent<RectTransform>();
        canvasRectTransform = canvas.GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData) 
    {
        Debug.Log("OnBeginDrag");
        canvasGroup.alpha = .4f; 
        canvasGroup.blocksRaycasts = false;
        lastCoords = rectTransform.anchoredPosition;
    }

    public void OnEndDrag(PointerEventData eventData) 
    {
        Debug.Log("OnEndDrag");
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
        if (correct == 1)
        {
            canvasGroup.blocksRaycasts = false;
            gameScore.Score++;
            
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
        foodsTargetPyramid.foodTargetPyramid = targetPyramid;
        foodsTargetPyramid.resetAlpha = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("OnPointerUp");

        foodsTargetPyramid.resetAlpha = true;

        float foodX = rectTransform.anchoredPosition.x - rectTransform.rect.xMax + canvasRectTransform.rect.width / 2;
        float foodY = rectTransform.anchoredPosition.y - rectTransform.rect.yMax + canvasRectTransform.rect.height / 2;
        float buttonX = buttonRectTransform.rect.width;
        float buttonY = buttonRectTransform.rect.height;
        if(foodX < buttonX && foodY < buttonY)
        {
            rectTransform.anchoredPosition = lastCoords;
        }
    }
}