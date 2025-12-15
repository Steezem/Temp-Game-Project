using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionRaycast : MonoBehaviour
{
    public DialogueManager manager;


    public void OnInteract(InputAction.CallbackContext context)
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 3f) && context.performed)
        {
            Debug.Log("Interacted with " + hit.transform.name + hit.transform.tag);
            if (hit.transform.tag == "NPC")
            {
                //manager.StartDialogue();
                Debug.Log(gameObject.name + " Interacted with " + hit.transform.name + " " + hit.transform.tag);
                //input = gameObject.GetComponent<PlayerInput>();
                gameObject.GetComponent<PlayerInput>().enabled = false;

            }
        }
    }

}
