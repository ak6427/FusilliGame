using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DownTip : MonoBehaviour, IPointerDownHandler,IPointerUpHandler
{
    
    public string tip;
    private float WaitTime = 0.5f;
    public void OnPointerDown(PointerEventData eventData){
        StopAllCoroutines();
        StartCoroutine(StartTimer());
    }

    public void OnPointerUp(PointerEventData eventData){
        StopAllCoroutines();
        TipText.OnPointerDownLost();
    }

    private void ShowTip(){
        TipText.OnPointerDown(tip, Input.mousePosition);
    }

    private IEnumerator StartTimer(){
        yield return new WaitForSeconds(WaitTime);
        ShowTip();

    }
}
