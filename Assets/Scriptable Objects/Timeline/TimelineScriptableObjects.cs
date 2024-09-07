using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Event Data", menuName = "ScriptableObjects/TimelineScriptableObject", order = 3)]
public class TimelineScriptableObjects : EventScriptableObject
{
    public List<DatesScriptableObjects> dateOrder;
}
