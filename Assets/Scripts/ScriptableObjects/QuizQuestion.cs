using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "QuizQuestion", menuName = "ScriptableObjects/Quiz/QuizQuestion", order = 1)]
public class QuizQuestion : ScriptableObject
{
    public string question;
    public Sprite image;
    public Choice[] choices;
}
