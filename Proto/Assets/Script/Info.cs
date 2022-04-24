using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Info : MonoBehaviour
{
    public RectTransform myRect;

    [SerializeField]
    public GameObject rightArrow;

    [SerializeField]
    public GameObject leftArrow;

    [SerializeField]
    public TMP_Text pageNumber;

    private SceneSaver sceneSaver;

    public int allPages = 4;

    public int currentPage;

    [SerializeField]
    public RectTransform background;

    [SerializeField]
    public GameObject pageOne;

    public RectTransform pageOneAnchor;

    [SerializeField]
    public RectTransform pageOneAnimation;

    [SerializeField]
    public GameObject pageTwo;

    [SerializeField]
    public RectTransform pageTwoImage;

    [SerializeField]
    public Sprite pageTwoImageFI;

    [SerializeField]
    public Sprite pageTwoImageEN;

    [SerializeField]
    public GameObject pageThree;

    [SerializeField]
    public RectTransform pageThreeImage;

    [SerializeField]
    public Sprite pageThreeImageFI;

    [SerializeField]
    public Sprite pageThreeImageEN;

    [SerializeField]
    public GameObject pageFour;

    [SerializeField]
    public RectTransform pageFourImage;

    [SerializeField]
    public Sprite pageFourImageFI;

    [SerializeField]
    public Sprite pageFourImageEN;

    void Awake()
    {
        sceneSaver = FindObjectOfType<SceneSaver>();
        pageOneAnchor = pageOne.GetComponent<RectTransform>();
        myRect = GetComponent<RectTransform>();
    }

    void Start()
    {
        currentPage = sceneSaver.levelPage;

        float ratioX = ((float) Screen.width / 1920);
        float ratioY = ((float) Screen.height / 1080);

        // Anchor
        pageOneAnchor.anchoredPosition = new Vector3(pageOneAnchor.anchoredPosition.x / pageOneAnchor.lossyScale.x, pageOneAnchor.anchoredPosition.y / pageOneAnchor.lossyScale.y, 0); 

        // Scale
        pageOneAnimation.localScale = new Vector3(sceneSaver.pageOneScale * ratioX / pageOneAnchor.lossyScale.x, sceneSaver.pageOneScale * ratioY / pageOneAnchor.lossyScale.y, 0);

        pageTwoImage.localScale = new Vector3(/*sceneSaver.pageOneScale **/ ratioX / pageOneAnchor.lossyScale.x, /*sceneSaver.pageOneScale **/ ratioY / pageOneAnchor.lossyScale.y, 0);
        pageThreeImage.localScale = new Vector3(/*sceneSaver.pageOneScale **/ ratioX / pageOneAnchor.lossyScale.x, /*sceneSaver.pageOneScale **/ ratioY / pageOneAnchor.lossyScale.y, 0);
        pageFourImage.localScale = new Vector3(/*sceneSaver.pageOneScale **/ ratioX / pageOneAnchor.lossyScale.x, /*sceneSaver.pageOneScale **/ ratioY / pageOneAnchor.lossyScale.y, 0);
    }

    public void TurnLeft()
    {
        currentPage -= 1;
    }

    public void TurnRight()
    {
        currentPage += 1;
    }

    void Update()
    {
        // page numbers
        pageNumber.text = currentPage + "/" + allPages;

        // Page De/Activate and arrow visibility
        if (currentPage == 1)
        {
            pageOne.SetActive(true);
            pageTwo.SetActive(false);
            pageThree.SetActive(false);
            pageFour.SetActive(false);
            leftArrow.SetActive(false);
            rightArrow.SetActive(true);
        }
        else if (currentPage == 2)
        {
            pageOne.SetActive(false);
            pageTwo.SetActive(true);
            pageThree.SetActive(false);
            pageFour.SetActive(false);
            leftArrow.SetActive(true);
            rightArrow.SetActive(true);
        }
        else if (currentPage == 3)
        {
            pageOne.SetActive(false);
            pageTwo.SetActive(false);
            pageThree.SetActive(true);
            pageFour.SetActive(false);
            leftArrow.SetActive(true);
            rightArrow.SetActive(true);
        }
        else if (currentPage == 4)
        {
            pageOne.SetActive(false);
            pageTwo.SetActive(false);
            pageThree.SetActive(false);
            pageFour.SetActive(true);
            leftArrow.SetActive(true);
            rightArrow.SetActive(false);
        }
    }
}
