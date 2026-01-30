using UnityEngine;

public class SceneState : IGameState
{
    public void Enter()
    {
        Debug.Log("Scene Enter");
    }

    public void Update() { }

    public void Exit()
    {
        Debug.Log("Scene Exit");
    }

}
