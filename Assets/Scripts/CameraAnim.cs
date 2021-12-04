using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnim : MonoBehaviour
{
    public Roomchange roomchangeCS;
    public void EndAnim()
    {
        roomchangeCS.isAnimating = false;
    }
}
