using UnityEngine;
using UnityEngine.SceneManagement; 

public class LevelManager : Singleton<LevelManager>
{
    public Player_BloodGuage playerBloodGauge; 
    public PlayerController playerController;

    public GameObject _playerObj;

    public GameObject _playerSpawnPoint = null;

    public override void Awake()
    {
        base.Awake();
    }

    private void OnEnable()
    {
       
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= onSceneLoaded;
    }

    void onSceneLoaded(Scene scene, LoadSceneMode mode)
    {
               
        PlayerGoToSpawnPoint(); 

    }


    public void GoToGameplayScene() 
    {
        SceneManager.sceneLoaded += onSceneLoaded;

        SceneManager.LoadScene("Gameplay");
        _playerObj.SetActive(true);
        playerBloodGauge.FillGauge();       
    }

    public void GoToMenuScene() 
    {
        SceneManager.LoadScene("MainMenu");
        _playerObj.SetActive(false);
    }

    public void PlayerGoToSpawnPoint()
    {
        _playerSpawnPoint = GameObject.Find("PlayerSpawnPoint");

        _playerObj.transform.position = _playerSpawnPoint.transform.position;

        _playerObj.transform.rotation = Quaternion.identity; 
    }

    public void QuitGame() 
    {
        Application.Quit();
    }
}
