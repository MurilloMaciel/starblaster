using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private ScoreKeeper _scoreKeeper;

    private void Awake()
    {
        _scoreKeeper = FindFirstObjectByType<ScoreKeeper>();
    }

    public void LoadGame()
    {
        _scoreKeeper.ResetScore();
        SceneManager.LoadScene("GameScene");
    }
    
    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad("GameOverScene", 2F));
    }
    
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void QuitGame()
    {
        print("Quit Game");
        Application.Quit();
    }

    public IEnumerator WaitAndLoad(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
