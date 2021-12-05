using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
  
    public int itemID;
    public bool onDesk = false;
    public bool picked = false;


    //Inventar
  
    public ItemManager itemManager;


   


    //  ID   [Click] ->  [ ID ]   isPicked   ||      [ ID ]    TT   [ !null? && !full?]  ID ->  onDesk = {ID}  ->  [   ]   -> Alarm für P2   ; [  ]


    public void Pickup()
    {
       if (itemManager.inventarFull == false)
        {
            picked = true;
            itemManager.itemID = itemID;
            itemManager.PickedUp();
            itemManager.lastPicked = GetComponent<Item>();
        }
       else
        {
            itemManager.lastPicked.picked = false;  //altes Item zurücklegen
            picked = true;
            itemManager.itemID = itemID;
            itemManager.PickedUp();
            itemManager.lastPicked = GetComponent<Item>();
        }

    }


    private void FixedUpdate()
    {

        //Item Anzeige
        if (picked == true)
        {
            GetComponent<CanvasGroup>().alpha = 0;
            GetComponent<CanvasGroup>().interactable = false;
        }
        else
        {
            GetComponent<CanvasGroup>().alpha = 1;
            GetComponent<CanvasGroup>().interactable = true;
        }

    }









}
