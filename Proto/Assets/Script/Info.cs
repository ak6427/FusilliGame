using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Info : MonoBehaviour
{
    public RectTransform myRect;

    public GameObject mainCamera;
    private Transform  mainCameraTransform;
    private Camera mainCameraCamera;

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
    private RectTransform pageTwoRect;

    [SerializeField]
    public RectTransform pageTwoImage;

    [SerializeField]
    public Sprite pageTwoImageFI;

    [SerializeField]
    public Sprite pageTwoImageEN;

    [SerializeField]
    public GameObject pageThree;
    private RectTransform pageThreeRect;

    [SerializeField]
    public RectTransform pageThreeImage;

    [SerializeField]
    public Sprite pageThreeImageFI;

    [SerializeField]
    public Sprite pageThreeImageEN;

    [SerializeField]
    public GameObject pageFour;
    private RectTransform pageFourRect;

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
        mainCameraTransform = mainCamera.GetComponent<Transform>();
        mainCameraCamera = mainCamera.GetComponent<Camera>();
        pageTwoRect = pageTwo.GetComponent<RectTransform>();
        pageThreeRect = pageThree.GetComponent<RectTransform>();
        pageFourRect = pageFour.GetComponent<RectTransform>();
    }

    void Start()
    {
        if (sceneSaver.hideMenuBackground)
        {
            MenuBackground.SetActive(false);
        }

        currentPage = sceneSaver.levelPage;

        // for camera size
        float canvasToScreenWidth = ((float) myRect.rect.width * ((float) 4/3) / Screen.width);
        float canvasToScreenHeight = ((float) myRect.rect.height * ((float) 4/3) / Screen.height);

        float canvasToReferenceWidth = ((float) myRect.rect.width / 1920);
        float canvasToReferenceHeight = ((float) myRect.rect.height / 1080);

        Debug.Log("Canvas width: " + myRect.rect.width);
        Debug.Log("Canvas height: " + myRect.rect.height);
        Debug.Log("Screen width: " + Screen.width);
        Debug.Log("Screen height: " + Screen.height);
        Debug.Log("Canvas to Screen Width: " + canvasToScreenWidth);
        Debug.Log("Canvas to Screen height: " + canvasToScreenHeight);
        Debug.Log("Canvas to Reference Width: " + canvasToReferenceWidth);
        Debug.Log("Canvas to Reference height: " + canvasToReferenceHeight);

        // Scale and Anchor
        //myRect.anchoredPosition = new Vector2(0, 0);

        mainCameraCamera.orthographicSize /= canvasToScreenWidth;
        if (sceneSaver.resume == "Info")
        {
            RectTransform canvasOverlay = GameObject.FindGameObjectWithTag("LevelCanvas").GetComponent<RectTransform>();

            float scale = canvasOverlay.localScale.x / myRect.localScale.x * 0.75f;
            
            pageOneAnimation.anchoredPosition = new Vector2(-9.6f, -5.4f);
            pageOneAnimation.localScale = new Vector2(scale, scale);
        }
        pageOneAnchor.localScale = new Vector2(pageOneAnchor.localScale.x * canvasToReferenceWidth, pageOneAnchor.localScale.y * canvasToReferenceHeight);
        pageTwoRect.localScale  = new Vector2(pageTwoRect.localScale.x * canvasToReferenceWidth, pageTwoRect.localScale.y * canvasToReferenceHeight);
        pageThreeRect.localScale  = new Vector2(pageThreeRect.localScale.x * canvasToReferenceWidth, pageThreeRect.localScale.y * canvasToReferenceHeight);
        pageFourRect.localScale  = new Vector2(pageFourRect.localScale.x * canvasToReferenceWidth, pageFourRect.localScale.y * canvasToReferenceHeight);

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
