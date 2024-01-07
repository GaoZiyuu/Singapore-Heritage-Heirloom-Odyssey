/* Author: Gao Ziyu
 * Date: 01/01/2024
 * Description: Script for food interactions in LPS (not in use)
 */
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FoodInteraction : MonoBehaviour
{
    /// <summary>
    /// variables
    /// </summary>
    public int score;
    public TextMeshProUGUI scoreText;

    public GameObject food1;
    public GameObject food2;

    bool food1Collected = false;
    bool food2Collected = false;

    /// <summary>
    /// when on trigger score +1 & destroy
    /// </summary>
    /// <param name="other"></param>
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
