using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : AttackBase
{
    public bool canAttack= true;
    public MoveBase move;
    [SerializeField] private GameObject target;
    // private Animator animator;
    // public GameObject weapon;
    // public GameObject weaponFire;
    // [SerializeField] private float flightSpeed = 5f;
    // private float hiddenTime = 0.35f;
    // [SerializeField] private float destroyTime = .7f;
    // private float resetAttackTime = .75f;
    // private Coroutine coroutine=null;
    // public Transform pointInstance;
    // public GameObject hasScore;
    // public Dead dead;


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
    public override void Attack(){
        move.canMove = false;
        canAttack = false;
        animator.SetBool("IsAttack",true);
        if(coroutine==null){
            coroutine = StartCoroutine(resetAttack());
            StartCoroutine(hideWeapon());
        }
    }
    public override void Attack(Transform transform)
    {
        return;
    }
    //Ẩn vũ khí
    IEnumerator hideWeapon(){
        yield return new WaitForSeconds(hiddenTime);
        weapon.SetActive(false);
        Instance();
    }
    IEnumerator resetAttack(){
        yield return new WaitForSeconds(resetAttackTime);
        animator.SetBool("IsAttack",false);
        weapon.SetActive(true);
        move.canMove=true;
        canAttack = true;
        coroutine = null;
        weapon.SetActive(true);
    }
    // Spawn vũ khí bắn ra (projectile)
    public override void Instance()
    {
        Vector3 direction = (target.transform.position - transform.position).normalized;
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        projectile = Instantiate(weaponFire, pointInstance.position, Quaternion.identity);
        projectile.GetComponent<GetScore>().Owner = hasScore;
        
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.useGravity= false;

        if (rb != null)
        {
            rb.velocity = direction * flightSpeed+new Vector3(0,-0.5f,0);
            //rb.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle+90));
        }
        Destroy(projectile,destroyTime);
        
    }
}
