using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HighScoreManager : MonoBehaviour
{
    [SerializeField] protected int highscore = 0;
    [SerializeField] protected int score = 0;

    void Awake()
    {
        //somehow get saved highscore
        if(FindObjectsOfType<HighScoreManager>().Length > 1)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public int GetHighScore()
    { return highscore; }

    public int GetScore() 
    { return score; }

    public void SetScore(int s)
    { 
        score = s;
        if (highscore < score)
            highscore = score;
    }
}
