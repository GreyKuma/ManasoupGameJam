using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public int itemID;
    public bool inventarFull;
    public Item lastPicked;

    //Inventar
    public Image icon;
    public Sprite[] itemSprites;


    public void PickedUp()
    {
        //  itemID = lastPicked.itemID;
        Debug.Log("TuTut");
        icon.sprite = itemSprites[itemID];
        inventarFull = true;
        //Inventar
        // last Picked ID -> anzeigen 
    }



}
