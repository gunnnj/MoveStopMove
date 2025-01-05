using UnityEngine;


public class PlayerMove : MoveBase
{
    public VariableJoystick joystick;
    public bool isJoyStick;
    public PlayerAttack attack;
    //public bool canMove = true;
    private Vector3 move;
    public static PlayerMove player;
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
    public override void Move(){

        move = new Vector3(joystick.Direction.x,0f,joystick.Direction.y);

       
        if(move.magnitude>0){
            animator.SetBool("IsIdle",false);
            attack.canAttack = false;

            Vector3 targetDirection = Vector3.RotateTowards(transform.forward, move, rotationSpeed *Time.deltaTime, 0f);
            transform.rotation = Quaternion.LookRotation(targetDirection);


            Vector3 newPos = move + transform.position;
            transform.position = Vector3.Lerp(transform.position,newPos,moveSpeed*Time.deltaTime);

          
        }else{
            animator.SetBool("IsIdle",true);
            attack.canAttack = true;
        }
        
    }

}
