using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Threading.Tasks;
public class Drop : MonoBehaviour, IDropHandler
{
    [SerializeField] private int rankBox; //lokero ranking
    private CanvasGroup canvasGroup;
    private Image image;
    private void Awake() {
        image=GetComponent<Image>();
        canvasGroup=GetComponent<CanvasGroup>();
    }
    public void OnDrop(PointerEventData eventData) {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null) {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            if (rankBox == eventData.pointerDrag.GetComponent<DragDrop>().rankFood) {
                image.color = Color.green;
                canvasGroup.blocksRaycasts = false;
                eventData.pointerDrag.GetComponent<DragDrop>().correct = 1;
            }
            else {
                image.color = Color.red;
            }

        }
    }
}
