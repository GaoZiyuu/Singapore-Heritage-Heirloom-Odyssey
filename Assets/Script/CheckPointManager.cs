using System.Collections;
using System.Collections.Generic;
using TMPro;
using System.Linq;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    [SerializeField] private TMP_Text RickshawText;
    [SerializeField] private TextMeshProUGUI TimerText;
    [SerializeField] private TMP_Text CheckPointText;
    [SerializeField] private TMP_Text CollidedObjText;
    public int checkPointCounter = 0;
    float elaspedTime = 0;
    public GameObject rickshaw;
    public GameObject firstRickshaw;
    public GameObject firstRickshawCanvas;
    public GameObject LastRickshaw;
    private bool finishedGame;
    private bool startTimer;
    public bool playRickShawGame;
    [SerializeField] private GameObject[] checkpointsList;

    private void Start()
    {
        finishedGame = false;
        startTimer = false;
        LastRickshaw.SetActive(false);
        firstRickshawCanvas.SetActive(false);
        playRickShawGame = true;
        for (int i = 0; i < checkpointsList.Count(); i++)
        {
            checkpointsList[i].SetActive(false);
        }

    }
    private void checkPointUI()
    {
        if (checkPointCounter == 1)
        {
            CheckPointText.text = "Checkpoint " + checkPointCounter;
            RickshawText.text = "Head to the Bridge";
            startTimer = true;
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
        }
        else if (checkPointCounter == 4) 
        {
            finishedGame = true;
            startTimer = false;
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
        CheckPointText.text = "Mini game is finished";
        RickshawText.text = "Congrats!!";
        yield return new WaitForSeconds(5f);
        //canvas.SetActive(false);
        rickshaw.SetActive(false);
        LastRickshaw.SetActive(true);
        yield return new WaitForEndOfFrame();
    }
    public void hoverFirstRickshaw()
    {
        if (playRickShawGame)
        {
            firstRickshawCanvas.SetActive(true);
        }
    }
    public void unhoverFirstRickshaw()
    {
        if (playRickShawGame)
        {
            firstRickshawCanvas.SetActive(false);
        }
    }
    public void checkRickshawReady()
    {
        if (playRickShawGame)
        {
            firstRickshaw.SetActive(false);
            rickshaw.SetActive(true);
            for (int i = 0; i < checkpointsList.Count(); i++)
            {
                checkpointsList[i].SetActive(true);
            }
        }
    }
    //public void AddCollidedObjNames(string name)
    //{
    //    CollidedObjText.text += name + '\n';
    //}

    private void Update()
    {
        checkPointUI();
        if (startTimer)
        {
            Timer();
        }

        if (finishedGame)
        {
            StartCoroutine(rickshawFin());
            
        }

    }
}
