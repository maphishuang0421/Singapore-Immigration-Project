using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting.FullSerializer;
using System.Data;
using UnityEngine.Events;

public class UIManager : MonoBehaviour
{
    [SerializeField] private RegionInformationScriptableObject selectedRegionInfo;
    [SerializeField] private TextMeshProUGUI regionTitleText;
    [SerializeField] private TextMeshProUGUI infoPanelText;
    [SerializeField] private TextMeshProUGUI chosenRegionPanelText;
    [SerializeField] private TextMeshProUGUI moneyPanelText;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private LessonDisplay lessonDisplay;
    [SerializeField] private QuizDisplay quizDisplay;
    [SerializeField] private EventScriptableObject[] events;
    [SerializeField] private int currentEventIndex = 0;
    [SerializeField] private TextMeshProUGUI endPanelText;
    public GameObject camera;

    public UnityEvent onSimulationStopped;
    public UnityEvent onEventCompleted;
    public UnityEvent onNextEventStarted;
    public UnityEvent onAllEventsFinished;

    private int lessonEntryIndex = 0;
    private int quizQuestionIndex = 0;
    private GameObject currentSimulation;
    private bool quizDone = false;
    private bool lessonDone = false;
    private bool simulationDone = false;

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

    public void GoToNextEvent() {
        currentEventIndex += 1;
        if (currentEventIndex == events.Length) {
            Finished("You won! Thank you for playing.");
        } else {
            onNextEventStarted.Invoke();
        }
    }
    public void Finished(string endscreentext) {
        onAllEventsFinished.Invoke();
        endPanelText.text = endscreentext;
    }
    public void SetRegionName(RegionInformationScriptableObject regionInfo)
    {
        selectedRegionInfo = regionInfo;
        regionTitleText.text = regionInfo.name;
        infoPanelText.text = regionInfo.regionText;
        GameManager.Instance.SetRegionName(regionInfo);
    }

    public void SetChosenRegionPanel()
    {
        chosenRegionPanelText.text = selectedRegionInfo.chosenRegionInfo;
        GameManager.Instance.UpdateMoney(selectedRegionInfo.regionMoney);
    }
    public void SetMonthDeductionPanel()
    {
        chosenRegionPanelText.text = "You have spent $" + selectedRegionInfo.livingExpenses + " on your monthly living expenses.";
    }
    public void UpdateMoneyText(int money)
    {
        moneyPanelText.text = money.ToString();
    }
    
    public void UpdateTimeText()
    {
        timeText.text = events[currentEventIndex].name;
    }

    public void StartLesson() {
        lessonEntryIndex = 0;
        SetLesson();
    }

    void SetLesson() {
        lessonDisplay.SetLesson(
            events[currentEventIndex].lesson.lessonEntries[lessonEntryIndex],
            lessonEntryIndex == 0,
            lessonEntryIndex == events[currentEventIndex].lesson.lessonEntries.Length - 1
        );
    }

    public void ChangeLessonEntry(bool forward) {
        if (forward) {
            lessonEntryIndex++;
        } else {
            lessonEntryIndex--;
        }

        if (lessonEntryIndex == events[currentEventIndex].lesson.lessonEntries.Length - 1){
            MarkLessonDone();
        }

        SetLesson();
    }

    public void MarkLessonDone() {
        lessonDone = true;
        DetermineEventCompleted();
    }

    public void StartQuiz() {
        quizQuestionIndex = 0;
        SetQuiz();
    }

    void SetQuiz() {
        quizDisplay.SetQuestion(events[currentEventIndex].quiz.questions[quizQuestionIndex]);
    }

    public void ChangeQuizQuestion() {
        quizQuestionIndex++;
        if (quizQuestionIndex == events[currentEventIndex].quiz.questions.Length) {
            MarkQuizDone();
            quizDisplay.FinishQuiz();
        } else {
            SetQuiz();
        }
    }

    public void SubmitAnswer(int index) {
        Choice choice = events[currentEventIndex].quiz.questions[quizQuestionIndex].choices[index];

        string correctAnswer = "";
        // Get the correct answer
        foreach (Choice c in events[currentEventIndex].quiz.questions[quizQuestionIndex].choices)
        {
            if (c.rightAnswer) {
                correctAnswer = c.choiceContent;
                break;
            }
        }

        bool answerCorrect = choice.rightAnswer;
        int worth = answerCorrect? selectedRegionInfo.reward : -selectedRegionInfo.penalty;
        GameManager.Instance.UpdateMoney(worth);
        quizDisplay.SetResultModal(answerCorrect, worth, correctAnswer);
    }

    public void MarkQuizDone() {
        quizDone = true;
        DetermineEventCompleted();
    }

    public void StartSimulation() {
        if (currentSimulation != null) {
            Destroy(currentSimulation);
        }

        currentSimulation = Instantiate(events[currentEventIndex].simulation);
        GameManager.Instance.SetUpSimluation(events[currentEventIndex].numNPC);
    }

    public void EndSimulation() {
        onSimulationStopped.Invoke();
        MarkSimulationDone();
    }

    public void DeleteSimulation() {
        if (currentSimulation != null) {
            Destroy(currentSimulation);
        }
    }

    public void MarkSimulationDone() {
        simulationDone = true;
        DetermineEventCompleted();
    }

    public void DetermineEventCompleted() {
        if (quizDone) {
            onEventCompleted.Invoke();
            quizDone = false;
        }
    }
}
