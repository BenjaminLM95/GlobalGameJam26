using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Character Data")]
public class CharacterData : ScriptableObject
{
    public enum favColor
    {
        Red, Green, Blue, Pink, Yellow
    }

    public enum gender
    {
        Female,Male,nonBinary
    }

    public enum mood
    {
        Depressed,
        Nice,
        Annoyed,
        Talkative
    }

    public string _characterName;
    public favColor _favColor;
    public gender _gender;
    public mood _mood;

    public TextAsset dialogueFile;
}