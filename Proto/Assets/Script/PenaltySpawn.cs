using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class PenaltySpawn : MonoBehaviour
{

    public float retrievePenalty = 0;
    public TMP_Text timePenalty;
    private RectTransform rectTransform;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        timePenalty.text = "-"+ retrievePenalty;
        timePenalty.rectTransform.anchoredPosition = new Vector2(timePenalty.rectTransform.anchoredPosition.x, timePenalty.rectTransform.anchoredPosition.y + 0.1f);
        timePenalty.alpha -= Time.deltaTime;
        timePenalty.outlineColor = new Color32(0, 0, 0, 255);

        Destroy(gameObject, 1);
    }
}
