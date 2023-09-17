using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Image actorImage;
    public Text actorName;
    public Text messageText;
    public RectTransform backgroundBox;

    Message[] currentMessages;
    Actor[] currentActors;
    int activeMessage = 0;
    public static bool isActive = false;

    // scale vectors to hide/show the dialogue
    private Vector3 invisible = new Vector3(0, 0, 0);
    private Vector3 visible = new Vector3(1, 1, 1);

    public void OpenDialogue(Message[] messages, Actor[] actors)
    {
        currentMessages = messages; // fetch messages
        currentActors = actors; // fetch actors
        activeMessage = 0;  // reset the messages count
        isActive = true;

        backgroundBox.localScale = visible; //display the dialogue box on the screen
        DisplayMessage();
    }

    void DisplayMessage()
    {
        // fetch the message
        Message messageToDisplay = currentMessages[activeMessage];
        messageText.text = messageToDisplay.message;

        // fetch the character name and avatar
        Actor actorToDisplay = currentActors[messageToDisplay.actorId];
        actorName.text = actorToDisplay.name;
        actorImage.sprite = actorToDisplay.sprite;
    }

    public void NextMessage()
    {
        activeMessage++; //advance the message

        if (activeMessage < currentMessages.Length) // if there is still messages to display
        {
            DisplayMessage();
        }
        else // messages end reached
        {
            isActive = false;
            backgroundBox.localScale = invisible;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //hide the dialogue box at the start
        backgroundBox.localScale = invisible;
    }

    // Update is called once per frame
    void Update()
    {
        // progress the messages upon E key
        if (Input.GetKeyDown(KeyCode.E) && isActive == true)
        {
            NextMessage();
        }
    }
}
