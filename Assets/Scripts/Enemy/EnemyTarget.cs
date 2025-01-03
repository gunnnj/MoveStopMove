using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTarget : MonoBehaviour
{
    public Transform targetPosition=null;
    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player") || other.CompareTag("Enemy")){
            targetPosition = other.GetComponent<Transform>();
        }
        
    }
    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player")|| other.CompareTag("Enemy")){
            targetPosition = null;
        }
    }
}
