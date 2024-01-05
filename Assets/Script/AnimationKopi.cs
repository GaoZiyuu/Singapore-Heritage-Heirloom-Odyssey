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
            conMilk.SetBool("Pour", true);
            other.transform.SetParent(teaSet);
            condenseMilk.SetActive(true);
            StartCoroutine(hideCondenseMilk());
        }

        if(other.gameObject.tag == "doneKopi")
        {
            doneKopi.SetActive(true);
            pourKopi.SetBool("donePour", true);
            other.transform.SetParent(teaSet);
            kopi.SetActive(true);
            StartCoroutine(hideKopi());
        }
    }

    IEnumerator hideCondenseMilk()
    {
        yield return new WaitForSeconds(2);
        conMilky.SetActive(false);
    }

    IEnumerator hideKopi()
    {
        yield return new WaitForSeconds(2);
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
