using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class NPCDialogue : MonoBehaviour
{
    public List<string> speechList;
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
        speechList = ServerManager.Instance.dialog.dialog.Split('\n').ToList();
        for(int i=speechList.Count-1; i>=0; i--) {
            if(speechList[i] == "") {
                speechList.RemoveAt(i);
            }
        }
        Debug.Log("starting dialogue manager conversation");
        DialogueManager.Instance.StartConversation(this);
    }
    public void Awake() {
        ServerManager.Instance.GenerateDialog(persona);
    }
}
