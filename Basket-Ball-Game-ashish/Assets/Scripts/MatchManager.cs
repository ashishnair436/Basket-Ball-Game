using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MatchManager : MonoBehaviour
{

    public float matchLength = 180f;

    public float currentMatchTime;

    void Start()
    {
        SetUpTimer();
    }

    void Update()
    {

        if (currentMatchTime > 0f)
        {
            currentMatchTime -= Time.deltaTime;

            if (currentMatchTime <= 0f)
            {
                currentMatchTime = 0f;

                SceneManager.LoadScene(0);
            }

        }

        UpdateTimerDisplay();

    }

    public void SetUpTimer()
    {
        if (matchLength > 0)
        {
            currentMatchTime = matchLength;
            UpdateTimerDisplay();
        }
    }

    public void UpdateTimerDisplay()
    {
        var timeToDisplay = System.TimeSpan.FromSeconds(currentMatchTime);

        UIManager.instance.timerText.text = timeToDisplay.Minutes.ToString("00") + ":" + timeToDisplay.Seconds.ToString("00");
    }
}
