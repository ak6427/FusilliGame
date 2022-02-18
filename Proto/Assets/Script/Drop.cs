using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drop : MonoBehaviour, IDropHandler
{

    void Awake()
    {

    }

    void Start()
    {

    }

    public void OnDrop(PointerEventData eventData) {
        Debug.Log("OnDrop");

        if (eventData.pointerDrag != null) {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;

            if (eventData.pointerDrag.GetComponent<HealthClimateRanking>().myHealthRanking == PyramidArrays.pyramidEz[GetComponent<PyramidPosition>().myPosition][1])
            {
                PyramidArrays.pyramidEz[GetComponent<PyramidPosition>().myPosition][0] = 1;
                Debug.Log("Success.");
            }
            else 
            {
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = eventData.pointerDrag.GetComponent<MyCoordinates>().myLastCoordinates;
                Debug.Log("Fail.");
            }
        }
    }
}
