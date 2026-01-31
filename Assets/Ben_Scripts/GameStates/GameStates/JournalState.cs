using UnityEngine;

public class JournalState : MonoBehaviour, IGameState
{
    private UIManager uiManager;

    private void Awake()
    {
        uiManager = FindFirstObjectByType<UIManager>();
    }

    public void Enter()
    {
        uiManager.ActivateMenuUI();
        Debug.Log("Journal Enter");
    }

    public void StateUpdate() { }

    public void Exit()
    {
        Debug.Log("Journal Exit");
    }
}
