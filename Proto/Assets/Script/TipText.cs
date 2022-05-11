using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TipText : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    public TextMeshProUGUI tipText;
    public RectTransform tipWindow;
    public static Action<string, Vector2> OnPointerDown;
    public static Action OnPointerDownLost;
    private float droid;

    private RectTransform canvasRectTransform;
    
    private void OnEnable(){
        OnPointerDown += ShowTip;
        OnPointerDownLost += HideTip;

    }
    private void OnDisable(){
        OnPointerDown -= ShowTip;
        OnPointerDownLost -= HideTip;

    }

    void Awake()
    {
        canvasRectTransform = canvas.GetComponent<RectTransform>();
    }
    void Start()
    {
        HideTip();
        
        Debug.Log("screenX: " + Screen.width);
        Debug.Log("screenY: " + Screen.height);
        Debug.Log("canvasX: " + canvasRectTransform.rect.width);
        Debug.Log("canvasY: " + canvasRectTransform.rect.height);
        Debug.Log("canvasScaleX: " + (canvasRectTransform.rect.width * canvasRectTransform.localScale.x));
        Debug.Log("canvasScaleY: " + (canvasRectTransform.rect.height * canvasRectTransform.localScale.y));
    }
    private void ShowTip(string tip, Vector2 MousePos){

        tipText.text = tip;
        tipWindow.sizeDelta = new Vector2(tipText.preferredWidth > 10000 ? 10000 : tipText.preferredWidth, tipText.preferredHeight);
        tipWindow.gameObject.SetActive(true);
    }
    
    private void HideTip(){
        tipText.text=default;
        tipWindow.gameObject.SetActive(false);
    }

}
