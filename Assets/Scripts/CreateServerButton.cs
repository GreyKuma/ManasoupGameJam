using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateServerButton : MonoBehaviour
{
    private Button button;
    private NetworkAPI network = NetworkAPI.Instance;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(CreateGame);

		NetworkAPI.OnCreated += OnCreated;
    }

    private void CreateGame()
    {
        network.CreateServer();
    }

	private void OnCreated(string roomId)
	{
		Debug.Log("Created room: " + roomId);
		// TODO: display room id
		// TODO: disable join interface and or move into waiting screen
	}
}
