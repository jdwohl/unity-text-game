using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/InputActions/Choose")]
public class Choose : InputAction
{
    public override void RespondToInput(GameController controller, string[] separatedInputWords)
    {
        controller.interactableItems.ChooseSquare(separatedInputWords);
    }
}
