using UnityEngine;

public class SceneState : MonoBehaviour, IGameState
{

    private UIManager uiManager;

    private void Awake()
    {
        uiManager = FindFirstObjectByType<UIManager>();
    }
    public void Enter()
    {
        uiManager.ActivateSceneUI(); 
        Debug.Log("Scene Enter");
    }

    public void StateUpdate() { }

    public void Exit()
    {
        Debug.Log("Scene Exit");
    }

}
