using TMPro;
using UnityEngine;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    private void Start()
    {
        scoreText.text = "Final Score:\n" + ScoreManager.Instance.GetScore();
    }
}
