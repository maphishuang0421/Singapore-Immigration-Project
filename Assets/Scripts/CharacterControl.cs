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
    public GameObject camera;
    void Awake() {
        camera = UIManager.Instance.camera;
    }
    void Update()
    {
        movementVector.x = Input.GetAxisRaw("Horizontal");
        movementVector.y = Input.GetAxisRaw("Vertical");
        if(currentNPC != null && Input.GetButtonDown("Interact")){
            Debug.Log("starting conversation");
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
        if (camera.activeInHierarchy) {
            camera.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
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
