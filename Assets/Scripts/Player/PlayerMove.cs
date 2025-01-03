using UnityEngine;


public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 10f;
    public VariableJoystick joystick;
    public bool isJoyStick;
    private Animator animator;
    public PlayerAttack attack;
    public bool canMove = true;
    public Vector3 move;
    public static PlayerMove player;
    public Camera mainCamera;
    public Dead dead;

    void Start()
    {
        animator = GetComponent<Animator>();
        player = this;
    }
    void Update()
    {
        if(!dead.isDead){
            Move();
        }
    }
    void Move(){

        move = new Vector3(joystick.Direction.x,0f,joystick.Direction.y);

       
        if(move.magnitude>0){
            animator.SetBool("IsIdle",false);
            attack.canAttack = false;

            Vector3 targetDirection = Vector3.RotateTowards(transform.forward, move, 10f*Time.deltaTime, 0f);
            transform.rotation = Quaternion.LookRotation(targetDirection);


            Vector3 newPos = move + transform.position;
            transform.position = Vector3.Lerp(transform.position,newPos,moveSpeed*Time.deltaTime);

          
        }else{
            animator.SetBool("IsIdle",true);
            attack.canAttack = true;
        }
        
    }

}
