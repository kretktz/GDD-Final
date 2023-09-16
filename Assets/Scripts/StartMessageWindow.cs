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
    // Start is called before the first frame update
    void Start()
    {
        if (!hasBeenRead)
        {
            backgroundBox.localScale = visible;
            //Time.timeScale = 0f;
            isDisplayed = true;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //Time.timeScale = 1f;
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
