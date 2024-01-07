/* Author: Leong YenZhen
 * Date: 22/12/2023
 * Description: Script to make the boat move
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoving : MonoBehaviour
{
    /// <summary>
    /// bool to check if the boat can move
    /// </summary>
    public bool canMove;

    /// <summary>
    /// boat var
    /// </summary>
    [SerializeField] float speed;
    [SerializeField] int StartPoint;
    [SerializeField] Transform[] points;

    /// <summary>
    /// variables
    /// </summary>
    int i;
    bool reverse;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = points[StartPoint].position;
        i = StartPoint;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, points[i].position) < 0.01f)
        {
            canMove = false;

            if(i == points.Length - 1)
            {
                reverse = true;
                i--;
                return;
            }
            else if(i == 0)
            {
                reverse = true;
                i++;
                return;
            }

            if (reverse)
            {
                i--;
            }
            else
            {
                i++;
            }

        }

        if (canMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
        }
    }
}
