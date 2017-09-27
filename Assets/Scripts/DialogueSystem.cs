using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour {

    public static DialogueSystem instance { get; set; }
    public GameObject DialoguePanel;
    public string npcName;
    [HideInInspector]
    public List<string> dialogueLines = new List<string>();

    Button continueButton;
    Text dialogueText, nameText;
    int dialogueIndex;

    void Awake() {

        DialoguePanel.SetActive(false);
        continueButton = DialoguePanel.transform.Find("Continue").GetComponent<Button>();
        dialogueText = DialoguePanel.transform.Find("Text").GetComponent<Text>();
        nameText = DialoguePanel.transform.Find("Name").GetChild(0).GetComponent<Text>();
        continueButton.onClick.AddListener(delegate { ContinueDialogue(); });
        
        if (instance != null && instance != this) {
            Destroy(gameObject);
        } else {
            instance = this;
        }
    }

    public void AddNewDialog(string[] lines, string npcName) {

        dialogueIndex = 0;
        dialogueLines = new List<string>(lines.Length);
        dialogueLines.AddRange(lines);
        this.npcName = npcName;
        Debug.Log(dialogueLines.Count);
        CreateDialogue();
    }

    public void CreateDialogue() {
        dialogueText.text = dialogueLines[dialogueIndex];
        nameText.text = npcName;
        DialoguePanel.SetActive(true);
    }

    public void ContinueDialogue() {

        if (dialogueIndex < dialogueLines.Count - 1) {
            dialogueIndex++;
            dialogueText.text = dialogueLines[dialogueIndex];
        } else {
            DialoguePanel.SetActive(false);
        }
    }
}
