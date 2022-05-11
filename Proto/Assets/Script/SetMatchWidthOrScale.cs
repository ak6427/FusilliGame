using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetMatchWidthOrScale : MonoBehaviour
{
    private SceneSaver sceneSaver;
    private CanvasScaler canvasScaler;

    void Awake()
    {
        sceneSaver = FindObjectOfType<SceneSaver>();
        canvasScaler = GetComponent<CanvasScaler>();
    }
    // Start is called before the first frame update
    void Update()
    {
        canvasScaler.matchWidthOrHeight = sceneSaver.widthOrHeight;
    }
}
