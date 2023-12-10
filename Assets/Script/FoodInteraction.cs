using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FoodInteraction : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreText;

    public GameObject food1;
    public GameObject food2;

    bool food1Collected = false;
    bool food2Collected = false;

    public void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == "bakuteh")
        {
            food1Collected = true;
            score += 1;
            scoreText.text = "Score: " + score;
            Destroy(gameObject);
        }
        if (gameObject.tag == "chickenrice")
        {
            food2Collected = true;
            score += 1;
            scoreText.text = "Score: " + score;
            Destroy(gameObject);
        }
    }
}
