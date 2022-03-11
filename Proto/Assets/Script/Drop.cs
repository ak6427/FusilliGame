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
    private GameScore gameScore;
    private PenaltySpawn penaltySpawn;
    [SerializeField]
    private GameObject prefabPenalty;
    private int rankPenalty = 0;

    private void Awake() {
        image=GetComponent<Image>();
        canvasGroup=GetComponent<CanvasGroup>();
        gameScore = FindObjectOfType<GameScore>();
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

                //PENALTY
                rankPenalty = Mathf.Abs(rankBox - eventData.pointerDrag.GetComponent<DragDrop>().rankFood) * 3;

                gameScore.timeR -= rankPenalty;

                SpawnPenalty(rankPenalty);
            }

        }
    }
    private void SpawnPenalty(int rankPenalty) 
    {
        Vector3 penaltyPosition = transform.position;
        penaltyPosition.x += 172;
        penaltyPosition.y += 36;

        Instantiate(prefabPenalty, penaltyPosition, transform.rotation);   
        penaltySpawn = FindObjectOfType<PenaltySpawn>();
        penaltySpawn.retrievePenalty = rankPenalty;
        penaltySpawn.transform.SetParent(gameObject.transform, false);
    }

}
