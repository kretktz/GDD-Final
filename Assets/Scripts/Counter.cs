using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Text counterText;
    public string description;
    public float counter;

    public RectTransform backgroundBox;
    private Vector3 invisible = new Vector3(0, 0, 0);
    private Vector3 visible = new Vector3(1, 1, 1);

    void Start()
    {
        backgroundBox.localScale = visible;
    }

    // Update is called once per frame
    void Update()
    {
        // hide display when dialogue or information is active
        if(DialogueManager.isActive || StartMessageWindow.isDisplayed)
        {
            backgroundBox.localScale = invisible;
        }
        else { backgroundBox.localScale = visible; }

        counter = Manager.spotCount;
        counterText.text = description + counter.ToString("0.00");

        if (counter < 3f && counter > 1f)
        {
            counterText.color = Color.yellow;
        }
        else if (counter < 1f)
        {
            counterText.color = Color.red;
        }
    }
}
