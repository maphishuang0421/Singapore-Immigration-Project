using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] protected RegionInformationScriptableObject selectedRegionInfo;
    [SerializeField] protected TMPro.TextMeshProUGUI regionTitleText;
    [SerializeField] protected TMPro.TextMeshProUGUI infoPanelText;
    [SerializeField] protected TMPro.TextMeshProUGUI chosenRegionPanelText;
    [SerializeField] protected TMPro.TextMeshProUGUI moneyPanelText;
    [SerializeField] protected TMPro.TextMeshProUGUI timeText;
    [SerializeField] protected TMPro.TextMeshProUGUI eventTextPanel;
    [SerializeField] protected Image eventImagePanel;
    [SerializeField] protected EventScriptableObject currentEventInfo;
    [SerializeField] protected TMPro.TextMeshProUGUI[] eventOptionText;
    [SerializeField] public GameObject progressTimeButton;
    [SerializeField] public GameObject nextEventButton;
    [SerializeField] public GameObject option4;
    [SerializeField] public int currentButtonNumber;
    private bool buttonDisabled = false;
    private static UIManager _instance;
    public static UIManager Instance {
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

    public void SetRegionName(RegionInformationScriptableObject regionInfo)
    {
        selectedRegionInfo = regionInfo;
        regionTitleText.text = regionInfo.name;
        infoPanelText.text = regionInfo.regionText;
    }

    public void SetChosenRegionPanel()
    {
        chosenRegionPanelText.text = selectedRegionInfo.chosenRegionInfo;
        GameManager.Instance.UpdateMoney(selectedRegionInfo.regionMoney);
    }
    public void UpdateMoneyText(int money)
    {
        moneyPanelText.text = money.ToString();
    }
    
    public void UpdateTimeText(string time)
    {
        timeText.text = time;
    }

    public void CreateEvent(EventScriptableObject eventSO) 
    {
        buttonDisabled = false;
        if(eventOptionText.Length > eventSO.eventOptions.Count) {
            option4.SetActive(false);
        } 
        else {
            option4.SetActive(true);
        }
        progressTimeButton.SetActive(false);
        nextEventButton.SetActive(false);
        eventTextPanel.text = eventSO.eventInfo;
        eventImagePanel.sprite = eventSO.eventImage;
        currentEventInfo = eventSO;
        for(int i = 0; i < eventSO.eventOptions.Count; i++)
        {
            eventOptionText[i].text = eventSO.eventOptions[i];
        }
    }
    public void EventButtonAction(int buttonNumber)
    {   
        if(!buttonDisabled) {
            currentButtonNumber = buttonNumber;
            eventTextPanel.text = currentEventInfo.eventResultInfo[buttonNumber - 1];
            GameManager.Instance.UpdateMoney(currentEventInfo.moneyChange[buttonNumber - 1]);
            if (currentEventInfo.subEvent[buttonNumber - 1] == null)
            {
                progressTimeButton.SetActive(true);
                buttonDisabled = true;
                //GameManager.Instance.EventCounter();
            } 
            else if(currentEventInfo.subEvent[buttonNumber - 1].thisEventType == EventScriptableObject.eventType.timeline) {
                TimelineManager.Instance.SetUpTimeline(currentEventInfo.subEvent[buttonNumber - 1]);
            }
            else
            {
                nextEventButton.SetActive(true);
                buttonDisabled = true;
            }
        }
    }
    public void GoSubEvent() 
    {
        CreateEvent(currentEventInfo.subEvent[currentButtonNumber - 1]);
    }
}
