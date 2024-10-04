using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    public string[] speechList;
    public GameObject speechBubble;
    public int NPCindex;
    public string persona;
    public void SetSpeechBubbleVisibility(bool status) {
        speechBubble.SetActive(status);
    }
    public void SetNPCIndex(int index) {
        NPCindex = index;
    }
    public void StartConversation() {
        ServerManager.Instance.GenerateDialog(persona);
        DialogueManager.Instance.StartConversation(this);
    }
    public void Start() {
        
    }
}
