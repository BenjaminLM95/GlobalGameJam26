using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Character Data")]
public class CharacterData : ScriptableObject //, Imo
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

    public enum personality 
    {
        Anxious,
        Melancholy,
        Content,
        Inspired,
        Playful,
        Bored,
        Excited,
        Relaxed,
        Stressed,
        Peaceful,
        Joyful

    }

    public string _characterName;
    public favColor _favColor;
    public gender _gender;
    public mood _mood;
    public personality _personality;

    public string[] allOptionDialogue = new string[4];

    //public TextAsset dialogueFile;
}