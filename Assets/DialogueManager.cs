using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public NPCDialogue[] NPCs;
    public TMPro.TextMeshProUGUI textBox;
    public string[] currentDialogue;
    public int dialogueIndex = 0;
    private static DialogueManager _instance;
    public TMPro.TextMeshProUGUI buttonText;
    public GameObject dialogueCanvas;
     public static DialogueManager Instance {
        get {
            return _instance;
        }
    }

    private void Awake() {
        if (_instance != null && _instance != this) {
            Destroy(this.gameObject);
        } 
        else {
            _instance = this;
        }
    }
    public void SetNPCDialogueInformation() {
        
    }
    public void StartConversation(int NPCindex) {
        dialogueCanvas.SetActive(true);
        dialogueIndex = 0;
        currentDialogue = NPCs[NPCindex].speechList;
        buttonText.text = "Continue";
        textBox.text = currentDialogue[dialogueIndex];
    }
    public void ContinueDialogue() {
        dialogueIndex += 1;
        if(dialogueIndex == currentDialogue.Length - 1){
            buttonText.text = "Exit Conversation";
        }
        if(dialogueIndex > currentDialogue.Length - 1){
            dialogueCanvas.SetActive(false);
        }
        else{
        textBox.text = currentDialogue[dialogueIndex];
        }
    }
    
}
