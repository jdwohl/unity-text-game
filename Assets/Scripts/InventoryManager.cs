using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    // used to represent current inventory
    public bool[] inventory = new bool[13];

    public InteractableObject[] allEvidence;

    public enum Items
    {
        Bow,
        China,
        Claw,
        Clothes,
        Crumbs,
        Dresser,
        Eyewitness,
        Footprints,
        Knife,
        Sword,
        Symbol,
        Table,
        Tape,
        Unknown = -1
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Items IndexOfNoun(string noun)
    {
        switch (noun)
        {
            case "bow":
                return Items.Bow;
            case "china":
                return Items.China;
            case "claw":
                return Items.Claw;
            case "clothes":
                return Items.Clothes;
            case "crumbs":
                return Items.Crumbs;
            case "dresser":
                return Items.Dresser;
            case "eyewitness":
                return Items.Eyewitness;
            case "footprints":
                return Items.Footprints;
            case "knife":
                return Items.Knife;
            case "sword":
                return Items.Sword;
            case "symbol":
                return Items.Symbol;
            case "table":
                return Items.Table;
            case "tape":
                return Items.Tape;
            default: 
                return Items.Unknown;
        }
    }

    public bool CheckIfNounInInventory(string noun)
    {
        Items item = IndexOfNoun(noun);
        if (item >= 0)
        {
            return inventory[(int)item];
        } else
        {
            return false;
        }
    }

    public void SetInventoryFromNoun(string noun)
    {
        Items item = IndexOfNoun(noun);
        if (item >= 0)
        {
            inventory[(int)item] = true;
        }
    }
}
