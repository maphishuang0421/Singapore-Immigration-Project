using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting.FullSerializer;

public class UIManager : MonoBehaviour
{
    [SerializeField] private RegionInformationScriptableObject selectedRegionInfo;
    [SerializeField] private TextMeshProUGUI regionTitleText;
    [SerializeField] private TextMeshProUGUI infoPanelText;
    [SerializeField] private TextMeshProUGUI chosenRegionPanelText;
    [SerializeField] private TextMeshProUGUI moneyPanelText;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private LessonDisplay lessonDisplay;
    [SerializeField] private GameObject quizPanel;
    [SerializeField] private EventScriptableObject currentEventInfo;

    private int lessonEntryIndex = 0;

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
        currentEventInfo = eventSO;
    }

    void SetLesson() {
        lessonDisplay.SetLesson(
            currentEventInfo.lesson.lessonEntries[lessonEntryIndex],
            lessonEntryIndex == 0,
            lessonEntryIndex == currentEventInfo.lesson.lessonEntries.Length - 1
        );
    }

    public void StartLesson() {
        lessonEntryIndex = 0;
        SetLesson();
    }

    public void ChangeLessonEntry(bool forward) {
        if (forward) {
            lessonEntryIndex++;
        } else {
            lessonEntryIndex--;
        }
        SetLesson();
    }

    public void StartQuiz() {

    }

    public void StartSimulation() {

    }
}
