using TMPro;
using UnityEngine;
using System.Collections; 

public class TextInteractable : MonoBehaviour, IInteractable
{
    public TextMeshPro objectText;
    public float offSetY; 

    private Vector3 textPosition;

    private void Awake()
    {
        gameObject.tag = "Interactable"; 
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textPosition = new Vector3(transform.position.x, transform.position.y + offSetY, transform.position.z);
        objectText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Interact() 
    {
       objectText.gameObject.SetActive(true);
       objectText.transform.position = textPosition;
        
    }

    private IEnumerator FadeTextAway() 
    {
        yield return new WaitForSeconds(2f); // wait 2 seconds
        objectText.gameObject.SetActive(false); 
    }

}
