using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameServerCallbackHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        NetworkAPI.OnStart += null;
        NetworkAPI.OnClosed += OnWrongId;
        NetworkAPI.OnStart += null;
    }



    private void OnWrongId()
    {
        //TODO: clear input field
        //TODO: show error message
    }
}
