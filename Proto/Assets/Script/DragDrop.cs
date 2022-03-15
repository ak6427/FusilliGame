using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler  {
    [SerializeField] private Canvas canvas;
    [SerializeField] public int rankFood; //ruoka ranking
    [SerializeField] public int correct; //0 = false, 1 = true
    private RectTransform rectTransform;
    public CanvasGroup canvasGroup;
    private GameScore gameScore;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup=GetComponent<CanvasGroup>();
        gameScore=FindObjectOfType<GameScore>();
    }

    public void OnBeginDrag(PointerEventData eventData) 
    {
        Debug.Log("OnBeginDrag");
        canvasGroup.alpha = .4f; 
        canvasGroup.blocksRaycasts = false;
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
    }

}
