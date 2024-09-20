using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Event Data", menuName = "ScriptableObjects/EventScriptableObject", order = 2)]
public class EventScriptableObject : ScriptableObject
{
   public string eventName;
   public string eventInfo;
   public Sprite eventImage;
   public List<int> moneyChange;
   public List<int> weeksPassed;
   public List<string> eventOptions;
   public List<string> eventResultInfo;
   public Vector2 playerPosition;
   public enum eventType{
    quiz, timeline, simulation
   }
   public eventType thisEventType;
   public List<EventScriptableObject> subEvent;

   public void eventFunction() {

   }
}
