using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameManager _gameManager;

    public GameObject menuUI;
    public GameObject gameplayUI;
    public GameObject pausedUI;
    public GameObject optionsUI;

    public void DisplayMainMenuUI()
    {
        ClearUI();
        menuUI.SetActive(true);
    }
    public void DisplayGameplayUI()
    {
        ClearUI();
        gameplayUI.SetActive(true);
    }
    public void DisplayPausedUI()
    {
        ClearUI();
        pausedUI.SetActive(true);
    }

    public void DisplayOptionsUI()
    {
        ClearUI();
        optionsUI.SetActive(true);
    }
    public void ClearUI()
    {
        if (menuUI != null) menuUI.SetActive(false);
        if (gameplayUI != null) gameplayUI.SetActive(false);
        if (pausedUI != null) pausedUI.SetActive(false);
        if (optionsUI != null) optionsUI.SetActive(false);
    }
}