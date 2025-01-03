using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public bool canAttack= true;
    private Animator animator;
    public PlayerMove move;
    public GameObject weapon;
    private float timeResetAttack = .75f;
    private float timeHiden = 0.35f;
    private Coroutine coroutine=null;
    public GameObject weaponFire;
    [SerializeField] private float timeDestroy = .7f;

    [SerializeField] private float speedFire = 8f;

    [SerializeField] private GameObject target;
    private GameObject projectile;
    public Transform pointInstance;
    public GameObject hasScore;
    public Dead dead;


    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if(!dead.isDead){
            if(target.activeSelf && animator.GetBool("IsIdle") && canAttack){
                Vector3 direc = target.transform.position-transform.position;
                direc.y = 0;
                Quaternion quaternion = Quaternion.LookRotation(direc);
                transform.rotation= quaternion;
                Attack();
            }
        }
      
    }
    void Attack(){
        move.canMove = false;
        canAttack = false;
        animator.SetBool("IsAttack",true);
        if(coroutine==null){
            coroutine = StartCoroutine(resetAttack());
            StartCoroutine(hideWeapon());
        }
        
        
    }
    IEnumerator hideWeapon(){
        yield return new WaitForSeconds(timeHiden);
        weapon.SetActive(false);
        Instance();
    }
    IEnumerator resetAttack(){
        yield return new WaitForSeconds(timeResetAttack);
        animator.SetBool("IsAttack",false);
        weapon.SetActive(true);
        move.canMove=true;
        canAttack = true;
        coroutine = null;
        weapon.SetActive(true);
    }

    public void Instance()
    {
        Vector3 direction = (target.transform.position - transform.position).normalized;
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        projectile = Instantiate(weaponFire, pointInstance.position, Quaternion.identity);
        projectile.GetComponent<GetScore>().Owner = hasScore;
        
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.useGravity= false;

        if (rb != null)
        {
            rb.velocity = direction * speedFire+new Vector3(0,-0.5f,0);
            //rb.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle+90));
        }
        Destroy(projectile,timeDestroy);
        
    }
}
