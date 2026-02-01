using TMPro;
using UnityEngine;
using System.Collections; 

public class InteractionDisplay : MonoBehaviour
{
    private TextMeshProUGUI interactionText;
    [SerializeField] private GameObject textSquare; 

    private void Awake()
    {
        interactionText = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Start()
    {
        DisableTextElements();
    }
    private void OnEnable()
    {
        Events.OnInteractWithTextObjEvent.Add(DisplayInteractionText);
    }

    private void OnDisable()
    {
        Events.OnInteractWithTextObjEvent.Remove(DisplayInteractionText);
    }

    public void DisplayInteractionText(string message)
    {
        if (!interactionText.gameObject.activeInHierarchy && !textSquare.gameObject.activeInHierarchy)
        {
            interactionText.gameObject.SetActive(true);
            textSquare.gameObject.SetActive(true);
            interactionText.text = message;
            StartCoroutine("FadeTextAway");
        }
    }

    private IEnumerator FadeTextAway()
    {
        yield return new WaitForSeconds(5f); // wait 2 seconds
        DisableTextElements();
    }

    private void DisableTextElements() 
    {
        if(interactionText != null && textSquare != null)
        {
            interactionText.gameObject.SetActive(false);
            textSquare.gameObject.SetActive(false);
        }
        else if (textSquare == null)
        {
            Debug.Log("Youre bad");
        }
    }
}
