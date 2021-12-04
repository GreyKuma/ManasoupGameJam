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

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(CreateGame);
        NetworkAPI.OnClosed += OnWrongId;
        NetworkAPI.OnStart += OnGameStart;
        inputField = FindObjectOfType<NetworkIdInputField>();
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
    }

    private void OnWrongId()
    {
        MessageBox.text = "ID existiert nicht!";
    }
}
