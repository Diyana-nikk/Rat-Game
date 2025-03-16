using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class DialogueCharacter
{
    public string name;
    public Sprite icon;
}

[System.Serializable]
public class DialogueLine
{
    public DialogueCharacter character;
    [TextArea(3,10)]
    public string line;
}

[System.Serializable]
public class Dialogue
{
    public List<DialogueLine> dialogueLines = new List<DialogueLine>();
}
[System.Serializable]
public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public void TriggerDialogue()
    {
        Debug.Log("Dialogue lines are: " + dialogue.dialogueLines[0]);
        DialogueManager.Instance.StartDialogue(dialogue);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            TriggerDialogue();
        }
    }
}