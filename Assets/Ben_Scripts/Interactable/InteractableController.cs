using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractableController : MonoBehaviour
{
    [SerializeField] GameObject interactableObject = null;
    [SerializeField] TextMeshProUGUI interactablePromptObj; 

    public UserInput userInput; 

    [Header("Raycast Settings")]
    public float rayDistance = 5f;       // How far the ray should go
    public LayerMask hitLayers;           // Layers to detect (set in Inspector)

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        userInput.InteractInputEvent += InteractWithObject; 
    }

    private void OnDisable()
    {
        userInput.InteractInputEvent -= InteractWithObject;
    }

    // Update is called once per frame
    void Update()
    {

        // Draw the ray in the Scene view for debugging
        Debug.DrawRay(transform.position, transform.forward * rayDistance, Color.red);

        // Perform the raycast
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo, rayDistance, hitLayers))
        {
            // Log the name of the object hit
            //Debug.Log("Hit: " + hitInfo.collider.name);
            
            if(interactableObject == null) 
            {
                interactableObject = hitInfo.collider.gameObject;
                interactablePromptObj.gameObject.SetActive(true); 
            }


        }
        else 
        {
            if(interactableObject != null) 
            {
                interactableObject = null;
                interactablePromptObj.gameObject.SetActive(false);
            }
        }
    }

    private void InteractWithObject(InputAction.CallbackContext context) 
    {
        if(interactableObject != null) 
        {
            interactableObject.GetComponent<BaseInteractable>().Interact();
             
        }
    }





}
