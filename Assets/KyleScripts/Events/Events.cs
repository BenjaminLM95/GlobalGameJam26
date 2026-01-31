using UnityEngine;

public static partial class Events
{
    public static readonly GameEvent OnPlayerDeath = new();
    public static readonly GameEvent<float> OnPlayerMove = new();
    public static readonly GameEvent<string> OnInteractWithTextObjEvent = new();
    public static readonly GameEvent<CharacterData> OnAddJournalEntry = new();
}
