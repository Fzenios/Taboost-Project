using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName ="New Card")]
public class CardsTemp : ScriptableObject
{
    public string MainWord;
    public string NoWord1;
    public string NoWord2;
    public string NoWord3;
    public string NoWord4;
    public string NoWord5;
    public string CardCreator;

    public enum Difficulty {easy, medium, hard, NSFW};
    public Difficulty difficulty;
}
