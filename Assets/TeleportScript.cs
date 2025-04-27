using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : NPCDialogue
{
    [SerializeField] private Transform playerTransform;
    public Vector2 roomPosition;

    public override void StartConversation() {
        if (!GameManager.Instance.minigameDone) {
            speechList = new List<string> {"You are entering a room where many objects are breaking laws. In order to not get fined, clean up the area. You have 2 minutes before the inspector comes."};
            DialogueManager.Instance.StartConversation(this, true);
            GameManager.Instance.setTeleportVariables(playerTransform, roomPosition);
        } else {
            speechList = new List<string> {"You have already completed the minigame."};
            DialogueManager.Instance.StartConversation(this);
        }
        
    }
}
