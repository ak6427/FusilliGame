using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToMenuConfirmation : MonoBehaviour
{
    public Text childText;
    public SceneSwitch sceneSwitch;
    public float confirmTimer = 0.0f;
    // Start is called before the first frame update
    void Awake()
    {
        childText = GameObject.FindObjectOfType<Text>();/*.transform.GetChild(0).gameObject.GetComponent<Text>()*/;
        sceneSwitch = FindObjectOfType<SceneSwitch>();
        sceneSwitch = sceneSwitch.GetComponent<SceneSwitch>();
    }

    public void ConfirmOrSetTimer()
    {
        if (confirmTimer == 0.0f)
        {
            confirmTimer = 3.0f;
        }
        else
        {
            sceneSwitch.SceneValikko();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (confirmTimer > 0.0f)
        {
            childText.text = "Confirm?";
            childText.color = new Color(255, 255, 0, 255);
            confirmTimer = Mathf.Clamp(confirmTimer - Time.deltaTime, 0.0f, 3.0f);
        }
        else
        {
            childText.text = "Main menu";
            childText.color = new Color(255, 0, 0, 255);
        }
    }
}
