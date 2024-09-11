using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimelineManager : MonoBehaviour
{
    [SerializeField] protected TimelineScriptableObjects currentTimeline;
    [SerializeField] protected int dateNumber;
    [SerializeField] protected Image timelineImage;
    [SerializeField] protected TMPro.TextMeshProUGUI dateTitle;
    [SerializeField] protected TMPro.TextMeshProUGUI dateInfo;
    [SerializeField] protected GameObject timelineGameObject;
    [SerializeField] protected GameObject baseUIObject;
    private static TimelineManager _instance;
    public static TimelineManager Instance {
        get {
            return _instance;
        }
    }
    private void Awake() {
        if (_instance != null && _instance != this) {
            Destroy(this.gameObject);
        } 
        else {
            _instance = this;
        }
    }
    public void forward() {
        if(dateNumber < currentTimeline.dateOrder.Count - 1) {
            dateNumber += 1;
        }
        UpdateTimelineUI(currentTimeline.dateOrder[dateNumber]);
    }
    public void backward() {
        if(dateNumber > 0) {
            dateNumber -= 1;
        }
        UpdateTimelineUI(currentTimeline.dateOrder[dateNumber]);
    }
    public void SetUpTimeline(EventScriptableObject timelineInfo) {
        if(timelineInfo is TimelineScriptableObjects) {
            dateNumber = 0;
            currentTimeline = (TimelineScriptableObjects)timelineInfo;
            timelineGameObject.SetActive(true);
            UpdateTimelineUI(currentTimeline.dateOrder[dateNumber]);
            baseUIObject.SetActive(false);
        }
    }
    public void ExitTimeline() {
        timelineGameObject.SetActive(false);
        baseUIObject.SetActive(true);
    }
    public void UpdateTimelineUI(DatesScriptableObjects thisDateInfo) {
        dateTitle.text = thisDateInfo.nameAndDate;
        timelineImage.sprite = thisDateInfo.dateImage;
        dateInfo.text = thisDateInfo.dateInfo;
    }
}
