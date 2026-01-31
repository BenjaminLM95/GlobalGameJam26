using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("All the UIs objects")]
    public GameObject mainMenuUI;
    public GameObject pauseUI;
    public GameObject gameplayUI;
    public GameObject sceneUI;
    public GameObject journalUI; 
    public GameObject winUI;
    public GameObject loseUI; 



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateMenuUI() 
    {
        ActivateUI(mainMenuUI);
    }

    public void ActivatePauseUI() 
    {
        ActivateUI(pauseUI);
    }

    public void ActivateGameplayUI() 
    {
        ActivateUI(gameplayUI);
    }

    public void ActivateSceneUI() 
    {
        ActivateUI(sceneUI);
    }

    public void ActivateJournalUI() 
    {
        ActivateUI(journalUI);
    }

    public void ActivateWinUI() 
    {
        ActivateUI(winUI);
    }

    public void ActivateLoseUI() 
    {
        ActivateUI(loseUI);
    }


    private void ActivateUI(GameObject ui) 
    {
        DisactivateAllUI();
        ui.SetActive(true);
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
        
    }

}
