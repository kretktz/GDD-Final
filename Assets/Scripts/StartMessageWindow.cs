using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMessageWindow : MonoBehaviour
{
    public RectTransform backgroundBox;

    public static bool isDisplayed;

    private bool hasBeenRead = false;

    private Vector3 visible = new Vector3(1, 1, 1);
    private Vector3 invisible = new Vector3(0, 0, 0);

    void Start()
    {
        if (!hasBeenRead)
        {
            backgroundBox.localScale = visible;
            isDisplayed = true;
        }
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isDisplayed = false;
            CloseMessage();
        }
    }

    public void CloseMessage()
    {
        backgroundBox.localScale = invisible;
        hasBeenRead = true;
    }
}
