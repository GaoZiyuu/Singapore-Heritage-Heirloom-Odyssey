/* Author: Pang Lexin
 * Date: 05/01/2024
 * Description: Script to push game data to firebase db
 */
using System.Collections;
using System.Collections.Generic;
using Firebase.Database;
using Firebase;
using Firebase.Auth;
using System.Threading.Tasks;
using UnityEngine;
using System.Data;

public class GameDataPush : MonoBehaviour
{
    /// <summary>
    /// Reference to the Firebase Database.
    /// </summary>
    public DatabaseReference DbReference;

    /// <summary>
    /// The Firebase authentication instance.
    /// </summary>
    FirebaseAuth mAuth;

    [SerializeField] private GameObject myCheckpointManager;

    /// <summary>
    /// update data
    /// </summary>
    /// <param name="time"></param>
    /// <param name="point"></param>
    private void UpdateGameData(string time,int point)
    {
        string timing = time.ToString();
        int checkpoint = point;
        StartCoroutine(GameDataUpdate(timing, checkpoint));
    }

    /// <summary>
    /// when to push data
    /// </summary>
    /// <param name="time"></param>
    /// <param name="point"></param>
    /// <returns></returns>
    private IEnumerator GameDataUpdate(string time, int point)
    {

        gameData data = new(point, time);
        string jsonStats = JsonUtility.ToJson(data);
        Task DBTask = DbReference.Child("submissions").Child(mAuth.CurrentUser.UserId).SetRawJsonValueAsync(jsonStats);

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
        }
    }

    /// <summary>
    /// chekcpoint for task1
    /// </summary>
    public void Relic1Btn()
    {
        string time = "Have't started mini game";
        int point = 1;
        UpdateGameData(time,point);
    }

    /// <summary>
    /// checkpoint for task2
    /// </summary>
    public void Relic2Btn()
    {
        string time = "Have't started mini game";
        int point = 2;
        UpdateGameData(time, point);
    }

    /// <summary>
    /// checkpoint for task3
    /// </summary>
    public void Relic3Btn()
    {
        string time = myCheckpointManager.GetComponent<CheckPointManager>().rickshawTime.ToString();
        int point = 3;
        UpdateGameData(time, point);
    }
}
