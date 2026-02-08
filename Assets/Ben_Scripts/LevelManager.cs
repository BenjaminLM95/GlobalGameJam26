using UnityEngine;
using UnityEngine.SceneManagement; 

public class LevelManager : Singleton<LevelManager>
{
    public override void Awake()
    {
        base.Awake();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToGameplayScene() 
    {
        SceneManager.LoadScene("Gameplay"); 
    }

    public void GoToMenuScene() 
    {
        SceneManager.LoadScene("MainMenu"); 
    }
}
