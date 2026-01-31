using System.Collections.Generic; 
using UnityEngine;

public class GameStateManager : MonoBehaviour
{


    #region All Game States 

    public MainMenuState mainMenuState;
    public PauseState pauseState;
    public GamePlayState gameplayState;
    public SceneState sceneState; 
    

    #endregion

    private IGameState currentGameState;
    private IGameState previousGameState;
    public string currentGameStateString; //{  get; private set; } 
       

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EnterMenu();
    }

    // Update is called once per frame
    void Update()
    {
        //currentGameState.StateUpdate();
    }

    public void EnterMenu() 
    {
        ChangeGameState(mainMenuState);
    }

    public void EnterPause() 
    {
        ChangeGameState(pauseState);
    }

    public void EnterGameplay() 
    {
        ChangeGameState(gameplayState);
    }

    public void EnterScene() 
    {
        ChangeGameState(sceneState);
    }


    public void ChangeGameState(IGameState gameState) 
    {
        if (currentGameState != null)
        {
            currentGameState.Exit();
            previousGameState = currentGameState;
        }                
        
        currentGameState = gameState;
        currentGameStateString = currentGameState.ToString();
        currentGameState.Enter(); 

    }

}
