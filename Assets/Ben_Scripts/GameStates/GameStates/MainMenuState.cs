using UnityEngine;

public class MainMenuState : MonoBehaviour, IGameState
{
    private UIManager uiManager;

    private void Awake()
    {
        uiManager = FindFirstObjectByType<UIManager>();
    }

    public void Enter()
    {
        uiManager.ActivateMenuUI(); 
        Debug.Log("Main Menu Enter");
    }

    public void StateUpdate() { }

    public void Exit()
    {
        Debug.Log("Main Menu Exit");
    }

}
