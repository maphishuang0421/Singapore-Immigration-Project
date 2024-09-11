using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "LessonEntry", menuName = "ScriptableObjects/Lesson/LessonEntry", order = 1)]
public class LessonEntry : ScriptableObject
{
    public string title;
    public string info;
    public Sprite image;
}
