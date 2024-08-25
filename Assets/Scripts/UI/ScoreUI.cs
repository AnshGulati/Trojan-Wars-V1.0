using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    public Text scoreText;

    private void Awake()
    {
        scoreText = GetComponent<Text>();
    }

    public void UpdateScore(ScoreController scoreController)
    {
        scoreText.text = $"Kills: {scoreController.Score}";
    }

}
