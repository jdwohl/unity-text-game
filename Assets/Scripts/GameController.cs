using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameController : MonoBehaviour
{
    // used for main scene
    public Text displayText;
    // used for logic grid scene
    public Text logicDisplayText;
    public InputAction[] inputActions;

    public Text[] buttonList = new Text[50];
    public GameObject logicTextPanel;
    public Text logicQuestionText;

    public InventoryManager inventoryManager;

    public int currentSquare = -1;

    private string input;

    [HideInInspector] public RoomNavigation roomNavigation;
    [HideInInspector] public List<string> interactionDescriptionsInRoom = new List<string>();
    [HideInInspector] public InteractableItems interactableItems;
 
    List<string> actionLog = new List<string>();

    void Awake()
    {
        interactableItems = GetComponent<InteractableItems>();
        roomNavigation = GetComponent<RoomNavigation>();

        SetGameControllerReferenceOnButtons();
    }

    void Start()
    {
        SetInventoryManager();
        DisplayRoomText();
        DisplayLoggedText();
    }

    void SetInventoryManager()
    {
        inventoryManager = FindAnyObjectByType<InventoryManager>();
    }

    public void DisplayLoggedText()
    {
        string logAsText = string.Join("\n", actionLog.ToArray());

        displayText.text = logAsText;
    }

    public void DisplayRoomText()
    {
        if (inventoryManager == null)
        {
            SetInventoryManager();
        }

        ClearCollectionsForNewRoom();

        UnpackRoom();

        string joinedInteractionDescriptions = string.Join("\n", interactionDescriptionsInRoom.ToArray());

        string combinedText = roomNavigation.currentRoom.description + "\n" + joinedInteractionDescriptions;

        LogStringWithReturn(combinedText);
    }

    void UnpackRoom()
    {
        roomNavigation.UnpackExitsInRoom();
        PrepareObjectsToTakeOrExamine(roomNavigation.currentRoom);
    }

    void PrepareObjectsToTakeOrExamine(Room currentRoom)
    {
        for (int i = 0; i < currentRoom.interactableObjectsInRoom.Length; i++)
        {
            string descriptionNotInInventory = interactableItems.GetObjectNotInInventory(currentRoom, i);
            if (descriptionNotInInventory != null)
            {
                interactionDescriptionsInRoom.Add(descriptionNotInInventory);
            }

            InteractableObject interactableInRoom = currentRoom.interactableObjectsInRoom[i];

            for (int j = 0; j < interactableInRoom.interactions.Length; j++)
            {
                Interaction interaction = interactableInRoom.interactions[j];
                if(interaction.inputAction.keyword == "???")
                {
                    interactableItems.examineDictionary.Add(interactableInRoom.noun, interaction.textResponse);
                }

                if (interaction.inputAction.keyword == "examine" || interaction.inputAction.keyword == "take")
                {
                    interactableItems.takeDictionary.Add(interactableInRoom.noun, interaction.textResponse);
                }
            }
        }
    }

    public string TestVerbDictionaryWithNoun(Dictionary<string, string> verbDictionary, string verb, string noun)
    {
        if (verbDictionary.ContainsKey(noun))
        {
            return verbDictionary[noun];
        }

        return "You can't " + verb + " " + noun;
    }

    void ClearCollectionsForNewRoom()
    {
        interactableItems.ClearCollections();
        interactionDescriptionsInRoom.Clear();
        roomNavigation.ClearExits();
    }

    public void LogStringWithReturn(string stringToAdd)
    {
        actionLog.Add(stringToAdd + "\n");
    }

    void SetGameControllerReferenceOnButtons()
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<GridSquare>().SetGameControllerReference(this);
        }
    }

    public void CheckPresentedEvidence(string evidence)
    {
        if(currentSquare != -1)
        {
            buttonList[currentSquare].GetComponentInParent<GridSquare>().LogicCheck(evidence);
        }
        else
        {
            logicDisplayText.text = "Please select a square.";
        }
    }

    public void ReadLogicStringInput(string s)
    {
        input = s.ToLower();
        CheckPresentedEvidence(input);
    }

    public bool TestValidRowElimination(int row, int col)
    {
        bool valid = true;
        for (int i = 0; i < buttonList.Length; i++)
        {
            GridSquare square = buttonList[i].GetComponentInParent<GridSquare>();

            if(square.rowNumber == row && square.colNumber != col)
            {
                if(square.button.interactable == true)
                {
                    valid = false;
                    break;
                }
            }
        }

        return valid;
    }

    public bool TestValidColElimination(int row, int col)
    {
        bool valid = true;
        for (int i = 0; i < buttonList.Length; i++)
        {
            GridSquare square = buttonList[i].GetComponentInParent<GridSquare>();

            if (square.rowNumber != row && square.colNumber == col)
            {
                if (square.button.interactable == true)
                {
                    valid = false;
                    break;
                }
            }
        }

        return valid;
    }

    public void Eliminate(int row, int col)
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            GridSquare square = buttonList[i].GetComponentInParent<GridSquare>();

            if (square.rowNumber == row || square.colNumber == col)
            {
                if(square.button.interactable == true)
                {
                    square.button.interactable = false;
                }
            }
            
        }
    }

    public bool AllButtonsDisabled()
    {
        bool gameIsWon = true;

        for (int i = 0; i < buttonList.Length; i++)
        {
            GridSquare square = buttonList[i].GetComponentInParent<GridSquare>();

            if(square.button.interactable == true)
            {
                gameIsWon = false;
                break;
            }
        }

        return gameIsWon;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
