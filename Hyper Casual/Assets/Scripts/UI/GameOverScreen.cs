using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] GameObject mainGame;

    [SerializeField] private Text scoreText;
    [SerializeField] private Text maxScoreText;
    public void Setup()
    {
        gameObject.SetActive(true);
        scoreText.text = "Score\n"+ StaticCounters.brickCounter.ToString();
        maxScoreText.text = "Max Score\n" + mainGame.GetComponent<MainGame>().maxScore.ToString();
     }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
        StaticCounters.brickCounter = 0;
        StaticCounters.isGameEnd = false;
    }
}
