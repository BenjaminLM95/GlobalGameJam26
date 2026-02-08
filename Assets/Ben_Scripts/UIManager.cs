using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private UserInput inputManager;

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
    public GameObject introUI;

    private GameObject lastActiveUI;

    public GameObject gameplayObjects;
  
       

    void Start()
    {
        ActivateMenuUI();
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            ActivateJournalUI();
        }
    }

    void OnEnable()
    {
        //inputManager.OnPauseInputEvent += ActivatePauseUI;
        //inputManager.OnJournalInputEvent += ActivateJournalUI;
    }

    void OnDestroy()
    {
        //inputManager.OnPauseInputEvent -= ActivatePauseUI;
        //inputManager.OnJournalInputEvent -= ActivateJournalUI;
    }

    public void ActivateMenuUI() 
    {
        AudioManager.Instance.PlayMusic("MainMenuMusic");
        ActivateUI(mainMenuUI);
        PauseTime();       
        //LevelManager.Instance.GoToMenuScene();
    }

    public void ResumeMenuUI() 
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
        AudioManager.Instance.PlayMusic("GameplayMusic");
        ActivateUI(gameplayUI);
        gameplayObjects.SetActive(true);
        ResumeTime();
        LevelManager.Instance.GoToGameplayScene(); 
    }

    public void ResumeGamePlay() 
    {
        ActivateUI(gameplayUI);
        ResumeTime();
    }

    public void ActivateSceneUI() 
    {
        ActivateUI(sceneUI);
    }

    public void ActivateJournalUI() 
    {
        AudioManager.Instance.PlaySFX("JournalOpening");
        ActivateUI(journalUI);
        PauseTime();
    }

    public void ActivateWinUI() 
    {
        ActivateUI(winUI);
    }

    public void ActivateLoseUI()
    {
        AudioManager.Instance.PlayMusic("GameOverMusic");
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
    public void ActivateIntroUI()
    {
        ActivateUI(introUI);
        PauseTime();
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
        introUI.SetActive(false);
        gameplayObjects.SetActive(false);
        
    }

    public void GetInputManager() 
    {
        if(inputManager == null) 
        {
            inputManager = FindFirstObjectByType<UserInput>(); 
        }
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
