using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactible_Controller : MonoBehaviour
{
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
    private void PickUp()
    {
        Debug.Log($"Picking up {gameObject.name}");
        // A collectible object that is added to the player's inventory and disappears from the game world (e.g., key, coin, sword).
    }
    private void Info()
    {
        Debug.Log($"Getting info from {gameObject.name}");
        // Displays UI text above the player when interacted with, representing the player's inner thoughts about an object. The text disappears after a set amount of time.
    }
    private void Dialogue()
    {
        Debug.Log($"Talking to {gameObject.name}");
    }
}
