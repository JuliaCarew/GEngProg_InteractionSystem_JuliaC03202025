using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactible_Controller : MonoBehaviour
{
    public GameObject currentInteractible = null;  

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Interactible")
        {
            currentInteractible = other.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Interactible")
        {
            currentInteractible = null;
        }
    }
}
