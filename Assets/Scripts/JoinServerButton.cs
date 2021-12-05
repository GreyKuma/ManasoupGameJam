using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoinServerButton : MonoBehaviour
{
    private Button button;
    private NetworkAPI network = NetworkAPI.Instance;
    private NetworkIdInputField inputField;
    [SerializeField] private Text MessageBox;
    [SerializeField] private Button CreateLobbyButton;
	private string messageboxText = "";

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(JoinGame);
        inputField = FindObjectOfType<NetworkIdInputField>();
    }

    private void Update()
    {
        MessageBox.text = messageboxText;
    }

    private void OnEnable()
    {
        RegisterHandlers();
    }

    private void OnDisable()
    {
        UnregisterHandlers();
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
		messageboxText = "Game startet";
        Debug.Log(messageboxText);
        //TODO: load game
    }

	private void OnJoined(string id)
	{
        CreateLobbyButton.interactable = false;
		messageboxText = "Raum beigetreten";
        Debug.Log(messageboxText);
    }

    private void OnWrongId()
    {
        messageboxText = "Raum existiert nicht!";
        Debug.Log(messageboxText);
    }

    private void OnGameCreated(string id)
    {
        messageboxText = "Lobby erstellt";
        Debug.Log(messageboxText);
    }
}
