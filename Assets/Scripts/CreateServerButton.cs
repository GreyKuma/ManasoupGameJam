using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateServerButton : MonoBehaviour
{
    private Button button;
    private NetworkAPI network = NetworkAPI.Instance;
    private string messagBoxText;
    [SerializeField] Text messageBox;
    [SerializeField] Button JoinServerButton;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(CreateGame);
    }

    private void Update()
    {
        messageBox.text = messagBoxText;
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
        network.CreateServer();
    }

	private void OnCreated(string roomId)
	{
        messagBoxText = $"Created room: {roomId}";
        Debug.Log(messagBoxText);
        JoinServerButton.interactable = false;
    }

    private void OnClosed()
    {
        JoinServerButton.interactable = true;
    }

    private void OnStart(string roomId)
    {
        //TODO: load game
    }
}
