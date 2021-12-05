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
	private string messageboxText = "";

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(CreateGame);
        NetworkAPI.OnClosed += OnWrongId;
		NetworkAPI.OnJoined += OnJoined;
        NetworkAPI.OnStart += OnGameStart;
        inputField = FindObjectOfType<NetworkIdInputField>();
    }

	private void Update() 
	{
		MessageBox.text = messageboxText;
	}

    private void CreateGame()
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
		Debug.Log("Started");
		messageboxText = "Started";
    }

	private void OnJoined(string id)
	{
		// TODO: disable create interface or move into waiting screen
		Debug.Log("Joined");
		messageboxText = "Joined";
	}

    private void OnWrongId()
    {
		messageboxText = "ID existiert nicht!";
    }
}
