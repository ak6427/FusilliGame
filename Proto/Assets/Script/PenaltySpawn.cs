using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PenaltySpawn : MonoBehaviour
{

    //public int retrievePenalty;
    //public TMP_Text timePenalty;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //timePenalty.text = "-"+ retrievePenalty;

        Destroy(gameObject, 1);
    }
}
