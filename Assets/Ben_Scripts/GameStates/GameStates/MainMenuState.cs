using UnityEngine;

public class MainMenuState : IGameState
{
    public void Enter()
    {
        Debug.Log("Main Menu Enter");
    }

    public void Update() { }

    public void Exit()
    {
        Debug.Log("Main Menu Exit");
    }

}
