using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonControls : MonoBehaviour
{
    public GameObject startButton;
    public GameObject settingsButton;
    public GameObject creditsButton;
    public GameObject beendenButton;
    public GameObject menuPanel;
    public GameObject settingPanel;
    public GameObject creditsPanel;
    public GameObject sicherPanel;
    public GameObject hud;

    public void GoBack()
    {
        //schliesse mich
        //aktiviere menupanel
        menuPanel.SetActive(true);
        settingPanel.SetActive(false);
        creditsPanel.SetActive(false);
        sicherPanel.SetActive(false);

    }

    public void Quit()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
    public void StartGame()
    {
        Debug.Log("Start Game");
        SceneManager.LoadScene("Raum 1");
    }

    public void SicherPanel()
    {
        menuPanel.SetActive(false);
        sicherPanel.SetActive(true);

    }

    public void BacktoGame()
    {
        menuPanel.SetActive(false);
    }

    public void Settings()
    {
        //aktiviere settingpanel
        menuPanel.SetActive(false);
        settingPanel.SetActive(true);
        creditsPanel.SetActive(false);
        sicherPanel.SetActive(false);

    }
    public void Credits()
    {
        //aktiviere creditpanel
        menuPanel.SetActive(false);
        settingPanel.SetActive(false);
        creditsPanel.SetActive(true);
        sicherPanel.SetActive(false);
    }

    public void Callmenu()
    {
       if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuPanel.SetActive(true);
        }
    }

    private void Update()
    {
        Callmenu();

    }
}
