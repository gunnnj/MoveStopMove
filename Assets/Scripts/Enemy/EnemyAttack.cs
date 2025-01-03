using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private Animator animator;
    public EnemyMove move;
    public EnemyTarget enemyTarget;
    private Coroutine coroutine;
    private float rotationSpeed = 10f;
    public GameObject weapon;
    public GameObject weaponFire;
    [SerializeField]
    private float speedFire = 5f;
    private float timeResetAttack=1.25f;
    private float timeHiden = 0.35f;
    [SerializeField] public float rangeAttack=5f;
    private Vector3 direc;
    public Transform pointInstance;
    public GameObject hasScore;
    public Dead dead;
    void Start()
    {
        move = GetComponent<EnemyMove>();
        animator = GetComponent<Animator>();
        weapon.SetActive(true);
    }


    void Update()
    {
        if(dead.isDead){
            move.isStop = true;
        }
        else{
            if(enemyTarget.targetPosition!=null){
                move.isStop = true;
                Attack(enemyTarget.targetPosition);
            }
        }
        
    }
    void Attack(Transform trans){
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
        yield return new WaitForSeconds(timeResetAttack);
        animator.SetBool("IsAttack",false);
        coroutine = null;
        weapon.SetActive(true);
        move.isStop=false;
    }
    IEnumerator hideWeapon(){
        yield return new WaitForSeconds(timeHiden);
        weapon.SetActive(false);
        Instance();
        
    }
    void Instance(){
        //GameObject projectile = Instantiate(weaponFire, new Vector3(transform.position .x,1.7f,transform.position.z), Quaternion.identity);
        GameObject projectile = Instantiate(weaponFire, pointInstance.position, Quaternion.identity);
        projectile.GetComponent<GetScore>().Owner = hasScore;

        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        Transform trans = projectile.GetComponent<Transform>();
        trans.rotation = Quaternion.Euler(90,trans.rotation.y,trans.rotation.z);
        if (rb != null)
        {
            rb.velocity = direc * speedFire;

        }
        Destroy(projectile,.7f);
    }
}
