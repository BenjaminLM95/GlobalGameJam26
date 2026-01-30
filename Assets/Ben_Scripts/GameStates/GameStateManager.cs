using System.Collections.Generic; 
using UnityEngine;

public class GameStateManager : MonoBehaviour
{


    #region All Game States 

    public IGameState mainMenuState;
    public IGameState pauseState;
    public IGameState gameplayState;
    public IGameState sceneState; 
    public IGameState winGameState;
    public IGameState loseGameState; 

    #endregion

    private IGameState currentGameState;
    private IGameState previousGameState;
    public string currentGameStateString {  get; private set; } 
       

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentGameState.Update();
    }

    public void ChangeGameState(IGameState gameState) 
    {
        currentGameState.Exit();
        previousGameState = currentGameState; 
        currentGameState = gameState;
        currentGameStateString = currentGameState.ToString();
        currentGameState.Enter(); 

    }

}
