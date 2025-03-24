using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Interactible_Controller : MonoBehaviour
{
    private PlayerInventory playerInventory;

    public GameObject infoObj;
    public GameObject dialogueObj;
    public GameObject player;

    public TextMeshProUGUI infoText;
    public TextMeshProUGUI dialogueText;

    string infoString = "INFO";
    string dialogueString = "DIALOGUE";

    public InteractibleType interactibleType;
    public enum InteractibleType
    {
        Default,
        pickUp,
        Info,
        Dialogue
    }
    public void Interact(){
        switch (interactibleType)
        {
            case InteractibleType.Default:
                Default();
                break;
            case InteractibleType.pickUp:
                PickUp();
                break;
            case InteractibleType.Info:
                StartCoroutine(DisplayInfoText());
                break;
            case InteractibleType.Dialogue:
                StartCoroutine(DisplayDialogue());
                break;
        }
    }
    private void Default()
    {
        Debug.Log($"Interacting with default {gameObject.name}");
    }
    private void PickUp() // add item to player Inventory
    {
        Debug.Log($"Picking up {gameObject.name}");
        this.gameObject.SetActive(false);
        //playerInventory.inventory.Add(this.gameObject); // not working right now
        Debug.Log($"{gameObject.name} added to inventory");
    }

    // Info next to player's head, for inner thoughts in info on objects
    IEnumerator DisplayInfoText()
    {
        Debug.Log("Started DisplayInfoText Coroutine");

        infoObj.SetActive(true);
        infoText.text = infoString;

        yield return new WaitForSeconds(5);
        infoObj.SetActive(false);
    }

    // Text above player's head, for dialogue with NPCs & player
    IEnumerator DisplayDialogue()
    {
        Debug.Log("Started DisplayDialogue Coroutine");

        dialogueObj.SetActive(true);
        dialogueText.text = dialogueString;

        yield return new WaitForSeconds(2);
        dialogueObj.SetActive(false);
    }
}
