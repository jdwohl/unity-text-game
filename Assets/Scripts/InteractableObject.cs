using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TextAdventure/InteractableObject")]
public class InteractableObject : ScriptableObject
{
    public string noun = "name";
    [TextArea]
    public string description = "Description in room";
    public Interaction[] interactions;
    public int itemIndex;
    public int locationIndex;
    // park = 0, hotel = 1, lake = 2, stadium = 3, train station = 4
}
