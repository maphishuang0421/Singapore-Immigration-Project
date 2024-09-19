using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationPortal : MonoBehaviour
{
    public GameObject prompt;
    private bool playerInRange = false;
    
    public void SetPromptVisibility(bool status) {
        prompt.SetActive(status);
    }

    public void Update() {
        if (playerInRange && Input.GetButtonDown("Interact")) {
            GoBack();
        }
    }

    public void GoBack() {
        UIManager.Instance.EndSimulation();
    }

    public void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            playerInRange = true;
            prompt.SetActive(true);
        }
    }

    public void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            playerInRange = false;
            prompt.SetActive(false);
        }
    }
}
