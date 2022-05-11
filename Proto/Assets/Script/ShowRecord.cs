using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowRecord : MonoBehaviour
{
    private SceneSaver sceneSaver;
    private TMP_Text text;
    private GameObject myParent;
    // Start is called before the first frame update
    void Awake()
    {
        sceneSaver = FindObjectOfType<SceneSaver>();
        text = GetComponent<TMP_Text>();
        myParent = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Start()
    {
        if(sceneSaver.newRecord != 0)
        {
            text.text = sceneSaver.newRecord.ToString() + "s";
            sceneSaver.newRecord = 0;
        }
        else
        {
            myParent.SetActive(false);
        }
    }
}
