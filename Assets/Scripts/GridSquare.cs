using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GridSquare : MonoBehaviour
{
    private GameController gameController;
    public Button button;
    public Text buttonText;
    public string squareMark;

    InventoryManager inventoryManager;

    public string correctEvidence;
    public string explanation;
    public bool greenSquare;
    public bool elimination;

    public int squareNumber;
    public int rowNumber;
    public int colNumber;
    public int sectNumber;

    private void Awake()
    {
        inventoryManager = FindAnyObjectByType<InventoryManager>();
    }

    public void SetSquare()
    {
        gameController.currentSquare = squareNumber;
    }

    public void SetGameControllerReference(GameController controller)
    {
        gameController = controller;
    }

    public void LogicCheck(string evidence)
    {
        bool correct = false;

        string displayString = "Incorrect.";

        if (evidence.ToLower() == "elimination" || inventoryManager.CheckIfNounInInventory(evidence.ToLower()))
        {
            if (evidence.ToLower() == this.correctEvidence)
            {
                if (elimination)
                {
                    if (gameController.TestValidRowElimination(this.rowNumber, this.colNumber) || gameController.TestValidColElimination(this.rowNumber, this.colNumber))
                    {
                        displayString = explanation;
                        button.interactable = false;
                        correct = true;
                    }
                }
                else
                {
                    displayString = explanation;
                    button.interactable = false;
                    correct = true;
                }

                if (greenSquare && correct)
                {
                    gameController.Eliminate(rowNumber, colNumber);
                }

                if (gameController.AllButtonsDisabled())
                {
                    displayString += "\n\nCongratulations! You win!";
                }
            }
        } else
        {
            displayString = "You have not collected this evidence.";
        }

        gameController.logicDisplayText.text = displayString;
    }
}
