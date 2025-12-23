using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionRaycast : MonoBehaviour
{
    DialogueManager dialogueManager;
    void Start()
    {
        dialogueManager = FindAnyObjectByType<DialogueManager>();
    }
    public void OnInteract(InputAction.CallbackContext context)
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 3f) && context.performed && gameObject.GetComponent<InteractionRaycast>().isActiveAndEnabled)
        {
            if (hit.transform.tag == "NPC")
            {
                // by doing this, you don't have to manually add the DialogueManager to the Interaction Script on the player character
                // Problems may arise if multiple Dialogue Managers are available
                dialogueManager.StartDialogue(hit.transform, hit.transform.GetComponent<DialogueTrigger>().dialogue);
            } else if (hit.transform.tag == "House")
            {
                // Maybe describe houses
            }
        }
    }
}
