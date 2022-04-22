using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Info : MonoBehaviour
{
    [SerializeField]
    public GameObject rightArrow;

    [SerializeField]
    public GameObject leftArrow;

    [SerializeField]
    public TMP_Text pageNumber;

    private SceneSaver sceneSaver;

    public int allPages = 4;
    public int currentPage;

    void Awake()
    {
        sceneSaver = FindObjectOfType<SceneSaver>();
    }

    void Start()
    {
        currentPage = sceneSaver.levelPage;
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

        // Arrow visibility
        if (currentPage == 1)
        {
            leftArrow.SetActive(false);
        }
        else 
        {
            leftArrow.SetActive(true);
        }
        if (currentPage == 4)
        {
            rightArrow.SetActive(false);
        }
        else 
        {
            rightArrow.SetActive(true);
        }
    }
}
