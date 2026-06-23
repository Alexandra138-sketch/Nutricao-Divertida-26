using UnityEngine;

public class GameManager2 : MonoBehaviour
{
    public static GameManager2 instance;
    private static int score = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void IncrementRightAnswer()
    {
        score++;
        Debug.Log("Score: " + score);
    }

    public static void IncrementWrongAnswer()
    {
        score--;
    }

    public static int GetScore()
    {
        return score;
    }

    public static void Reset()
    {
        score = 0;
    }
}