using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{
    HighScoreManager hs_manager;
    [SerializeField] protected TMP_Text highscore_text;
    [SerializeField] protected TMP_Text score_text;

    void Start()
    {
        hs_manager = GameObject.FindWithTag("Highscore").GetComponent<HighScoreManager>();

        if (hs_manager != null)
        {
            score_text.text = hs_manager.GetScore().ToString();
            highscore_text.text = hs_manager.GetHighScore().ToString();
        }
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }

    public void MenuButton()
    {
        SceneManager.LoadScene(0);
    }
}
