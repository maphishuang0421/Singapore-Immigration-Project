using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Quiz", menuName = "ScriptableObjects/Quiz/Quiz", order = 1)]
public class Quiz : ScriptableObject
{
    public string title;
    public QuizQuestion[] questions;
}
