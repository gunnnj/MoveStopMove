using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackBase : MonoBehaviour
{
    public Animator animator;
    public MoveBase move;
    public GameObject weapon;
    public GameObject weaponFire;
    public float flightSpeed;
    public float hiddenTime = 0.35f;
    public float destroyTime;
    public float resetAttackTime = 0.75f;
    public Coroutine coroutine;
    public SphereCollider rangeAttack;

    protected void StartAttack(){
        if(coroutine == null){
            coroutine = StartCoroutine(ResetAttack());
            StartCoroutine(HiddenWeapon());
        }
    }
    protected IEnumerator HiddenWeapon(){
        yield return new WaitForSeconds(hiddenTime);
        weapon.SetActive(false);
        Instance();
    }
    protected IEnumerator ResetAttack(){
        yield return new WaitForSeconds(resetAttackTime);
        animator.SetBool("IsAttack",false);
        weapon.SetActive(true);
        coroutine = null;
    }
    public abstract void Instance();

}
