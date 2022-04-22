using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace db
{
public class DownTip : MonoBehaviour, IPointerDownHandler,IPointerUpHandler
{
    public FetchFood fetchFood;
    public string tip;
    private float WaitTime = 0.0f;
    private bool show = false;

    void Awake(){
        fetchFood = GetComponent<FetchFood>();
    }

    void Update()
    {
        if (show == true)
        {
            ShowTip();
        }
    }

    public void OnPointerDown(PointerEventData eventData){
        StopAllCoroutines();
        StartCoroutine(StartTimer());
    }

    public void OnPointerUp(PointerEventData eventData){
        StopAllCoroutines();
        TipText.OnPointerDownLost();
        show = false;
    }

    private void ShowTip(){
        tip = fetchFood.foodName;
        TipText.OnPointerDown(tip, Input.mousePosition);
    }

    private IEnumerator StartTimer(){
        yield return new WaitForSeconds(WaitTime);
        show = true;
        //ShowTip();

    }
}
}