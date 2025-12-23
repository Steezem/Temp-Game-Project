using UnityEngine;

public class InvisWallsTrigger : MonoBehaviour
{
    DialogueManager dialogueManager;
    void Start()
    {
        Debug.Log("starting now");
        dialogueManager = FindAnyObjectByType<DialogueManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        
        dialogueManager.StartDialogue(other.transform, other.GetComponent<DialogueTrigger>().dialogue);
        dialogueManager.DisplayNextSentence();
    }
}
