using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public UnityEvent timerDone;

    public float duration;

    float timer;
    bool timerOver;

    public void StartTimer() {
        timer = duration;
        timerOver = false;
    }

    void Update() {
        if (timerOver) return;

        timer -= Time.deltaTime;
        if (timer < 0) {
            timerDone.Invoke();
            timerOver = true;
        }
    }
}
