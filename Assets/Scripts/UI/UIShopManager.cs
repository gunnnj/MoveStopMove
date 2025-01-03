using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIShopManager : MonoBehaviour
{
    public Button[] btnSelectShops;

    void Start()
    {
        foreach (Button button in btnSelectShops)
        {
            button.onClick.AddListener(() => OnButtonClick(button));
        }
    }
    public void OnClickWithWWithIndex(int index){

    }
    public void OnButtonClick(Button button){

    }
}
