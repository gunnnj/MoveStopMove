using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChooseManage : MonoBehaviour
{
    public ListWpSO listWpSO;
    public static ChooseManage instance;

    void Start()
    {
        instance = this;
    }

    public void OnClickBuy(){
        int indexWp  = SelectWeapon.instance.currentWp;
        int price = SelectWeapon.instance.weaponSOs[indexWp].priceWp;
        GoldManage.instance.gold -= price;
        SelectWeapon.instance.weaponSOs[indexWp].wasBoughtWp = true;
        SelectWeapon.instance.SwitchBtn();
        SelectWeapon.instance.SwitchUI();
    }
    public void OnClickSelect(){
        int indexWp  = SelectWeapon.instance.currentWp;
        listWpSO.indexCurrentWp = indexWp;
        if(SelectWeapon.instance.txtBtnSelect.text.Equals("Select")){
            SelectWeapon.instance.txtBtnSelect.text="Equipped";
        }
        else{
            SelectWeapon.instance.txtBtnSelect.text="Select";
        }
    }

    public void OnClickClose(){
        SceneManager.LoadScene("ScenePlay");
    }
}
