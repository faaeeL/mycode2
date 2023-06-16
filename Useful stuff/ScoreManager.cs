using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highscoreText;
    int score = 0;
    int highscore = 0;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        highscore = PlayerPrefs.GetInt("Highscore", 0);
        scoreText.text = "Score: " + score.ToString();
        highscoreText.text = "Highscore: " + highscore.ToString();
    }
    public void AddScore()
    {
        score += 1;
        scoreText.text = "Score: " + score.ToString();
        if (highscore < score)
        {
            highscore += 1;
            highscoreText.text = "Highscore: " + highscore.ToString();
            PlayerPrefs.SetInt("Highscore", score);
            
        }
    }
}
