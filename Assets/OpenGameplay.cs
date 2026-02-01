using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenGameplay : MonoBehaviour
{
    public GameObject mainMenuUI;
    public void GoToGameplay()
    {
        mainMenuUI.SetActive(false);

        // switch to gameplay scen
        SceneManager.LoadScene("Gameplay");
        //SceneManager.LoadScene(gameScene.ToString());

    }
}
