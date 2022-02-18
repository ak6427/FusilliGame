using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Threading.Tasks;
public class Drop : MonoBehaviour, IDropHandler
{
    [SerializeField] private int Value;
    private CanvasGroup canvasGroup;
    private Image image;
    private void Awake() {
        image=GetComponent<Image>();
        canvasGroup=GetComponent<CanvasGroup>();
    }
    public void OnDrop(PointerEventData eventData){
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null){
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            if (Value == eventData.pointerDrag.GetComponent<DragDrop>().Value){
                image.color = Color.green;
                canvasGroup.blocksRaycasts = false;
                eventData.pointerDrag.GetComponent<DragDrop>().Correct = 1;
                 /*if (eventData.pointerDrag.GetComponent<HealthClimateRanking>().myHealthRanking == PyramidArrays.pyramidEz[GetComponent<PyramidPosition>().myPosition][1])
            {
                PyramidArrays.pyramidEz[GetComponent<PyramidPosition>().myPosition][0] = 1;
                Debug.Log("Success.");
            }
            else 
            {
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = eventData.pointerDrag.GetComponent<MyCoordinates>().myLastCoordinates;
                Debug.Log("Fail.");
            }*/
            }
            else{
                image.color = Color.red;
            }

        }
    }
}
