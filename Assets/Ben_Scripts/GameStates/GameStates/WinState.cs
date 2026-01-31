using UnityEngine;

public class WinState : MonoBehaviour, IGameState
{
    private UIManager uiManager;

    private void Awake()
    {
        uiManager = FindFirstObjectByType<UIManager>();
    }

    public void Enter()
    {
        uiManager.ActivateMenuUI();
        Debug.Log("Win Enter");
    }

    public void StateUpdate() { }

    public void Exit()
    {
        Debug.Log("Win Exit");
    }
}
