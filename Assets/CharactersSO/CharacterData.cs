using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Character Data")]
public class CharacterData : ScriptableObject //, Imo
{
    bool isHunter = false;
    public enum favColor
    {
        Red, Green, Blue
    }

    public enum gender
    {
        Female,Male, nonBinary
    }

    public enum weapons 
    {
        HolyWater, Stake, Garlic
    }


    public string _characterName;
    // Color, gender can be dialogue keywords.
    public favColor _favColor;
    public gender _gender;
    //public string _keyword;
    public string[] keyWords = new string[4];

    public string[] allOptionDialogue = new string[4];

    //public TextAsset dialogueFile;
}