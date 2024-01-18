using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/InputActions/Examine")]
public class Examine : InputAction
{
    public override void RespondToInput(GameController controller, string[] separatedInputWords)
    {
        Dictionary<string, string> takeDictionary = controller.interactableItems.Take(separatedInputWords);

        if (takeDictionary != null)
        {
            controller.LogStringWithReturn(controller.TestVerbDictionaryWithNoun(takeDictionary, separatedInputWords[0], separatedInputWords[1]));

            if (!controller.inventoryManager.CheckIfNounInInventory(separatedInputWords[1])){
                controller.inventoryManager.SetInventoryFromNoun(separatedInputWords[1]);
                controller.LogStringWithReturn(separatedInputWords[1][..1].ToUpper() + separatedInputWords[1][1..] + " added to evidence list.");
            }
        }
    }
}
