using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissTimer : Singleton<MissTimer>
{
    public Text timerText;

    int count = 0;

    //IEnumerator Timer;
    WaitForSeconds WF = new WaitForSeconds(1f);

    private void Awake()
    {
        //Timer = DecTimer();
    }

    public void StartTimer()
    {
        StartCoroutine(DecTimer(10));
    }

    public void RefreshTimer(int value)
    {
        StopAllCoroutines();

        StartCoroutine(DecTimer(value));
    }

    IEnumerator DecTimer(int value)
    {
        count = value;
        timerText.text = count.ToString();

        while (true)
        {
            yield return WF;
            count--;
            if (count == 0)
            {
                GameManager.Instance.LoseGame();
                yield break;
            }
            timerText.text = count.ToString();
        }
    }
}
