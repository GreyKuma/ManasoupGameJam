using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControl : MonoBehaviour
{
    public GameObject startbutton;
    public GameObject settingsbutton;
    public GameObject creditsbutton;
    public GameObject beendenbutton;
    public GameObject zuruecksettingbutton;
    public GameObject zurueckcreditsbutton;
    public GameObject jabutton;
    public GameObject neinbutton;

    public GameObject menuPanel;
    public GameObject ingamemenuPanel;
    public GameObject settingsPanel;
    public GameObject creditsPanel;
    public GameObject sicherPanel;
    public GameObject lobbyPanel;

    // Update is called once per frame
   public void Update()
    {
       if (Input.GetKeyDown(KeyCode.Escape))
        {
            ingamemenuPanel.SetActive(true);
        }
    }


    //buttons aktivieren
    public void Settings()
    {
        menuPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void Settingsingame()
    {
        ingamemenuPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void Credis()
    {
        menuPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }

    public void Creditsingame()
    {
        ingamemenuPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }

    //back aktivierien
    public void Back()
    {
        menuPanel.SetActive(true);
        settingsPanel.SetActive(false);
        creditsPanel.SetActive(false);
        lobbyPanel.SetActive(false);
    }

    public void Backingamemenu()
    {
        ingamemenuPanel.SetActive(true);
        settingsPanel.SetActive(false);
        creditsPanel.SetActive(false);
        sicherPanel.SetActive(false);
    }

    public void Backtogame()
    {
        ingamemenuPanel.SetActive(false);
    }

    public void Sicher()
    {
        ingamemenuPanel.SetActive(false);
        sicherPanel.SetActive(true);
    }

    //beendne erstellen
  public void Quit()
    {
        Application.Quit();
    }


    //start zu lobby
    public void Beginn()
    {
        menuPanel.SetActive(false);
        lobbyPanel.SetActive(true);
    }
    //slieder musik controll



}
