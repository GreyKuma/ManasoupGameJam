using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Roomchange : MonoBehaviour
{
    public int RoomNr = 1;
    public Animator CameraAnim;
    public bool isAnimating;

    public void RoomRight()
    {
        if (!isAnimating)
        {
            if (RoomNr < 5)
            {       
            RoomNr++;
            isAnimating = true;
            }

            CameraAnim.SetInteger("RoomID", RoomNr);
          
        }
        
    }

    public void RoomLeft()
    {
        if (!isAnimating)
        {
            if (RoomNr > 1)
            {
                RoomNr--;
                isAnimating = true;
            }
            CameraAnim.SetInteger("RoomID", RoomNr);
            
        }
    }

   

}
