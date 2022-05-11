using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class DragDrop : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IBeginDragHandler, IEndDragHandler, IDragHandler  {
    [SerializeField] private Canvas canvas;
    [SerializeField] public int rankFood; //ruoka ranking
    [SerializeField] public int correct; //0 = false, 1 = true
    [SerializeField] public string targetPyramid;

    private AudioSource canvasAudioSource;

    private RectTransform rectTransform;
    public CanvasGroup canvasGroup;
    private GameScore gameScore;
    public TargetPyramid foodsTargetPyramid;
    public Vector2 lastCoords;
    public GameObject buttons;
    private RectTransform buttonsRectTransform;
    private RectTransform canvasRectTransform;
    public GameObject myBox; 
    public Image myBoxImage;
    public Color myBoxColor;
    public Vector2 myBoxAnchoredPosition;
    private RectTransform tipWindow;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup=GetComponent<CanvasGroup>();
        gameScore=FindObjectOfType<GameScore>();
        foodsTargetPyramid = FindObjectOfType<TargetPyramid>();
        foodsTargetPyramid = foodsTargetPyramid.GetComponent<TargetPyramid>();
        buttons = GameObject.Find("Buttons group");
        buttonsRectTransform = buttons.GetComponent<RectTransform>();
        canvasRectTransform = canvas.GetComponent<RectTransform>();
        canvasAudioSource = canvas.GetComponent<AudioSource>();
        tipWindow = GameObject.Find("TipWindow").GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData) 
    {
        canvasGroup.alpha = .4f; 
        canvasGroup.blocksRaycasts = false;
        lastCoords = rectTransform.anchoredPosition;
    }

    public void OnEndDrag(PointerEventData eventData) 
    {
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
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        if (eventData.pointerDrag != null)
        {
            tipWindow.anchoredPosition = new Vector2(eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition.x, eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition.y + 128);
        }
        if (myBox != null && rectTransform.anchoredPosition != myBoxAnchoredPosition)
        {
            //myBox.filled = false;
            myBoxImage.color = myBoxColor;
            myBox = null;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.pointerEnter != null)
        {
            tipWindow.anchoredPosition = new Vector2(eventData.pointerEnter.GetComponent<RectTransform>().anchoredPosition.x, eventData.pointerEnter.GetComponent<RectTransform>().anchoredPosition.y + 128);
        }
        foodsTargetPyramid.foodTargetPyramid = targetPyramid;
        foodsTargetPyramid.resetAlpha = false;
        canvasAudioSource.Play();
    }

    public void OnPointerUp(PointerEventData eventData)
    {

        foodsTargetPyramid.resetAlpha = true;

        float foodX = rectTransform.anchoredPosition.x + rectTransform.rect.xMax + canvasRectTransform.rect.width / 2;
        float foodY = rectTransform.anchoredPosition.y + rectTransform.rect.yMax + canvasRectTransform.rect.height / 2;
        float buttonX = canvasRectTransform.rect.width - buttonsRectTransform.rect.width;
        float buttonY = canvasRectTransform.rect.height - buttonsRectTransform.rect.height;
        if(foodX > buttonX && foodY > buttonY)
        {
            rectTransform.anchoredPosition = lastCoords;
        }
    }
}