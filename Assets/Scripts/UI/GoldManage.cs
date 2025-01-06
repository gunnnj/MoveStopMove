using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldManage : MonoBehaviour
{   
    public int gold = 1000;
    public TextMeshProUGUI txtGold;
    public static GoldManage instance;

    public void Start()
    {       
        instance = this;
        PlayerPrefs.SetInt("Gold",gold);
        PlayerPrefs.Save();
        UpdateGold();
    }
    public void UpdateGold(){
        int Gold = PlayerPrefs.GetInt("Gold",gold);
        Debug.Log(Gold);
        txtGold.text = Gold + "";
    }
}
