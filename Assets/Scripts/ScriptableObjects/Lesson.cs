using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Lesson", menuName = "ScriptableObjects/Lesson/Lesson", order = 1)]
public class Lesson : ScriptableObject
{
    public string title;
    public LessonEntry[] lessonEntries;
}
