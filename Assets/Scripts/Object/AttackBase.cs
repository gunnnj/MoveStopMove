using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackBase : MonoBehaviour
{
    protected Animator animator;
    public GameObject weapon;
    public GameObject weaponFire;
    [SerializeField] protected float flightSpeed;
    [SerializeField] protected float hiddenTime = 0.35f;
    [SerializeField] protected float destroyTime = 0.7f;
    [SerializeField] protected float resetAttackTime = 0.75f;
    protected GameObject projectile;
    public Coroutine coroutine;
    public Transform pointInstance;
    public GameObject hasScore;
    public Dead dead;
    //public SphereCollider rangeAttack;
    public abstract void Attack();
    public abstract void Attack(Transform transform);
    public abstract void Instance();

}
