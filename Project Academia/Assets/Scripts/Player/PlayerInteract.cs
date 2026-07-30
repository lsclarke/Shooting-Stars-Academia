using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    private bool canInteract;
    private bool isInteracting;
    public Transform ContactPoint;
    //This variable is for keeping track of what object we are looking at !
    private Collider2D InteractableObject;

    [SerializeField]
    private LayerMask DetectThisLayer;


    private void Update()
    {
        //Calls the DrawDetector method
        DrawDetector();
    }

    public void SetPlayerInteract(bool value)
    {
        canInteract = value;
    }

    public bool CanPlayerInteract()
    {
        return canInteract;
    }

    public void SetIsInteracting(bool value)
    {
        isInteracting = value;
    }

    public bool GetIsInteract()
    {
        return isInteracting;
    }

    //A custom method created for detecting Interacatable objects
    public void DrawDetector()
    {
        if (InteractableObject != null)
        {
            //Create a Ray variable and have it start from the player, and facing forward
            canInteract = Physics2D.OverlapCircle(ContactPoint.position, 1f, DetectThisLayer);
            if (InteractableObject.gameObject.CompareTag("Interactable"))
            {
                canInteract = true;
            }
            else
            {
                canInteract = false;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(ContactPoint.position, 1f);
    }

    public bool IsInteractable()
    {
        //Custom Function that returns 
        return canInteract;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Interactable")
        {
            InteractableObject = collision;
            canInteract = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Interactable")
        {
            canInteract = false;
            InteractableObject = null;
        }
    }


    public void Interact(InputAction.CallbackContext context)
    {
        if (InteractableObject == null)
        {
            Debug.Log("Interact Button Pressed No action");
        }

        if (InteractableObject != null)
        {
            Debug.Log("Interact Button Pressed yes Action");
            //Create a var variable and set it to equal Interactable Object variable and do .GetComponent of The interface for interaction
            var Obj = InteractableObject.GetComponent<IInteractable>();
            //If I press the Interact button DOWN and can interact with other objects
            if (context.started && canInteract)
            {
                
                isInteracting = true;
                if (isInteracting)
                {
                    Obj.Interact();
                    isInteracting = false;
                }

            }
        }
    }

}
