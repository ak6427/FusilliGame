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
        tipWindow.sizeDelta = new Vector2(tipText.preferredWidth > 10000 ? 10000 : tipText.preferredWidth, tipText.preferredHeight);
        tipWindow.gameObject.SetActive(true);

        //tipWindow.transform.position = new Vector3(MousePos.x * 0.015625f, MousePos.y * 0.015625f + (64 * 0.015625f), 100);

        if (Application.platform == RuntimePlatform.Android)
        {
            float ratioX = ((float) Screen.width / 1920);
            float ratioY = ((float) tipWindow.lossyScale.y / 0.015625f);
            tipWindow.transform.position = new Vector3( MousePos.x / ratioX * tipWindow.lossyScale.x - 4.75f, MousePos.y / ratioY * tipWindow.lossyScale.y + (128 * tipWindow.lossyScale.y), canvas.planeDistance);
        }
        else 
        {
            tipWindow.transform.position = new Vector3(MousePos.x * tipWindow.lossyScale.x, MousePos.y * tipWindow.lossyScale.y + (64 * tipWindow.lossyScale.y), canvas.planeDistance);
        }
    }
    
    private void HideTip(){
        tipText.text=default;
        tipWindow.gameObject.SetActive(false);
    }
    
    
    
    // Start is called before the first frame update

}
