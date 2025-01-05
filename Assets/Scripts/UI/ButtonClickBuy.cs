using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class ButtonClickBuy : MonoBehaviour
{
    private Button btnBuy;
    void Start()
    {
        btnBuy = GetComponent<Button>();
        if(btnBuy!=null){
            
        }
        

    }
    public void ListeningButton(){
        Debug.Log("Đã mua");
    }
    
}
