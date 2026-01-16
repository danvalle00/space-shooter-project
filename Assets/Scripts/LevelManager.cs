using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private readonly string gameSceneName = "GameScene";
    private readonly string gameOverSceneName = "GameOver";
    private readonly string mainMenuSceneName = "MainMenu";

    [SerializeField] private float sceneTimeDelay = 2f;
    public void LoadGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting the game...");
        Application.Quit();
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad(gameOverSceneName, sceneTimeDelay));
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(mainMenuSceneName);
        ScoreManager.Instance.ResetScore();
    }

    IEnumerator WaitAndLoad(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }

}
