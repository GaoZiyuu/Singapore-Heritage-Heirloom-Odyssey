using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    [SerializeField] private TMP_Text RickshawText;
    [SerializeField] private TextMeshProUGUI TimerText;
    [SerializeField] private TMP_Text CheckPointText;
    public int checkPointCounter = 1;
    float elaspedTime = 0;
    public GameObject rickshaw;
    private bool finishedGame;

    private void Start()
    {
        finishedGame = false;
    }
    private void checkPointUI()
    {
        if (checkPointCounter == 1)
        {
            CheckPointText.text = "Checkpoint " + checkPointCounter;
            RickshawText.text = "Head to the Bridge";
        }
        else if (checkPointCounter == 2)
        {
            CheckPointText.text = "Checkpoint " + checkPointCounter;
            RickshawText.text = "Go past the Bridge";
        }
        else if (checkPointCounter == 3)
        {

            CheckPointText.text = "Checkpoint " + checkPointCounter;
            RickshawText.text = "Head to the port";
            finishedGame = true;
        }
    }

    private void Timer()
    {
        elaspedTime+= Time.deltaTime;
        int min = Mathf.FloorToInt(elaspedTime/60);
        int sec = Mathf.FloorToInt(elaspedTime%60);
        TimerText.text = string.Format("{0:00}:{1:00}", min,sec);
    }
    IEnumerator rickshawFin()
    {
        yield return new WaitForSeconds(3f);
        CheckPointText.text = "Mini game is finished";
        RickshawText.text = "Congrats!!";
        yield return new WaitForSeconds(5f);
        //canvas.SetActive(false);
        rickshaw.SetActive(false);
        yield return new WaitForEndOfFrame();
    }

  
    private void Update()
    {
        checkPointUI();
        if (checkPointCounter < 3)
        {
            Timer();
        }

        if (finishedGame)
        {
            StartCoroutine(rickshawFin());
        }
    }
}
