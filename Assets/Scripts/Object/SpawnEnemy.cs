using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] enemySpawn;
    public Transform point1;
    public Transform point2;
    public Vector3 pointSpawn;
    [SerializeField]
    public int amountEnemy = 99;
    public int alive = 0;
    public static SpawnEnemy instance;
    private Coroutine coroutine;
    [SerializeField]
    public TextMeshProUGUI txtAlive;
    [SerializeField]
    public float timeToSpawn = 5f;
    void Awake()
    {
        instance=this;
    }
    void Start()
    {
        coroutine = null;
        for(int i =0; i<5; i++){
            Spawn();
        }
    }
    void Update()
    {
        if(coroutine==null && alive<=amountEnemy){
            coroutine = StartCoroutine(StartSpawn());
        }
    }
    [ContextMenu("spawn")]
    public void Spawn(){
        if(amountEnemy<=0){
            return;
        }
        Vector3 pointSpawn = new Vector3(
        Random.Range(point1.position.x, point2.position.x),
        1f,
        Random.Range(point1.position.z, point2.position.z)
        );
        int randomIndex = Random.Range(0,enemySpawn.Count());
        GameObject enemy = Instantiate(enemySpawn[randomIndex],pointSpawn, Quaternion.identity); 
        alive++;
    }

    public IEnumerator StartSpawn(){
        for(int i =0; i<2; i++){
            Spawn();
        }
        yield return new WaitForSeconds(timeToSpawn);
        coroutine = null;
    }
    public void SetNumAlive(){
        txtAlive.text = amountEnemy+1+"";
    }
}
