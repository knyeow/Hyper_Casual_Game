using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private Text score;

    private float _score;

    private void Start()
    {
        score = GetComponent<Text>();
    }

    private void FixedUpdate()
    {
        _score = StaticCounters.brickCounter;

        score.text = _score.ToString();
        
    }
}
