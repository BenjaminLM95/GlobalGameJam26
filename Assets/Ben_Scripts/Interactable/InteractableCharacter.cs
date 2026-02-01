using UnityEngine;


public class InteractableCharacter : BaseInteractable
{
    [SerializeField] private CharacterData characterData;
    [SerializeField] private bool firstTime = false;
    public string characterDialogue;   


    private void Awake()
    {
        gameObject.tag = "Interactable";
        GetRandomMood();
    }

    public override void Interact()
    {
        GetRandomMood();

        if (!firstTime)
        {
            // Check if its the first time talking to the character, in that case you get their info in the journey
            Events.OnAddJournalEntry.Publish(characterData);
            firstTime = true;
        }

        if (!DialogueManager.Instance.IsDialogueStarted)
        {
            Events.OnDialogueStarted.Publish(characterDialogue);
        }

    }

    public void GetRandomMood() 
    {
        // Get a random number between 1 and the length of all the dialogue the character has. In this case should have 4
        int randomNumber = Random.Range(1, characterData.allOptionDialogue.Length + 1);
        // Based on that random number, will get the string based on the array
        characterDialogue = GetTheDialogue(randomNumber);
    }

    public string GetTheDialogue(int numIndex) 
    {

        return characterData.allOptionDialogue[numIndex - 1]; 
    }

    public string GetParticipantName() 
    {
        return characterData.name; 
    }
}
