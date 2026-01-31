using UnityEngine;

public class PauseState : MonoBehaviour, IGameState
{
    private UIManager uiManager;

    private void Awake()
    {
        uiManager = FindFirstObjectByType<UIManager>();
    }

    public void Enter()
    {
        uiManager.ActivatePauseUI(context: default); 
        Debug.Log("Pause Enter");
    }

    public void StateUpdate() { }

    public void Exit()
    {
        Debug.Log("Pause Exit");
    }

}
