using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/InputActions/Present")]
public class Present : InputAction
{
    public override void RespondToInput(GameController controller, string[] separatedInputWords)
    {
        //controller.interactableItems.PresentEvidence(separatedInputWords);
    }
}
