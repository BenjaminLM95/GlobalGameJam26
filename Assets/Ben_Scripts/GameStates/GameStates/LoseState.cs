using UnityEngine;

public class LoseState : MonoBehaviour, IGameState
{
    private UIManager uiManager;

    private void Awake()
    {
        uiManager = FindFirstObjectByType<UIManager>();
    }

    public void Enter()
    {
        uiManager.ActivateMenuUI();
        Debug.Log("Lose Enter");
    }

    public void StateUpdate() { }

    public void Exit()
    {
        Debug.Log("Lose Exit");
    }
}
