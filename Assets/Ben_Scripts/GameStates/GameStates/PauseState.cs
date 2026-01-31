using UnityEngine;

public class PauseState : MonoBehaviour, IGameState
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
