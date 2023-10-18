using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] protected HighScoreManager highscore;
    [SerializeField] protected TMP_Text highscore_text;

    void Start()
    {
        highscore = GameObject.FindWithTag("Highscore").GetComponent<HighScoreManager>();
        highscore_text.text = highscore.GetHighScore().ToString();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Endgame()
    {
        Application.Quit();
    }
}
