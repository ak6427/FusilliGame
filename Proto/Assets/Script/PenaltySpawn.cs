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

    // Start is called before the first frame update
    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        timePenalty.text = "-"+ retrievePenalty +"s";
        timePenalty.rectTransform.anchoredPosition3D = new Vector3(timePenalty.rectTransform.anchoredPosition.x, timePenalty.rectTransform.anchoredPosition.y + 1, -5.0f);
        timePenalty.alpha -= Time.deltaTime;

        Destroy(gameObject, 1);
    }
}
