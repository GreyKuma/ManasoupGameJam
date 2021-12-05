using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageBoxHandler : MonoBehaviour
{
    public string MessageBoxText { get; set; } = string.Empty;
    private Text textBox;
    // Start is called before the first frame update
    void Start()
    {
        textBox = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        textBox.text = MessageBoxText;
    }
}
