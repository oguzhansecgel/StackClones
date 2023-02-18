using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public Spawner spaw;
    public int highScore;
    public TMP_Text highScoreText;
    [SerializeField]
    ParticleSystem particleSystem;


    private void Start()
    {
        particleSystem.Stop();
    }
    public void scoreWrite()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "HighScore : " + highScore.ToString();
    }
    // Update is called once per frame
    public void ScoreCheck()
    {
        if (spaw.currentScore > highScore)
        {
            highScore = spaw.currentScore - 1;
            highScoreText.text = "HighScore : " + highScore.ToString();
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
            particleSystem.Play();
        }
        else
        {
            
            highScoreText.text = "HighScore : " + highScore.ToString();
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();

        }
       

    }
}