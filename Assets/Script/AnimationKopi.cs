using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationKopi : MonoBehaviour
{
    public Animator conMilk;
    public Transform teaSet;

    public Animator pourKopi;

    public GameObject conMilky;
    public GameObject doneKopi;
    public GameObject condenseMilk;
    public GameObject kopi;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "condenseMilk")
        {
            conMilky.SetActive(true);
            //conMilk.SetBool("Pour", true);
            other.transform.SetParent(teaSet);
            StartCoroutine(hideCondenseMilk());
            condenseMilk.SetActive(true);
        }

        if (other.gameObject.tag == "doneKopi")
        {
            doneKopi.SetActive(true);
            //pourKopi.SetBool("donePour", true);
            other.transform.SetParent(teaSet);
            StartCoroutine(hideKopi());
            kopi.SetActive(true);
        }
    }

    IEnumerator hideCondenseMilk()
    {
        conMilk.SetBool("Pour", true);
        yield return new WaitForSeconds(3);
        conMilky.SetActive(false);
    }

    IEnumerator hideKopi()
    {
        pourKopi.SetBool("donePour", true);
        yield return new WaitForSeconds(3);
        doneKopi.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
