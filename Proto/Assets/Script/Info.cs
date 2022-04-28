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
    public RectTransform GameBackground;

    [SerializeField]
    public GameObject MenuBackground;

    [SerializeField]
    public GameObject pageOne;

    public RectTransform pageOneAnchor;

    [SerializeField]
    public RectTransform pageOneAnimation;

    [SerializeField]
    private RectTransform tut1Text;

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

    private int localeToggle = 0;

    void Awake()
    {
        sceneSaver = FindObjectOfType<SceneSaver>();
        pageOneAnchor = pageOne.GetComponent<RectTransform>();
        myRect = GetComponent<RectTransform>();
    }

    void Start()
    {
        if (sceneSaver.hideMenuBackground)
        {
            MenuBackground.SetActive(false);
        }

        currentPage = sceneSaver.levelPage;

        float ratioX = ((float) Screen.width / 1920);
        float ratioY = ((float) Screen.height / 1080);

        Debug.Log(ratioX);
        Debug.Log(ratioY);

        // Scale and Anchor
        if (ratioX >= ratioY)
        {
            pageOneAnimation.localScale = new Vector3(sceneSaver.pageOneScale * ratioX / pageOneAnchor.lossyScale.x, sceneSaver.pageOneScale * ratioY / pageOneAnchor.lossyScale.y, 0);
            pageOneAnchor.anchoredPosition = new Vector3(pageOneAnchor.anchoredPosition.x / pageOneAnchor.lossyScale.x, pageOneAnchor.anchoredPosition.y / pageOneAnchor.lossyScale.y, 0); 
            tut1Text.anchoredPosition = new Vector3(tut1Text.anchoredPosition.x / tut1Text.lossyScale.x, tut1Text.anchoredPosition.y / tut1Text.lossyScale.y, 0); 
            pageTwoImage.localScale = new Vector3(ratioX / pageOneAnchor.lossyScale.x, ratioY / pageOneAnchor.lossyScale.y, 0);
            pageThreeImage.localScale = new Vector3(ratioX / pageOneAnchor.lossyScale.x, ratioY / pageOneAnchor.lossyScale.y, 0);
            pageFourImage.localScale = new Vector3(ratioX / pageOneAnchor.lossyScale.x, ratioY / pageOneAnchor.lossyScale.y, 0);
        }
        else
        {
            pageOneAnimation.localScale = new Vector3(sceneSaver.pageOneScale / ratioX / pageOneAnchor.lossyScale.x, sceneSaver.pageOneScale / ratioY * pageOneAnchor.lossyScale.y, 0);
            pageOneAnchor.anchoredPosition = new Vector3(pageOneAnchor.anchoredPosition.x * pageOneAnchor.lossyScale.x - 0.8f, pageOneAnchor.anchoredPosition.y * pageOneAnchor.lossyScale.y - 0.8f, 0); 
            tut1Text.anchoredPosition = new Vector3(tut1Text.anchoredPosition.x * tut1Text.lossyScale.x - 0.8f, tut1Text.anchoredPosition.y * tut1Text.lossyScale.y - 0.8f, 0); 
            pageTwoImage.localScale = new Vector3(ratioX / pageOneAnchor.lossyScale.x + 0.08f, ratioY / pageOneAnchor.lossyScale.y + 0.08f, 0);
            pageThreeImage.localScale = new Vector3(ratioX / pageOneAnchor.lossyScale.x + 0.08f, ratioY / pageOneAnchor.lossyScale.y + 0.08f, 0);
            pageFourImage.localScale = new Vector3(ratioX / pageOneAnchor.lossyScale.x + 0.08f, ratioY / pageOneAnchor.lossyScale.y + 0.08f, 0);
        }

        SetText();
    }

    public void SetText()
    {

        if (localeToggle != sceneSaver.localeToggle)
        {
            localeToggle = sceneSaver.localeToggle;
        }
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

        if (localeToggle != sceneSaver.localeToggle)
        {
            SetText();
        }
    }
}
