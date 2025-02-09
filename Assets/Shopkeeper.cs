using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopkeeper : NPCDialogue
{
    protected void Awake() {
    }
    public void StartShop() {
        
        Debug.Log("starting dialogue manager conversation");
        DialogueManager.Instance.StartConversation(this);
    }

}
