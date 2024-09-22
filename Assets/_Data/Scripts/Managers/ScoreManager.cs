using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : SingleReference<ScoreManager>
{
    [SerializeField] private int score = 0;
    [SerializeField] private TextMeshProUGUI txtScore;

    private void Start()
    {
        score = 0;
    }

    public void AddScore(float distance)
    {
        int amount = Mathf.Max(Mathf.RoundToInt(5 - distance), 0);
        score += amount;
        txtScore.text = score.ToString();
        txtScore.GetComponent<TextEffect>().PlayAnim();
    }

    public void ResetScore()
    {
        score = 0;
        txtScore.text = score.ToString();
    }
}
