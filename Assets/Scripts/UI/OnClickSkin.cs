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
            btnSelect.SetActive(false);
        }
        if(uIShop.indexButton==1){
            OnClickPant();
            btnBuy.SetActive(true);
            btnSelect.SetActive(false);
        }
        if(uIShop.indexButton==2){
            OnClickShield();
            btnBuy.SetActive(true);
            btnSelect.SetActive(false);
        }
        if(uIShop.indexButton==3){
            OnClickFullset();
            btnBuy.SetActive(true);
            btnSelect.SetActive(false);
        }
  
        PlayerPrefs.SetInt("IndexSkinCategory",index);
        PlayerPrefs.Save();
        
    }
    public void OnClickHat(){
        foreach(var go in uIShop.HatGO){
            go.SetActive(false);
        }
        uIShop.HatGO[index].SetActive(true);
        shopFullset.listFullsetSO.wasEquipped = false;
        txtBuy.text = UIShopManager.instance.listHatSO.hatSOs[index].priceHat+"";
        // //Lưu chỉ số của mũ
        // PlayerPrefs.SetInt("IndexHatGO",index);
        // PlayerPrefs.Save();
    }
    public void OnClickPant(){
        listPantSO.indexPant = index;
        GetMaterialPant.instance.GetMaterial();
        shopFullset.listFullsetSO.wasEquipped = false;
        txtBuy.text = UIShopManager.instance.listPantSO.listPant[index].Price+"";
    }
    public void OnClickShield(){
        foreach(var go in uIShop.ShieldGO){
            go.SetActive(false);
        }
        uIShop.ShieldGO[index].SetActive(true);
        shopFullset.listFullsetSO.wasEquipped = false;
        txtBuy.text = UIShopManager.instance.listShieldSO.shieldSos[index].priceShield+"";
        // //Lưu chỉ số của khiên
        // PlayerPrefs.SetInt("IndexShieldGO",index);
        // PlayerPrefs.Save();
    }
    public void OnClickFullset(){
        uIShop.HideHatGO();
        shopFullset.listFullsetSO.currentFullset = index;
        shopFullset.listFullsetSO.wasEquipped = true;
        txtBuy.text = UIShopManager.instance.shopFullset.listFullsetSO.fullsetSOs[index].priceFullset+"";
        //Spawn phụ kiện theo fullset
        shopFullset.SpawnAccessory();
    }
}
