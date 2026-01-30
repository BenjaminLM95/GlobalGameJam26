using UnityEngine;

public class PauseState : IGameState
{
    public void Enter()
    {
        Debug.Log("Pause Enter");
    }

    public void Update() { }

    public void Exit()
    {
        Debug.Log("Pause Exit");
    }

}
