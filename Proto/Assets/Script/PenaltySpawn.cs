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
    public RectTransform rectTransform;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Start()
    {
        timePenalty.text += retrievePenalty +"s";
    }

    // Update is called once per frame
    void Update()
    {
        timePenalty.rectTransform.anchoredPosition3D = new Vector3(timePenalty.rectTransform.anchoredPosition.x, timePenalty.rectTransform.anchoredPosition.y + 1, -5.0f);
        timePenalty.alpha -= Time.deltaTime;

        Destroy(gameObject, 1);
    }
}
