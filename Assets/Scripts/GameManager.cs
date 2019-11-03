using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public Text scoreText;
    public ParticleSystem getScoreParticle;
    int score;

    private void Start()
    {
        
        score = 0;
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
    }
}
