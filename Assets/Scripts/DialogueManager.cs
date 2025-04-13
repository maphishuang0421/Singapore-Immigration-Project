using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public TMPro.TextMeshProUGUI textBox;
    public TMPro.TextMeshProUGUI shoptextBox;
    public List<string> currentDialogue;
    public int dialogueIndex = 0;
    private static DialogueManager _instance;
    public TMPro.TextMeshProUGUI buttonText;
    public GameObject dialogueCanvas;
    public GameObject shopCanvas;
    public List<string> charactersToRemove;
    public GameObject teleportButton;

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

    public void StartConversation(NPCDialogue dialogue, bool isTeleport=false) {
        Debug.Log("conversation is starting");
        if (isTeleport != false) {
            Debug.Log("teleport button is on");
            teleportButton.SetActive(true);
            buttonText.text = "Exit";
        } else {
            Debug.Log("teleport button should be off");
            teleportButton.SetActive(false);
            buttonText.text = "Continue";
        }
        dialogueCanvas.SetActive(true);
        dialogueIndex = 0;
        currentDialogue = dialogue.speechList;
        textBox.text = currentDialogue[dialogueIndex];
        }
    public void ContinueDialogue() {
        dialogueIndex += 1;
        if(dialogueIndex == currentDialogue.Count - 1){
            buttonText.text = "Exit";
        }
        if(dialogueIndex > currentDialogue.Count - 1){
            dialogueCanvas.SetActive(false);
        }
        else{
        textBox.text = currentDialogue[dialogueIndex];
        }
    }
    public void OpenShop() {
        shopCanvas.SetActive(true);
        Debug.Log("teleport button should be off");
        teleportButton.SetActive(false);
        shoptextBox.text = "Welcome to the shop!";
        GameManager.Instance.UpdateShopText();
    }
}