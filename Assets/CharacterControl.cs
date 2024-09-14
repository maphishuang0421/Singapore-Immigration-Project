using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    Vector2 movementVector;
    public float playerSpeed;
    public Rigidbody2D rigidBody;
    public NPCDialogue currentNPC;
    public Animator animator;
    
    void Update()
    {
        movementVector.x = Input.GetAxisRaw("Horizontal");
        movementVector.y = Input.GetAxisRaw("Vertical");
        if(Input.GetButton("Interact")){
            currentNPC.StartConversation();
        }
        if(movementVector.x > 0){
            animator.Play("playerWalkRight");
        }
        else if(movementVector.x < 0){
            animator.Play("playerWalkLeft");
        }
        else if(movementVector.y > 0){
            animator.Play("playerWalkUp");
        }
        else if(movementVector.y < 0){
            animator.Play("playerWalkDown");
        }
        else{
            animator.Play("idle");
        }
    }
    void FixedUpdate()
    {
        rigidBody.MovePosition(rigidBody.position + Vector2.ClampMagnitude(playerSpeed * movementVector, playerSpeed) * Time.fixedDeltaTime);
    }
    void OnTriggerEnter2D(Collider2D col) 
    {
        if(col.gameObject.TryGetComponent<NPCDialogue>(out NPCDialogue NPC)) {
            NPC.SetSpeechBubbleVisibility(true);
            currentNPC = NPC;
        }
    }
    void OnTriggerExit2D(Collider2D col) 
    {
        if(col.gameObject.TryGetComponent<NPCDialogue>(out NPCDialogue NPC)) {
            NPC.SetSpeechBubbleVisibility(false);
            currentNPC = null;
        }
    }
}
