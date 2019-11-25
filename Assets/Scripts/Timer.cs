using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : Singleton<Timer>
{
    Text timerText;
    Animation anim;

    public delegate void timer();
    public event timer TimeOut;

    int count = 0;

    private void Awake()
    {
        timerText = GetComponent<Text>();
        anim = GetComponent<Animation>();
    }

    public void StartTimer()
    {
        if (!anim.isPlaying)
        {
            count = 3;
            timerText.text = count.ToString();
            anim.Play();
        }
    }

    public void DecreaseTime()
    {
        count--;
        
        if(count == 0)
        {
            timerText.text = "Start!";
            return;
        }
        timerText.text = count.ToString();
    }

    public void StartGame()
    {
        timerText.text = " ";
        GameManager.Instance.SetStartGame();
        MissTimer.Instance.StartTimer();
    }
}
