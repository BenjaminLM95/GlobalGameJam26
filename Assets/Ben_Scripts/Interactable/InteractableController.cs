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

    private UIManager _uiManager; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        userInput.InteractInputEvent += InteractWithObject;
        userInput.OnPauseInputEvent += PauseGame; 
    }

    private void OnDisable()
    {
        userInput.InteractInputEvent -= InteractWithObject;
        userInput.OnPauseInputEvent -= PauseGame;
    }

    private void Start()
    {
        _uiManager = FindFirstObjectByType<UIManager>();
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

    private void PauseGame(InputAction.CallbackContext context) 
    {
        if(_uiManager == null) 
        {
            _uiManager = FindFirstObjectByType<UIManager>();
        }

        if (_uiManager == null)
            return;

        _uiManager.ActivatePauseUI(context); 
    }



}
