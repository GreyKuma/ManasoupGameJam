using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NetworkIdInputField : MonoBehaviour
{
    private InputField input;
    public string id
    {
        get => input.text;
    }

    void Start()
    {
        input = GetComponent<InputField>();
    }
}
