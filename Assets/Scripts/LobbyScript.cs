using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyScript : MonoBehaviour
{
    private JoinServerButton joinServerButton;
    private CreateServerButton createServerButton;

    private void OnEnable()
    {
        joinServerButton = GetComponent<JoinServerButton>();
        createServerButton = GetComponent<CreateServerButton>();
        joinServerButton.RegisterHandlers();
        createServerButton.RegisterHandlers();
    }

    private void OnDisable()
    {
        joinServerButton.UnregisterHandlers();
        createServerButton.UnregisterHandlers();
    }
}
