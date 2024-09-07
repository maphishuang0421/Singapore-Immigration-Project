using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Event Data", menuName = "ScriptableObjects/DatesScriptableObjects", order = 4)]
public class DatesScriptableObjects : ScriptableObject
{
    public string nameAndDate;
    public string dateInfo;
    public Sprite dateImage;
}
