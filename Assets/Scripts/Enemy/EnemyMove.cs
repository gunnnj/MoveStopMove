using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float minDistance = 1f; 
    public float maxDistance = 10f; 
    public bool isStop = false; 
    public float moveSpeed = 5f; 
    private Vector3 targetPosition;
    private float rotationSpeed = 10f;
    private Animator animator;
    private float looptime = 1.5f;
    private bool redirec = true;
    void Start()
    {
        SetRandomTargetPosition();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(!isStop){
            MoveTowardsTarget();
           
            if (Vector3.Distance(transform.position, targetPosition) < 1f || redirec)
            {
                StartCoroutine(Redirec());
            }
        }
        
    }

    public IEnumerator Redirec(){
        transform.position = transform.position;
        redirec = false;
        // looptime = Random.Range(4f,8f);
        yield return new WaitForSeconds(looptime);
        SetRandomTargetPosition(); 
        redirec = true;
    }

    void SetRandomTargetPosition()
    {

        float randomAngle = Random.Range(0f, 360f);
        float randomDistance = Random.Range(minDistance, maxDistance);
        
        // Tính toán tọa độ mục tiêu
        targetPosition = new Vector3(
            transform.position.x + randomDistance * Mathf.Cos(randomAngle * Mathf.Deg2Rad),
            transform.position.y,
            transform.position.z + randomDistance * Mathf.Sin(randomAngle * Mathf.Deg2Rad)
        );
    }

    void MoveTowardsTarget()
    {
        animator.SetBool("IsIdle",false);
        Vector3 direction = (targetPosition - transform.position).normalized;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        if (direction != Vector3.zero) 
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        // if(other.CompareTag("Weapon")){
        //     Destroy(gameObject);
        // }
    }
}