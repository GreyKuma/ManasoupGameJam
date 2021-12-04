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
    }

    private void CreateGame()
    {
        network.CreateServer();
    }
}
