using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class SimulationPointerEvents : MonoBehaviour
{
    public void Delay()
    {
        StartCoroutine(waiter());
    }

    IEnumerator waiter() {
        yield return new WaitForSeconds(5);
    }
}
