using System.Collections.Generic;
using UnityEngine;

public class Journal : MonoBehaviour
{
    List<Entry> entries = new List<Entry>();

    private void OnEnable()
    {
        Events.OnAddJournalEntry.Add(AddEntry);
    }

    private void OnDisable()
    {
        Events.OnAddJournalEntry.Remove(AddEntry);
    }

    public void AddEntry(CharacterData characterData)
    {
        Entry entry = new() { 
            Name = characterData.name,
            Color = characterData._favColor.ToString(),
            Gender = characterData._gender.ToString(),
            Mood = characterData._mood.ToString()
        };
        if (!entries.Contains(entry))
        {
            entries.Add(entry);
        }
    }

    public void RemoveEntry(Entry entry)
    {
        if (entries.Contains(entry))
        {
            entries.Remove(entry);
        }
    }
}

public struct Entry
{
    public string Name;
    public string Color;
    public string Gender;
    public string Mood;
}
