using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoinServerButton : MonoBehaviour
{
    private Button button;
    private NetworkAPI network = NetworkAPI.Instance;
    private NetworkIdInputField inputField;
    private MessageBoxHandler messageBox;
    [SerializeField] private Button CreateLobbyButton;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(JoinGame);
        inputField = FindObjectOfType<NetworkIdInputField>();
        messageBox = FindObjectOfType<MessageBoxHandler>();
    }


    private void OnEnable()
    {
        RegisterHandlers();
        CreateLobbyButton.interactable = true;
    }

    private void OnDisable()
    {
        UnregisterHandlers();
        messageBox.MessageBoxText = String.Empty;
    }

    public void RegisterHandlers()
    {
        NetworkAPI.OnClosed += OnWrongId;
        NetworkAPI.OnJoined += OnJoined;
        NetworkAPI.OnStart += OnGameStart;
        NetworkAPI.OnCreated += OnGameCreated;
    }

    public void UnregisterHandlers()
    {
        NetworkAPI.OnClosed -= OnWrongId;
        NetworkAPI.OnJoined -= OnJoined;
        NetworkAPI.OnStart -= OnGameStart;
        NetworkAPI.OnCreated -= OnGameCreated;
    }

    private void JoinGame()
    {
        //TODO: show error message
        if (!string.IsNullOrWhiteSpace(inputField.id))
        {
            network.JoinServer(inputField.id);
        }
    }

    private void OnGameStart(string id)
    {
        NetworkAPI.OnClosed -= OnWrongId;
        messageBox.MessageBoxText = "Game startet";
        Debug.Log(messageBox.MessageBoxText);
        //TODO: load game
    }

	private void OnJoined(string id)
	{
        CreateLobbyButton.interactable = false;
        messageBox.MessageBoxText = "Raum beigetreten";
        Debug.Log(messageBox.MessageBoxText);
    }

    private void OnWrongId()
    {
        messageBox.MessageBoxText = "Raum existiert nicht!";
        Debug.Log(messageBox.MessageBoxText);
    }

    private void OnGameCreated(string id)
    {
        messageBox.MessageBoxText = "Lobby erstellt";
        Debug.Log(messageBox.MessageBoxText);
    }
}
