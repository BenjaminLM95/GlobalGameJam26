using UnityEngine;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{
    [SerializeField]private UserInput inputManager;

    [Header("All the UIs objects")]
    public GameObject mainMenuUI;
    public GameObject pauseUI;
    public GameObject gameplayUI;
    public GameObject sceneUI;
    public GameObject journalUI; 
    public GameObject winUI;
    public GameObject loseUI; 
    public GameObject settingsUI; 
    public GameObject creditsUI; 

    private GameObject lastActiveUI;

    void Start()
    {
        ActivateMenuUI();
    }

    void OnEnable()
    {
        inputManager.OnPauseInputEvent += ActivatePauseUI;
        inputManager.OnJournalInputEvent += ActivateJournalUI;
    }

    void OnDestroy()
    {
        inputManager.OnPauseInputEvent -= ActivatePauseUI;
        inputManager.OnJournalInputEvent -= ActivateJournalUI;
    }

    public void ActivateMenuUI() 
    {
        ActivateUI(mainMenuUI);
        PauseTime();
    }

    public void ActivatePauseUI(InputAction.CallbackContext context) 
    {
        if(context.performed)
        {
            ActivateUI(pauseUI);
            PauseTime();
        }
    }

    public void ActivateGameplayUI() 
    {
        ActivateUI(gameplayUI);
        ResumeTime();
    }

    public void ActivateSceneUI() 
    {
        ActivateUI(sceneUI);
    }

    public void ActivateJournalUI(InputAction.CallbackContext context) 
    {
        if(context.performed){
            ActivateUI(journalUI);
            PauseTime();
        }
    }

    public void ActivateWinUI() 
    {
        ActivateUI(winUI);
    }

    public void ActivateLoseUI() 
    {
        ActivateUI(loseUI);
    }

    public void ActivateSettingsUI() 
    {
        ActivateUI(settingsUI);
    }

    public void ActivateCreditsUI() 
    {
        ActivateUI(creditsUI);
    }

    private void ActivateUI(GameObject ui) 
    {
        DisactivateAllUI();
        ui.SetActive(true);
        lastActiveUI = ui;
    }

    public void ActivateLastUI() 
    {
        DisactivateAllUI();
        if(lastActiveUI != null)
            lastActiveUI.SetActive(true);
    }

    private void DisactivateAllUI() 
    {
        mainMenuUI.SetActive(false);
        pauseUI.SetActive(false);
        gameplayUI.SetActive(false);
        sceneUI.SetActive(false);
        journalUI.SetActive(false);
        winUI.SetActive(false);
        loseUI.SetActive(false);
        settingsUI.SetActive(false);
        creditsUI.SetActive(false);
        
    }

    public void QuitGame() 
    {
        Application.Quit();
    }

    private void PauseTime() 
    {
        Time.timeScale = 0f;
    }
    private void ResumeTime() 
    {
        Time.timeScale = 1f;
    }

    // select ui button with controller d-pad
    

}
