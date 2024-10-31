using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Regional Data", menuName = "ScriptableObjects/RegionInformationScriptableObject", order = 1)]
public class RegionInformationScriptableObject : ScriptableObject
{
    public string regionName;
    public string regionText;
    public int regionMoney;
    public string chosenRegionInfo;
    public int livingExpenses;
    public int reward;
    public int penalty;
    
}
