using UnityEngine;

public class GamePlayState : MonoBehaviour, IGameState
{
    private UIManager uiManager;

    private void Awake()
    {
        uiManager = FindFirstObjectByType<UIManager>();
    }

    public void Enter()
    {
        uiManager.ActivateGameplayUI(); 
        Debug.Log("Gameplay Enter");
    }

    public void StateUpdate() { }

    public void Exit()
    {
        Debug.Log("Gameplay Exit");
    }

}
