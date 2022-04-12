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
    public string boxPartOfPyramid;

    [SerializeField]
    private GameObject prefabPenalty;

    private int rankPenalty = 0;
    public TargetPyramid foodsTargetPyramid;

    private void Awake() 
    {
        image=GetComponent<Image>();
        canvasGroup=GetComponent<CanvasGroup>();
        gameScore = FindObjectOfType<GameScore>();
        foodsTargetPyramid = FindObjectOfType<TargetPyramid>();
        foodsTargetPyramid = foodsTargetPyramid.GetComponent<TargetPyramid>();
    }

    public void OnDrop(PointerEventData eventData) 
    {
        Debug.Log("OnDrop");

        bool samePyramid = boxPartOfPyramid == eventData.pointerDrag.GetComponent<DragDrop>().targetPyramid;

        image.color = new Color(image.color.r, image.color.g, image.color.b, 1);

        if (eventData.pointerDrag != null) 
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            if (samePyramid == true)
            {
                if (rankBox == eventData.pointerDrag.GetComponent<DragDrop>().rankFood) 
                {
                    image.color = Color.green;
                    canvasGroup.blocksRaycasts = false;
                    eventData.pointerDrag.GetComponent<DragDrop>().correct = 1;
                }
                else 
                {
                    image.color = Color.red;

                    //PENALTY
                    rankPenalty = Mathf.Abs(rankBox - eventData.pointerDrag.GetComponent<DragDrop>().rankFood) * 2;

                    gameScore.timeR -= rankPenalty;

                    SpawnPenalty(rankPenalty);
                }
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

    void Update()
    {
        Debug.Log("Check pyramid");
        if (foodsTargetPyramid.foodTargetPyramid != "" && boxPartOfPyramid != foodsTargetPyramid.foodTargetPyramid)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
        }
    }
}
