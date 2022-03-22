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
    
    
    
    private void OnEnable(){
        OnPointerDown += ShowTip;
        OnPointerDownLost += HideTip;

    }
    private void OnDisable(){
        OnPointerDown -= ShowTip;
        OnPointerDownLost -= HideTip;

    }
    void Start()
    {
        HideTip();
    }
    private void ShowTip(string tip, Vector2 MousePos){
        tipText.text = tip;
        tipWindow.sizeDelta = new Vector2(tipText.preferredWidth > 200 ? 200 : tipText.preferredWidth, tipText.preferredHeight);
        tipWindow.gameObject.SetActive(true);
        tipWindow.transform.position = new Vector2(MousePos.x + tipWindow.sizeDelta.x * 2 / canvas.scaleFactor, MousePos.y / canvas.scaleFactor);

    }
    
    private void HideTip(){
        tipText.text=default;
        tipWindow.gameObject.SetActive(false);
    }
    
    
    
    // Start is called before the first frame update

}
