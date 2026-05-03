using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private static ScoreKeeper _instance = null;

    private void Awake()
    {
        ManageSingleton();
    }

    private void ManageSingleton()
    {
        if (_instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    
    public int Score { get; private set; }

    public void AddScore(int value)
    {
        Score += value;
        Score = Mathf.Clamp(Score, 0, int.MaxValue);
    }

    public void ResetScore()
    {
        Score = 0;
    }
}
