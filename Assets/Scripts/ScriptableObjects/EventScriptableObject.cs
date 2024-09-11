using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Event Data", menuName = "ScriptableObjects/EventScriptableObject", order = 2)]
public class EventScriptableObject : ScriptableObject
{
   public string title;
   public string info;
   public Sprite image;
   public Lesson lesson;
   public Quiz quiz;
}
