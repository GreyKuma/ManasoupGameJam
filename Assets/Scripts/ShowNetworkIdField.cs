using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowNetworkIdField : MonoBehaviour
{
    private InputField inputField;

    void Start()
    {
        inputField = GetComponent<InputField>();
        NetworkAPI.OnCreated += OnSessionCreated;
    }

    private void OnSessionCreated(string id)
    {
        inputField.text = id;
    }
}
