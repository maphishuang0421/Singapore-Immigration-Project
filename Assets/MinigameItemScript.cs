using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameItemScript : NPCDialogue
{
    public string objectName;
    public GameObject sprite;
    public bool isExitObject;
    public override void StartConversation() {
        if (!isExitObject) {
            GameManager.Instance.SetMinigameItemState(objectName);
            sprite.SetActive(!sprite.activeSelf);
        } else {
            GameManager.Instance.EndMinigame();
        }
    }
}
