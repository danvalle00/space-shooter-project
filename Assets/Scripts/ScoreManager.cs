using UnityEngine;
public class ScoreManager : MonoBehaviour
{
    private int playerScore = 0;


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



