using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class TweenPositions : MonoBehaviour
{
    public UnityEvent doneTweening;
    public UnityEvent halfwayDoneTweening;
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private RectTransform start;
    [SerializeField] private RectTransform finish;
    [SerializeField] private float moveDuration = 1.0f; // Duration of the movement animation
    public Tween currentTween;
    private bool halfwayInvoked = false; // To keep track of whether the halfway event has been invoked

    // Function to move the UI element from point A to point B
    public void DoMove(RectTransform pointA, RectTransform pointB)
    {
        // Set the initial position to point A
        rectTransform.anchoredPosition = pointA.anchoredPosition;

        // Tween the UI element from point A to point B
        Tween tween = rectTransform.DOAnchorPos(pointB.anchoredPosition, moveDuration)
                              .SetEase(Ease.OutQuad); // You can choose different easing methods
        currentTween = tween;

        tween.OnUpdate(() =>
        {
            // Check if we have reached halfway through the tween
            if (!halfwayInvoked)
            {
                float progress = tween.Elapsed() / moveDuration;
                if (progress >= 0.5f)
                {
                    halfwayInvoked = true;
                    halfwayDoneTweening.Invoke(); // Invoke halfway event
                }
            }
        })
        .OnComplete(() =>
        {
            doneTweening.Invoke(); // Invoke completion event
            halfwayInvoked = false; // Reset the flag for future tweens
        });
    }

    public void MoveStartFinish() {
        DoMove(start, finish);
    }

    public void MoveFinishStart() {
        DoMove(finish, start);
    }
    public void PauseTween() {
        currentTween.Pause();
        Debug.Log("Tween should be paused.");
        StartCoroutine(waiter());
    }
    public void ResumeTween() {
        currentTween.Play();
    }
    IEnumerator waiter() {
        yield return new WaitForSeconds(5);
        ResumeTween();
    }
}
