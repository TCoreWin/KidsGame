using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    //PUBLIC VARIABLES
    public Text scoreText;
    public ParticleSystem getScoreParticle;

    //PRIVATE VARIABLES
    int score;

    //PROPERTIES
    public bool IsGameStarted { get; private set; }

    private void Start()
    {
        score = 0;
        IsGameStarted = false;
        scoreText.text = score.ToString();
    }

    public void IncScore(Vector3 posSpawnParticle)
    {
        getScoreParticle.transform.position = posSpawnParticle;
        getScoreParticle.Stop();
        getScoreParticle.Play();
        score++;
        scoreText.text = score.ToString();
    }

    public void LoseGame()
    {
        scoreText.text = "You LOSE!";
        score = 0;
        IsGameStarted = false;
    }

    public void StartGame()
    {
        IsGameStarted = true;
        scoreText.text = "0";
    }
}
