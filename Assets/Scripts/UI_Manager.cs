using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] protected int score;
    [SerializeField] protected int fails;
    [SerializeField] protected bool gameover;
    [SerializeField] protected TMP_Text score_text;
    [SerializeField] protected TMP_Text fails_text;
    HighScoreManager hs_manager;

    void Start()
    {
        score = fails = 0;
        gameover = false;
        hs_manager = GameObject.FindWithTag("Highscore").GetComponent<HighScoreManager>();
    }
    
    void Update()
    {
        if (fails > 2 && !gameover)
        {
            gameover = true;
            SceneManager.LoadScene(2);
            Debug.Log("GAMEOVER!");
        }
    }

    void OnDestroy()
    {
        if(hs_manager != null) 
        {
                hs_manager.SetScore(score);
        }
    }

    public int GetScore()
    { return score; }

    public void ScoreUp()
    {
        if (fails > 0) 
        {
            fails = 0;
            fails_text.text = fails.ToString();
        }
        score++;
        score_text.text = score.ToString();
    }

    public void LostTarget()
    {
        fails++;
        fails_text.text = fails.ToString();
    }
}
