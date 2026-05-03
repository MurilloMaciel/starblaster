using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiUpdater : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Health playerHealth;
    
    [Header("Score")]
    [SerializeField] private TextMeshProUGUI scoreText;
    
    private ScoreKeeper _scoreKeeper;
    
    private void Start()
    {
        _scoreKeeper = FindFirstObjectByType<ScoreKeeper>();
        healthSlider.maxValue = playerHealth.GetHealth();
    }

    private void Update()
    {
        scoreText.text = _scoreKeeper.Score.ToString("000000000");
        healthSlider.value = playerHealth.GetHealth();
    }
}
