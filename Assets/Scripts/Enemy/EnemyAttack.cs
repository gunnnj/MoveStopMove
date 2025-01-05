using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : AttackBase
{
    public MoveBase move;
    public EnemyTarget enemyTarget;
    private float rotationSpeed = 10f;
    private Vector3 direc;
    // private Animator animator;
    // public GameObject weapon;
    // public GameObject weaponFire;
    // public float flightSpeed = 5f;
    // private float timeHiden = 0.35f;
    // public float destroyTime = 0.7f;
    // private float timeResetAttack=1.25f;
    // private Coroutine coroutine;
    // public Transform pointInstance;
    // public GameObject hasScore;
    // public Dead dead;
    
    
    void Start()
    {
        move = GetComponent<EnemyMove>();
        animator = GetComponent<Animator>();
        weapon.SetActive(true);
    }


    void Update()
    {
        if(dead.isDead){
            move.canMove = false;
        }
        else{
            if(enemyTarget.targetPosition!=null){
                move.canMove = false;
                Attack(enemyTarget.targetPosition);
            }
        }
        
    }
    public override void Attack()
    {
        return; // không làm gì
    }
    public override void Attack(Transform trans){
        animator.SetBool("IsAttack",true);
        //Quay về hướng đánh
        direc = (trans.position - transform.position).normalized;
        if (direc != Vector3.zero) 
        {
            Quaternion lookRotation = Quaternion.LookRotation(direc);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
        }
        if(coroutine==null){
            coroutine = StartCoroutine(resetAttack());
            StartCoroutine(hideWeapon());
        }        
    }
    IEnumerator resetAttack(){
        yield return new WaitForSeconds(resetAttackTime);
        animator.SetBool("IsAttack",false);
        coroutine = null;
        weapon.SetActive(true);
        move.canMove=true;
    }
    IEnumerator hideWeapon(){
        yield return new WaitForSeconds(hiddenTime);
        weapon.SetActive(false);
        Instance();
        
    }
    public override void Instance(){
        //GameObject projectile = Instantiate(weaponFire, new Vector3(transform.position .x,1.7f,transform.position.z), Quaternion.identity);
        projectile = Instantiate(weaponFire, pointInstance.position, Quaternion.identity);
        projectile.GetComponent<GetScore>().Owner = hasScore;

        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        Transform trans = projectile.GetComponent<Transform>();
        trans.rotation = Quaternion.Euler(90,trans.rotation.y,trans.rotation.z);
        if (rb != null)
        {
            rb.velocity = direc * flightSpeed;

        }
        Destroy(projectile,destroyTime);
    }
}
