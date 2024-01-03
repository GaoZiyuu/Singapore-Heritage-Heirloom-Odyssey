using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationKopi : MonoBehaviour
{
    public Animator conMilk;
    public Transform teaSet;

    public GameObject condenseMilk;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "condenseMilk")
        {
            conMilk.SetBool("Pour", true);
            other.transform.SetParent(teaSet);
            condenseMilk.SetActive(true);
            Destroy(gameObject);
        }
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
