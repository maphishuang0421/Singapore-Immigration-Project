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
    public virtual void StartConversation() {
        speechList = ServerManager.Instance.NPCDialogue[NPCindex].Split('\n').ToList();
        for(int i=speechList.Count-1; i>=0; i--) {
            if(speechList[i] == "") {
                speechList.RemoveAt(i);
            } else {
                foreach(var c in DialogueManager.Instance.charactersToRemove) {
                    speechList[i] = speechList[i].Replace(c, string.Empty);
                } 
            }
        }
        Debug.Log("starting dialogue manager conversation");
        DialogueManager.Instance.StartConversation(this);
        GameManager.Instance.UpdateNpcChecklist(NPCindex);
    }
    public virtual void Awake() {
        ServerManager.Instance.GenerateDialog(persona, NPCindex);
    }
}
