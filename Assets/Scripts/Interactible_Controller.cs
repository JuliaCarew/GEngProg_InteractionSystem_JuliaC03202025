using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Interactible_Controller : MonoBehaviour
{
    public GameManager gameManager;
    private DialogueManager dialogueManager;

    [TextArea]
    public string[] sentences;
    [TextArea]
    public string[] shrubberyEvent; // unique dialogue if the player has picked up a shrubbery

    public InteractibleType interactibleType;
    public enum InteractibleType // sets the type of interaction for the object, swap between them in the inspector drop-down
    {
        Default,
        pickUp,
        Info,
        Dialogue
    }

    public bool hasShrubbery = false;

    void Start()
    {
        gameManager = GameManager.Instance;
        if (gameManager == null)
        {
            gameManager = FindObjectOfType<GameManager>(); // get game manager from instanced scene (dont destroy on load)
        }

        if (gameManager != null)
        {
            dialogueManager = gameManager.dialogueManager;
        }
        
        if (dialogueManager == null)
        {
            dialogueManager = FindObjectOfType<DialogueManager>();
        }
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
        StartCoroutine(gameManager.uiManager.DisplayPickUpText("picked up " + gameObject.name));
        Debug.Log($"Picking up {gameObject.name}");
        this.gameObject.SetActive(false); // object disappears

        if (gameObject.name == "shrubbery") { // if the gameobjects is named shrubbery, add it to the inventory
            gameManager.playerInventory.AddItemToInventory("shrubbery");
            Debug.Log($"{gameObject.name} added to inventory");
        }
    }

    // Info next to player's head, for inner thoughts in info on objects
    void Info()
    {
        Debug.Log($"displaying info text");
        StartCoroutine(gameManager.uiManager.DisplayInfoText());
    }

    private void Dialogue()
    {
        bool hasShrubbery = gameManager.playerInventory.CheckInventoryForItem("shrubbery");
        Debug.Log($"Has Shrubbery: {hasShrubbery}");

        if (hasShrubbery && shrubberyEvent.Length > 0){
            dialogueManager.StartDialogue(shrubberyEvent); // dialogue if player has event item (shrubbery in this case)
        }
        else{
            dialogueManager.StartDialogue(sentences); // (NormalControl dialogue on this object)
        }
    }
}
