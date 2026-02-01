using UnityEngine;


public class InteractableCharacter : BaseInteractable
{
    [SerializeField] private CharacterData characterData;
    [SerializeField] private bool firstTime = false;
    public string characterDialogue;
    private int currentDialogueIndex = 0;

    public bool isHunter = false; 


    private void Awake()
    {
        gameObject.tag = "Interactable";
        isHunter = false; 
        GetRandomMood();
    }

    void OnDisable()
    {
        //isHunter = false; 
    }

    public override void Interact()
    {
        Debug.Log("Interact called");
        GetRandomMood();

        if (!firstTime)
        {
            // Check if its the first time talking to the character, in that case you get their info in the journey
            Events.OnAddJournalEntry.Publish(characterData);
            firstTime = true;
        }

        if (!DialogueManager.Instance.IsDialogueStarted)
        {
            // TODO instead of publishing entire string, find a key word to give clue of who is talking.
            if(currentDialogueIndex < characterData.keyWords.Length && currentDialogueIndex > 0)
            {
                Debug.Log("Adding clue to journal");
                string clue = characterData.keyWords[currentDialogueIndex];
                Events.AddClueToJournal.Publish(clue);
            }
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
        currentDialogueIndex = numIndex - 1;
        return characterData.allOptionDialogue[numIndex - 1]; 
    }

    public string GetParticipantName() 
    {
        return characterData.name; 
    }

    public void BecomesTheHunter()
    {
        isHunter = true; 
    }
}
