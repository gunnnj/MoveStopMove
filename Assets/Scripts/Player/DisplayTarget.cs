using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayTarget : MonoBehaviour
{
    public GameObject circleTarget;
    private Collider current;
    void Start()
    {
        circleTarget.SetActive(false);
        current = null;
    }

    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Enemy")){
            current = other;
            circleTarget.transform.position = new Vector3(other.transform.position.x,2f,other.transform.position.z);
            circleTarget.SetActive(true);
        }
        
    }
    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Enemy")){
            current = null;
            circleTarget.SetActive(false);
        }
    }
    void Update()
    {
        if (current == null )
        {
            circleTarget.SetActive(false); 

        }
    }
}
