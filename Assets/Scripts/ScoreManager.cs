using UnityEngine;
public class ScoreManager : MonoBehaviour
{
    private int playerScore = 0;
    public static ScoreManager Instance { get; private set; }

    private void SingletonManager()
    {
        if (Instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Awake()
    {
        SingletonManager();
    }
    public int GetScore()
    {
        return playerScore;
    }

    public void ModifyScore(int amount)
    {

        playerScore += amount;
        playerScore = Mathf.Clamp(playerScore, 0, int.MaxValue);
    }

    public void ResetScore()
    {
        playerScore = 0;
    }

}



