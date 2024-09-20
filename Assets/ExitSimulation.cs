using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitSimulation : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        DialogueManager.Instance.ExitSimulation();
    }
}
