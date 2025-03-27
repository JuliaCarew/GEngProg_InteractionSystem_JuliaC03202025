using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Interactible_Controller : MonoBehaviour
{
    public GameManager gameManager;
    private DialogueManager dialogueManager;

    //[Header]
    //string dialogueString = "DIALOGUE";
    [TextArea]
    public string[] sentences;

    private void Awake()
    {
        gameManager = GameManager.Instance;
        dialogueManager = GameManager.Instance.dialogueManager;
    }

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
                Info();
                break;
            case InteractibleType.Dialogue:
                Dialogue();
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
    void Info()
    {
        StartCoroutine(gameManager.uiManager.DisplayInfoText());
    }

    private void Dialogue()
    {
        dialogueManager.StartDialogue(sentences);
    }
}
