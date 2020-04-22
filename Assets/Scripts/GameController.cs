using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text displayText;
    public InputAction[] inputActions;

    [HideInInspector] public RoomNavigation roomNavigation;
    [HideInInspector] public List<string> interactionDescriptionInRoom = new List<string>();

    List<string> actionLog = new List<string>();

    void Awake()
    {

        roomNavigation = GetComponent<RoomNavigation>();

    }

    void Start ()
    {
        
        DisplayRoomText ();
        DisplayLoggedText ();
    }

    public void DisplayLoggedText()
    {
        string logAsText = string.Join ("\n", actionLog.ToArray ());

        displayText.text = logAsText;
    }

    public void DisplayRoomText ()
    {
        ClearCollectionsForNewRoom();

        UnpackRoom ();

        string joinedInteractionDescriptions = string.Join("\n", interactionDescriptionInRoom.ToArray());
        string combinedText = roomNavigation.currentRoom.description + joinedInteractionDescriptions;

        LogStringWithReturn(combinedText);
    }

    void UnpackRoom ()
    {
        roomNavigation.UnpackExitsInRoom();
    }

    void ClearCollectionsForNewRoom()
    {
        interactionDescriptionInRoom.Clear();
        roomNavigation.ClearExits();
    }

    public void LogStringWithReturn (string stringToAdd)
    {
        actionLog.Add(stringToAdd + "\n");
    }
}
