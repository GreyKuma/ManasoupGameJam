using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateServerButton : MonoBehaviour
{
    private Button button;
    private NetworkAPI network = NetworkAPI.Instance;
    private MessageBoxHandler messageBox;
    private Button joinServerButton;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(CreateGame);
        messageBox = FindObjectOfType<MessageBoxHandler>();
        joinServerButton = FindObjectOfType<JoinServerButton>().GetComponent<Button>();
    }

    private void OnEnable()
    {
        RegisterHandlers();
        joinServerButton = FindObjectOfType<JoinServerButton>().GetComponent<Button>();
        joinServerButton.interactable = true;
    }

    private void OnDisable()
    {
        UnregisterHandlers();
        messageBox.MessageBoxText = String.Empty;
    }

    public void RegisterHandlers()
    {
        NetworkAPI.OnCreated += OnCreated;
        NetworkAPI.OnClosed += OnClosed;
        //NetworkAPI.OnJoined
        NetworkAPI.OnStart += OnStart;
    }

    public void UnregisterHandlers()
    {
        NetworkAPI.OnCreated -= OnCreated;
        NetworkAPI.OnClosed -= OnClosed;
        //NetworkAPI.OnJoined
        NetworkAPI.OnStart -= OnStart;
    }

    private void CreateGame()
    {
        try
        {
            network.CreateServer();
        }
        catch(Exception e)
        {
            messageBox.MessageBoxText = $"Couldn't create a Server";
            Debug.Log($"{messageBox.MessageBoxText}{e.Message}");
        }
        
    }

	private void OnCreated(string roomId)
	{
        messageBox.MessageBoxText = $"Created room: {roomId}";
        Debug.Log(messageBox.MessageBoxText);
        joinServerButton.interactable = false;
    }

    private void OnClosed()
    {
        joinServerButton.interactable = true;
    }

    private void OnStart(string roomId)
    {
        //TODO: load game
    }
}
