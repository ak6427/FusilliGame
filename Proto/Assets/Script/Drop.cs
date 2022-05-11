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
    private bool penalty;
    public Color myColor;

    private AudioSource audioSource;

    private void Awake() 
    {
        image=GetComponent<Image>();
        canvasGroup=GetComponent<CanvasGroup>();
        gameScore = FindObjectOfType<GameScore>();
        foodsTargetPyramid = FindObjectOfType<TargetPyramid>();
        foodsTargetPyramid = foodsTargetPyramid.GetComponent<TargetPyramid>();
        myColor = image.color;
        audioSource = GetComponent<AudioSource>();
    }

    public void OnDrop(PointerEventData eventData) 
    {

        bool samePyramid = boxPartOfPyramid == eventData.pointerDrag.GetComponent<DragDrop>().targetPyramid;

        // image.color = new Color(image.color.r, image.color.g, image.color.b, 1);

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
                    
                    eventData.pointerDrag.GetComponent<AudioSource>().Play();

                    rankPenalty = 1;

                    gameScore.timeR += rankPenalty;

                    penalty = false;

                    SpawnPenalty(rankPenalty, penalty);
                }
                else 
                {
                    image.color = Color.red;
                    eventData.pointerDrag.GetComponent<DragDrop>().myBox = gameObject;
                    eventData.pointerDrag.GetComponent<DragDrop>().myBoxImage = image;
                    eventData.pointerDrag.GetComponent<DragDrop>().myBoxColor = myColor;
                    eventData.pointerDrag.GetComponent<DragDrop>().myBoxAnchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                    
                    audioSource.Play();

                    //PENALTY
                    rankPenalty = Mathf.Abs(rankBox - eventData.pointerDrag.GetComponent<DragDrop>().rankFood) * 2;

                    gameScore.timeR -= rankPenalty;

                    penalty = true;

                    SpawnPenalty(rankPenalty, penalty);
                }
            }
            else
            {
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = eventData.pointerDrag.GetComponent<DragDrop>().lastCoords;
            }
        }
    }

    private void SpawnPenalty(int rankPenalty, bool penalty) 
    {
        Vector2 penaltyPosition = new Vector2(136, 64);

        Instantiate(prefabPenalty, penaltyPosition, transform.rotation);   
        penaltySpawn = FindObjectOfType<PenaltySpawn>();
        penaltySpawn.retrievePenalty = rankPenalty;
        penaltySpawn.transform.SetParent(gameObject.transform, false);
        if (penalty == true)
        {
            penaltySpawn.timePenalty.text = "-";
        }
        else 
        {
            penaltySpawn.timePenalty.color = new Color32(0, 255, 0, 255);
            penaltySpawn.timePenalty.text = "+";
        }
    }

    void Update()
    {
        if (foodsTargetPyramid.foodTargetPyramid != "" && boxPartOfPyramid != foodsTargetPyramid.foodTargetPyramid)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
        }
        if (foodsTargetPyramid.resetAlpha == true) 
        {
            if (image.color.r != 1 && image.color.g != 1)
            {
                image.color = new Color(image.color.r, image.color.g, image.color.b, 0.5f);
            }
            else
            {
                image.color = new Color(image.color.r, image.color.g, image.color.b, 1);
            }
        }
    }
}
