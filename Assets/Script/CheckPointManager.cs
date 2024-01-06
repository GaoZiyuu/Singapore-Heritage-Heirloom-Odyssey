using System.Collections;
using System.Collections.Generic;
using TMPro;
using Firebase.Database;
using Firebase;
using Firebase.Auth;
using System.Threading.Tasks;
using System.Linq;
using UnityEngine;

/// <summary>
/// Manages the checkpoints, timer, and UI for a rickshaw game.
/// </summary>
public class CheckPointManager : MonoBehaviour
{
    /// <summary>
    /// Text component for displaying Rickshaw information.
    /// </summary>
    [SerializeField] private TMP_Text RickshawText;

    /// <summary>
    /// Text component for displaying the timer.
    /// </summary>
    [SerializeField] private TextMeshProUGUI TimerText;

    /// <summary>
    /// Text component for displaying checkpoint information.
    /// </summary>
    [SerializeField] private TMP_Text CheckPointText;

    /// <summary>
    /// Text component for displaying collided object information.
    /// </summary>
    [SerializeField] private TMP_Text CollidedObjText;

    /// <summary>
    /// Counter for the number of checkpoints reached.
    /// </summary>
    public int checkPointCounter = 0;

    /// <summary>
    /// Elapsed time for the timer.
    /// </summary>
    float elaspedTime = 0;

    /// <summary>
    /// GameObject representing the rickshaw.
    /// </summary>
    public GameObject rickshaw;

    /// <summary>
    /// GameObject representing the first rickshaw.
    /// </summary>
    public GameObject firstRickshaw;

    /// <summary>
    /// GameObject representing the canvas for the first rickshaw.
    /// </summary>
    public GameObject firstRickshawCanvas;

    /// <summary>
    /// GameObject representing the last rickshaw.
    /// </summary>
    public GameObject LastRickshaw;

    /// <summary>
    /// Flag indicating whether the game is finished.
    /// </summary>
    private bool finishedGame;

    /// <summary>
    /// Flag indicating whether the timer should start.
    /// </summary>
    private bool startTimer;

    /// <summary>
    /// Flag indicating whether the rickshaw game should be played.
    /// </summary>
    public bool playRickShawGame;

    /// <summary>
    /// Array of GameObjects representing checkpoints.
    /// </summary>
    [SerializeField] private GameObject[] checkpointsList;

    public string rickshawTime;

    [SerializeField] private GameObject grandpa;
    ///// <summary>
    ///// Reference to the Firebase Database.
    ///// </summary>
    //public DatabaseReference DbReference;

    ///// <summary>
    ///// The Firebase authentication instance.
    ///// </summary>
    //FirebaseAuth mAuth;

    /// <summary>
    /// Initializes the CheckPointManager.
    /// </summary>
    private void Start()
    {
        finishedGame = false;
        startTimer = false;
        LastRickshaw.SetActive(false);
        firstRickshawCanvas.SetActive(false);
        playRickShawGame = false;
        grandpa.SetActive(false);

        // Deactivate all checkpoints
        for (int i = 0; i < checkpointsList.Count(); i++)
        {
            checkpointsList[i].SetActive(false);
        }
    }

    /// <summary>
    /// Updates the UI based on the current checkpoint counter.
    /// </summary>
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

    /// <summary>
    /// Updates the timer display.
    /// </summary>
    private void Timer()
    {
        elaspedTime += Time.deltaTime;
        int min = Mathf.FloorToInt(elaspedTime / 60);
        int sec = Mathf.FloorToInt(elaspedTime % 60);
        TimerText.text = string.Format("{0:00}:{1:00}", min, sec);
        rickshawTime = string.Format("{0:00}:{1:00}", min, sec);
    }

    //private void UpdateGameData()
    //{
    //    string timing = rickshawTime.ToString();
    //    int checkpoint = 3;
    //    StartCoroutine(GameDataUpdate(timing,checkpoint));
    //}
    //private IEnumerator GameDataUpdate(string time, int point)
    //{

    //    gameData data = new (point,time);
    //    string jsonStats = JsonUtility.ToJson(data);
    //    Task DBTask = DbReference.Child("submissions").Child(mAuth.CurrentUser.UserId).SetRawJsonValueAsync(jsonStats);

    //    yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

    //    if (DBTask.Exception != null)
    //    {
    //        Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
    //    }
    //    else
    //    {
    //    }
    //}
    /// <summary>
    /// Coroutine for finishing the rickshaw game.
    /// </summary>
    /// <returns>IEnumerator</returns>
    IEnumerator rickshawFin()
    {
        CheckPointText.text = "You brought grandma to the port";
        RickshawText.text = "Congrats! Now talk to Grandpa.";
        yield return new WaitForSeconds(3f);

        // Deactivate rickshaw and activate last rickshaw
        rickshaw.SetActive(false);
        LastRickshaw.SetActive(true);
        playRickShawGame = false;
        grandpa.SetActive(true);
        //UpdateGameData();
        yield return new WaitForEndOfFrame();
    }

    /// <summary>
    /// Shows the canvas for the first rickshaw when hovered.
    /// </summary>
    public void hoverFirstRickshaw()
    {
        if (playRickShawGame)
        {
            firstRickshawCanvas.SetActive(true);
        }
    }

    /// <summary>
    /// Hides the canvas for the first rickshaw when unhovered.
    /// </summary>
    public void unhoverFirstRickshaw()
    {
        if (playRickShawGame)
        {
            firstRickshawCanvas.SetActive(false);
        }
    }

    /// <summary>
    /// Checks if the rickshaw game is ready to start. Only starts when player selects the rickshaw.
    /// </summary>
    public void checkRickshawReady()
    {
        if (playRickShawGame)
        {
            // Deactivate first rickshaw and activate checkpoints
            firstRickshaw.SetActive(false);
            rickshaw.SetActive(true);

            for (int i = 0; i < checkpointsList.Count(); i++)
            {
                checkpointsList[i].SetActive(true);
            }
        }
    }

    // /// <summary>
    // /// Adds the name of a collided object to the text display.
    // /// </summary>
    // /// <param name="name">Name of the collided object.</param>
    // public void AddCollidedObjNames(string name)
    // {
    //     CollidedObjText.text += name + '\n';
    // }

    /// <summary>
    /// Signals the completion of the coffeeshop game, allowing the rickshaw game to be played.
    /// </summary>
    public void coffeeGameFinish()
    {
        playRickShawGame = true;
    }

    /// <summary>
    /// Updates are checked every frame.
    /// </summary>
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