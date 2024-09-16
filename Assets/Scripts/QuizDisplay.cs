using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using System;

public class QuizDisplay : MonoBehaviour
{
    public UnityEvent quizOver;
    public Image image;
    public TextMeshProUGUI text;
    public TextMeshProUGUI choiceA;
    public TextMeshProUGUI choiceB;
    public TextMeshProUGUI choiceC;
    public TextMeshProUGUI choiceD;
    public TextMeshProUGUI modalDisplay;
    public Image panel;
    public Color rightColor;
    public Color wrongColor;

    public void SetQuestion(QuizQuestion question) {
        image.sprite = question.image;
        text.text = question.question;

        choiceA.text = question.choices[0].choiceContent;
        choiceB.text = question.choices[1].choiceContent;
        choiceC.text = question.choices[2].choiceContent;
        choiceD.text = question.choices[3].choiceContent;
    }

    public void SetResultModal(bool answerCorrect, int worth, string answer) {
        panel.color = answerCorrect? rightColor: wrongColor;
        modalDisplay.text = "";
        modalDisplay.text += answerCorrect? "Correct!" : "Incorrect!";
        modalDisplay.text += "\n";
        modalDisplay.text += answerCorrect? "You gained " : "You lost ";
        modalDisplay.text += "$" + Math.Abs(worth).ToString() + ".";
        modalDisplay.text += "\n";
        modalDisplay.text += "The answer was " + answer;
    }

    public void FinishQuiz() {
        quizOver.Invoke();
    }
}
