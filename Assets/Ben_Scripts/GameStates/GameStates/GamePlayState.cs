using UnityEngine;

public class GamePlayState : IGameState
{
    public void Enter()
    {
        Debug.Log("Gameplay Enter");
    }

    public void Update() { }

    public void Exit()
    {
        Debug.Log("Gameplay Exit");
    }

}
