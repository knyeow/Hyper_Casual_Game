using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class MainGame : MonoBehaviour
{
    public  float maxScore =0;

    private void Start()
    {
        LoadPlayer();
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }

    private void FixedUpdate()
    {
        if(StaticCounters.isGameEnd)
        CheckMaxScore();
    }

    public  void CheckMaxScore()
    {
        if (maxScore < StaticCounters.brickCounter)
        {
            maxScore = StaticCounters.brickCounter;
            savePlayer();
        }
    }

    public void savePlayer()
    {
        SaveSystem.SavePlayer(this);
    }
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        maxScore = data.maxScore;
    }

}
