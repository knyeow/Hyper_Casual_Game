using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerData
{
    public  float maxScore = 0;

    public  PlayerData(MainGame maingame)
    {
        maxScore = maingame.maxScore;      
    }


}
