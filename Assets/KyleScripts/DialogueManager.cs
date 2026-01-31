using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Basic dialogue manager. Should probably derrive from singleton if we're using a singleton.
/// </summary>
public class DialogueManager : MonoBehaviour
{
    public GameObject dialoguePanel;     // The UI element to display dialogue.
    public string[] DialogueLines; // Lines of dialogue to display.
    public TextMeshProUGUI dialogueText; // The text component to show dialogue.
    public Queue<string> dialogue; // The queue to manage sentences.

    private Coroutine displayCoroutine; // Coroutine that displays text letter by letter.
    private string currentSentence; // Current sentence displayed.

    private void Start()
    {
        // Initialize empty queue.
        dialogue = new Queue<string>();
    }

    public void StartDialogue(string[] sentences)
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
            yield return new WaitForSecondsRealtime(0.05f);
        }
        yield return new WaitForSecondsRealtime(1f);
        displayCoroutine = null;
    }
}