using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MoveBase
{
    [SerializeField] private float minDistance = 1f; 
    [SerializeField] private float maxDistance = 10f; 
    //public bool canMove = true; 
    private Vector3 targetPosition;
    private float looptime = 1.5f;
    private bool redirec = true;
    void Start()
    {
        SetRandomTargetPosition();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(canMove){
            Move();
            //Điều kiện chuyển hướng của enemy
            if (Vector3.Distance(transform.position, targetPosition) < 1f || redirec)
            {
                StartCoroutine(Redirec());
            }
        }
        
    }
    //Chuyển hướng mục tiêu di chuyển
    public IEnumerator Redirec(){
        transform.position = transform.position;
        redirec = false;
        // looptime = Random.Range(4f,8f);
        yield return new WaitForSeconds(looptime);
        SetRandomTargetPosition(); 
        redirec = true;
    }
    //Random mục tiêu di chuyển
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

    public override void Move()
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
}
