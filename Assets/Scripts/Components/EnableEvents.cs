using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnableEvents : MonoBehaviour
{
    public UnityEvent onEnabled;
    public UnityEvent onDisabled;

    void OnEnable() {
        onEnabled.Invoke();
    }

    void OnDisable() {
        onDisabled.Invoke();
    }
}
