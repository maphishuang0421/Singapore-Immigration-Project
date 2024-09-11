using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class Punch : MonoBehaviour
{
    [SerializeField] private float punchStrength = 0.2f;
    [SerializeField] private float punchDuration = 0.5f;
    private RectTransform rectTransform;
    private bool isPunching = false;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void DoPunch()
    {
        if (isPunching) return;

        isPunching = true;
        rectTransform.DOPunchScale(Vector3.one * punchStrength, punchDuration)
                     .SetEase(Ease.OutBack)
                     .OnComplete(() => isPunching = false); // Reset flag when animation completes
    }
}
