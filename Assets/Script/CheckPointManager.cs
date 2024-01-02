using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    [SerializeField] private TMP_Text RickshawText;
    [SerializeField] private TextMeshProUGUI TimerText;
    [SerializeField] private TMP_Text CheckPointText;
    public int checkPointCounter = 0;
    float elaspedTime = 0;

    private void checkPointUI()
    {
        if (checkPointCounter == 0)
        {
            CheckPointText.text = "Checkpoint " + checkPointCounter;
            RickshawText.text = "Head to the Bridge";
        }
        else if (checkPointCounter == 1)
        {
            CheckPointText.text = "Checkpoint " + checkPointCounter;
            RickshawText.text = "Go past the Bridge";
        }
        else if (checkPointCounter == 2)
        {

            CheckPointText.text = "Checkpoint " + checkPointCounter;
            RickshawText.text = "Head to the port";
        }
    }

    private void Timer()
    {
        elaspedTime+= Time.deltaTime;
        int min = Mathf.FloorToInt(elaspedTime/60);
        int sec = Mathf.FloorToInt(elaspedTime%60);
        TimerText.text = string.Format("{0:00}:{1:00}", min,sec);
    }
    private void Update()
    {
        checkPointUI();
        if (checkPointCounter < 2)
        {
            Timer();
        }
    }
}
