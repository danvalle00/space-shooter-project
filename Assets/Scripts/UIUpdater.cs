using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIUpdater : MonoBehaviour
{
    [SerializeField] private Slider HPSlider;
    [SerializeField] private HealthControl playerHealth;

    [SerializeField] private TextMeshProUGUI scoreText;
    private ScoreManager scoreManager;


    private void Start()
    {
        scoreManager = FindFirstObjectByType<ScoreManager>();
        HPSlider.maxValue = playerHealth.GetHealth();
    }


    private void Update()
    {
        scoreText.text = scoreManager.GetScore().ToString("000000000");
        HPSlider.value = playerHealth.GetHealth();
    }
}
