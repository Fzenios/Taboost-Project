using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AllData", menuName ="AllData")]
public class AllDataHere : ScriptableObject
{
    public string Team1Name, Team2Name, Team3Name, Team4Name;
    public float TeamCount, TimerPick, PassToLosePick, WordsCount, RoundsCount;
    
    public bool EasyCards, MediumCards, HardCards; 
    public Color TeamColor1, TeamColor2, TeamColor3, TeamColor4;


}
