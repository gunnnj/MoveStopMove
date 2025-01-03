using UnityEngine;

public class GetScore: MonoBehaviour
{
    public GameObject Owner;
    public ScaleRangeAttack scale;
    private float maxScore = 500f;
    public int countLV;
    void Start()
    {
        scale = Owner.GetComponent<ScaleRangeAttack>();
        countLV = scale.tagLV;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy") || other.CompareTag("Player")){
            float score = other.GetComponent<Score>().score;
            other.GetComponent<Score>().score = 0;
            other.GetComponent<Dead>().dead();
            if(Owner!=null && Owner.GetComponent<Score>().score<maxScore){
                CompareScore(Owner.GetComponent<Score>().score+=score);
            }  
            Destroy(gameObject); 
        }
        
    }

    void CompareScore(float score){
        if(score >4 && countLV==1){
            scale.LevelUp();
            countLV++;
        }
        else if(score>9 && countLV==2){
            scale.LevelUp();
            countLV++;
        }
        else if(score>29 && countLV==3){
            scale.LevelUp();
            countLV++;
        }
        else if(score>59 && countLV==4){
            scale.LevelUp();
            countLV++;
        }
    }
}