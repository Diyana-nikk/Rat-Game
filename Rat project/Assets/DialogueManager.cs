using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;
    //public Image characterIcon;
    //public TextMeshProUGUI characterName;
    public TextMeshProUGUI dialogueArea;

    public GameObject dialogueBackground;
    public TMP_Text dialogueText;
    public Button dialogueNextButton;

    public float typingSpeed = 0.2F;
    public bool isDialogueActive = false;
    private Queue<DialogueLine> sentences;

    void Start()
    {
        if (Instance == null)
            Instance = this;
        sentences = new Queue<DialogueLine>();
        dialogueBackground.SetActive(false);
        Debug.Log("Setting inactive, " + dialogueBackground.activeSelf + ", " + dialogueBackground.activeInHierarchy);
        dialogueNextButton.onClick.AddListener(DisplayNextSentence);
        Debug.Log("Should be inactive still... " + dialogueBackground.activeSelf + ", " + dialogueBackground.activeInHierarchy);

    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialogueBackground.SetActive(true);
        isDialogueActive = true;
        sentences.Clear();

        foreach (DialogueLine sentence in dialogue.dialogueLines)
        {
            sentences.Enqueue(sentence);
        }
        Debug.Log("Sentence count is: " + sentences.Count);
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        DialogueLine currentSentence = sentences.Dequeue();
        Debug.Log("Displaying sentence: " + currentSentence);

        //characterIcon.sprite = currentSentence.character.icon;
        //characterName.text = currentSentence.character.name;

        StopAllCoroutines();
        StartCoroutine(TypeSentence(currentSentence));
    }

    IEnumerator TypeSentence(DialogueLine dialogueLine)
    {
        dialogueText.text = "";
        Debug.Log("Next line is: " + dialogueLine.line);
        foreach (char letter in dialogueLine.line.ToCharArray())
        {
            Debug.Log("Next letter is: " + letter);
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
    void EndDialogue()
    {
        isDialogueActive = false;
        dialogueBackground.SetActive(false);
    }
}