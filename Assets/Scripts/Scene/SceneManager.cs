using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    public GameObject player;
    public GameObject spawnEnemy;
    public void OnClickShopWp(){
        SceneManager.LoadScene("Shop");
    }
    public void OnClickPlay(){
        player.GetComponent<PlayerMove>().enabled = true;
        spawnEnemy.SetActive(true);
    }
}
