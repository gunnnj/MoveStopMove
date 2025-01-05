using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MoveBase : MonoBehaviour
{
    [SerializeField] protected float moveSpeed; 
    protected Animator animator;
    protected float rotationSpeed = 10f;
    public bool canMove = true; 
    public abstract void Move();

}
