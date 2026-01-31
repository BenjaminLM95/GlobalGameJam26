using TMPro;
using UnityEngine;
using System.Collections;
using System.Buffers.Text;

public class TextInteractable : BaseInteractable
{
    public TextMeshPro objectText;
    public float offSetY;
    public string message; 

    private Vector3 textPosition;

    private void Awake()
    {
        gameObject.tag = "Interactable"; 
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textPosition = new Vector3(transform.position.x - objectText.transform.localScale.x / 2, transform.position.y + offSetY, transform.position.z);
        objectText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Interact()
    { 
        Events.OnInteractWithTextObjEvent.Publish(message);      

    }

    private IEnumerator FadeTextAway() 
    {
        yield return new WaitForSeconds(10f); // wait 2 seconds
        objectText.gameObject.SetActive(false); 
    }

}
