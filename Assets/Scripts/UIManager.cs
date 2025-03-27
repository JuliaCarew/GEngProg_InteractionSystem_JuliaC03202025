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

    // Info interactible
    public GameObject infoObj;
    public TextMeshProUGUI infoText;
    string infoString = "INFO";

    // Pick up interactible
    public GameObject pickUpObj;
    public TextMeshProUGUI pickUpText;

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

    public IEnumerator DisplayInfoText()
    {
        Debug.Log("Started DisplayInfoText Coroutine");

        infoObj.SetActive(true);
        infoText.text = infoString;

        yield return new WaitForSeconds(5);
        infoObj.SetActive(false);
    }
    public IEnumerator DisplayPickUpText(string text)
    {
        Debug.Log("Started DisplayPickUpText Coroutine");

        pickUpObj.SetActive(true);
        pickUpText.text = text;

        yield return new WaitForSeconds(5);
        pickUpObj.SetActive(false);
    }   
}