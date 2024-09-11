using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    public string[] speechList;
    public GameObject speechBubble;
    public int NPCindex;
    
    public void SetSpeechBubbleVisibility(bool status) {
        speechBubble.SetActive(status);
    }
    public void SetNPCIndex(int index) {
        NPCindex = index;
    }
    public void StartConversation() {
        DialogueManager.Instance.StartConversation(NPCindex);
    }
}
