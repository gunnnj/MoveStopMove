using UnityEngine;

public class Dead : MonoBehaviour
{
    public Animator animator;
    public GameObject go;
    public bool isDead=false;
    public void dead(){
        isDead = true;
        animator.SetBool("IsDead",true);
        if(SpawnEnemy.instance.amountEnemy>0){
            SpawnEnemy.instance.amountEnemy-=1;
            SpawnEnemy.instance.alive-=1;
            SpawnEnemy.instance.SetNumAlive();
            Debug.Log(SpawnEnemy.instance.amountEnemy);
        }
        Destroy(go,1f);
    }

}
