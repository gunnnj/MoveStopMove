using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OnClickSkin : MonoBehaviour
{
    public ListPantSO listPantSO;
    public UIShopManager uIShop;
    public ShopFullset shopFullset;
    public int index = 0;
    public GameObject btnBuy;
    public GameObject iconLock;
    public TextMeshProUGUI txtBuy;
    public GameObject btnSelect;
    public ButtonClickBuy buttonClickBuy;

    
    void Start()
    {
        btnBuy.SetActive(false);
        btnSelect.SetActive(false);

    }
    //Khi ấn nút chọn skin
    public void OnClick(){
        if(uIShop.indexButton==0){
            OnClickHat();
            btnBuy.SetActive(true);
        }
        if(uIShop.indexButton==1){
            OnClickPant();
        }
        if(uIShop.indexButton==2){
            OnClickShield();
        }
        if(uIShop.indexButton==3){
            OnClickFullset();
        }
        
    }
    public void OnClickHat(){
        foreach(var go in uIShop.HatGO){
            go.SetActive(false);
        }
        uIShop.HatGO[index].SetActive(true);
        shopFullset.fullsetSO.wasEquipped = false;
        //Lưu chỉ số của mũ
        PlayerPrefs.SetInt("IndexHatGO",index);
        PlayerPrefs.Save();
    }
    public void OnClickPant(){
        listPantSO.indexPant = index;
        GetMaterialPant.instance.GetMaterial();
        shopFullset.fullsetSO.wasEquipped = false;
    }
    public void OnClickShield(){
        foreach(var go in uIShop.ShieldGO){
            go.SetActive(false);
        }
        uIShop.ShieldGO[index].SetActive(true);
        shopFullset.fullsetSO.wasEquipped = false;
        //Lưu chỉ số của khiên
        PlayerPrefs.SetInt("IndexShieldGO",index);
        PlayerPrefs.Save();
    }
    public void OnClickFullset(){
        uIShop.HideHatGO();
        shopFullset.fullsetSO.currentFullset = index;
        shopFullset.fullsetSO.wasEquipped = true;
        //Spawn phụ kiện theo fullset
        shopFullset.SpawnAccessory();
    }

    public void HandleButtonBuyClick(){
        Debug.Log("Bấm mua ở skin hat");
    }
}
