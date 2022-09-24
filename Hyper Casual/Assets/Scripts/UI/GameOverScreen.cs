using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    public void Setup()
    {
        gameObject.SetActive(true);
        scoreText.text = StaticCounters.brickCounter.ToString() + "Bricks!";
     }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
        StaticCounters.brickCounter = 0;
    }
}
