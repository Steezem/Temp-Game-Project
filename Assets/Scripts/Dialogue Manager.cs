using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject playerCharacter;
    public TextMeshProUGUI speakerNameText;
    public TextMeshProUGUI dialogueText;
    public Button[] optionButtons;
    public GameObject dialoguePanel;

    public DialogueLine[] dialogueLines;
    private int currentLineIndex = 0;
    private bool inDialogue = false;

    void Start()
    {
        dialoguePanel.SetActive(false);

        //Eventually load dialogue from a json file permaybe
    }


    public void StartDialogue()
    {
        playerCharacter.GetComponent<CharacterMovement>().enabled = false;
        dialoguePanel.SetActive(true);
        currentLineIndex = 0;
        DisplayDialogueLine(dialogueLines[currentLineIndex]);
        inDialogue = true;
    }

    public void OnInteractInConvo(InputAction.CallbackContext context)
    {
        Debug.Log("Yes it gets recognized");
        DisplayNextLine();
    }

    public void DisplayNextLine()
    {
        currentLineIndex++;
        if (currentLineIndex < dialogueLines.Length)
        {
            DisplayDialogueLine(dialogueLines[currentLineIndex]);
        } else
        {
            inDialogue = false;
            EndDialogue();
        }
    }

    private void DisplayDialogueLine(DialogueLine line)
    {

        //TODO implement slow rolling out of text
        //speakerNameText.text = line.speakerName;
        //dialogueText.text = line.text;

        if (line.options != null && line.options.Length > 0)
        {
            EnableOptions(line.options);
        } 
        else
        {
            DisableOptions();
        }
    }

    public void ChooseOption(int optionIndex)
    {
        DialogueOption chosenOption = dialogueLines[currentLineIndex].options[optionIndex];
        currentLineIndex = chosenOption.nextLineIndex;
        DisplayDialogueLine(dialogueLines[currentLineIndex]);
    }

    //If Dialogue has options to choose from - enable them
    private void EnableOptions(DialogueOption[] options)
    {
        for (int i = 0; i < optionButtons.Length; i++)
        {
            if (i < options.Length)
            {
                int optionIndex = i;
                optionButtons[i].gameObject.SetActive(true);
                optionButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = options[i].text;
                optionButtons[i].onClick.RemoveAllListeners();
                optionButtons[i].onClick.AddListener(() => ChooseOption(optionIndex));
            }
            else
            {
                optionButtons[i].gameObject.SetActive(false);
            }
        }
    }

    private void DisableOptions()
    {
        foreach(Button button in optionButtons)
        {
            button.gameObject.SetActive(false); 
        }
    }

    private void EndDialogue()
    {
        dialoguePanel.SetActive(false);
    }
}
