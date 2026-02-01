using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Basic dialogue manager. Should probably derrive from singleton if we're using a singleton.
/// </summary>
public class DialogueManager : Singleton<DialogueManager>
{
    public GameObject dialoguePanel;     // The UI element to display dialogue.
    public string[] DialogueLines; // Lines of dialogue to display.
    public TextMeshProUGUI dialogueText; // The text component to show dialogue.
    public Queue<string> dialogue; // The queue to manage sentences.
    public Queue<char> dialogueSentence;

    private Coroutine displayCoroutine; // Coroutine that displays text letter by letter.
    private string currentSentence; // Current sentence displayed.
    [SerializeField] bool isDialogueStarted = false;
    public bool IsDialogueStarted { get { return isDialogueStarted; } }

    public override void Awake()
    {
        base.Awake();
    }
    private void OnEnable()
    {
        Events.OnDialogueStarted.Add(StartDialogue);
    }
    private void Start()
    {
        // Initialize empty queue.
        dialogue = new Queue<string>();
        dialogueSentence = new Queue<char>();
    }

    /*public void StartDialogue(string[] sentences)
    {
        // Clear the queue and add the new sentences.
        dialogue.Clear();
        dialoguePanel.SetActive(true);
        
        foreach (string currentString in sentences)
        {
            // Add each sentence to the queue.
            dialogue.Enqueue(currentString);
        }
        // Display the first sentence.
        DisplayNextSentence();
    }*/

    public void StartDialogue(string sentence)
    {
        Debug.Log("Starting dialogue");
        dialogueSentence.Clear();
        dialoguePanel.SetActive(true);

        isDialogueStarted=true;
        foreach (char c in sentence)
        {
            dialogueSentence.Enqueue(c);
        }
        displayCoroutine = StartCoroutine(DisplayDialogueCoroutine(sentence));
        
    }
    public void DisplayNextSentence()
    {
        // If a coroutine is running, stop it and display the full sentence.
        if (displayCoroutine != null)
        {
            StopCoroutine(displayCoroutine);
            // Display the full sentence.
            dialogueText.text = currentSentence;
            // Clear the reference so a new coroutine can be started.
            displayCoroutine = null;
            return;
        }

        if (dialogue.Count == 0)
        {
            EndSentence();
            return;
        }

        // Clear the dialogue text at the start of each sentence.
        dialogueText.text = "";
        // Store the current sentence, so it can be displayed in full.
        currentSentence = dialogue.Dequeue();
        // Store the coroutine so we can stop it abruptly.
        displayCoroutine = StartCoroutine(DisplayDialogueCoroutine(currentSentence));
    }

    public void EndSentence()
    {
        // When dialogue finishes, clear it, disable panel and reactivate player movement and cursor.
        dialogueText.text = "";
        dialoguePanel.SetActive(false);

        // Call event here to notify dialogue ending once we have an event system.
    }

    private IEnumerator DisplayDialogueCoroutine(string currentSentence)
    {
        for (int i = 0; i < currentSentence.Length; i++)
        {
            // Play type writer sound here.
            // While coroutine is running, display the sentence letter by letter.
            dialogueText.text = currentSentence.Substring(0, i + 1);
            Debug.Log("Started dialogue coroutine...");
            yield return new WaitForSecondsRealtime(0.05f);
        }
        yield return new WaitForSecondsRealtime(2f);
        displayCoroutine = null;
        CloseDialogueBox();
    }

    private void CloseDialogueBox()
    {
        dialogueText.text = string.Empty;
        dialoguePanel.SetActive(false);
        isDialogueStarted = false;
    }
}