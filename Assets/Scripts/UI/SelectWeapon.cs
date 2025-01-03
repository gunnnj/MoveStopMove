using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectWeapon : MonoBehaviour
{
    public WeaponSO[] weaponSOs;
    public int currentWp = 0;
    public GameObject UISkin;
    public GameObject btnBuy;
    public GameObject btnSelect;
    public TextMeshProUGUI txtBtnBuy;
    public TextMeshProUGUI txtBtnSelect;

    public static SelectWeapon instance;

    void Start()
    {
        instance = this;
        SwitchUI();
        SwitchBtn();
    }
   
    public void OnClickNext(){
        CustomSkin.instance.SaveMaterial(); //Lưu material vũ khí trc
        if(currentWp==weaponSOs.Count()-1){
            currentWp=0;
        }
        else{
            currentWp++;
        }
        SwitchUI();
        SwitchWp();
        SwitchBtn();
        ResetBtnSelect();
        
    }

    public void OnClickPrev(){
        CustomSkin.instance.SaveMaterial(); //Lưu material vũ khí sau
        if(currentWp==0){
            currentWp=weaponSOs.Count()-1;
        }
        else{
            currentWp--;
        }
        SwitchUI();
        SwitchWp();
        SwitchBtn();
        ResetBtnSelect();
    }
    //Chuyển đổi vũ khí
    public void SwitchWp(){
        SelectSkin.instance.ChangeWeapon();
        SelectSkin.instance.ChangeWpGO(currentWp);
        CustomSkin.instance.ScaleBtnByAmout();
        
    }

    public void HidenUISkin(){
        UISkin.SetActive(false);
    }

    public void DisplayUISkin(){
        UISkin.SetActive(true);
    }
    //Ẩn hiện UI skin
    public void SwitchUI(){
        if(weaponSOs[currentWp].wasBoughtWp){
            DisplayUISkin();
        }
        else{
            HidenUISkin();
        }
    }

    //Chuyển đổi Nút mua và trang bị (select->equipped)
    public void SwitchBtn(){
        if(!weaponSOs[currentWp].wasBoughtWp){
            btnBuy.SetActive(true);
            //Set giá vk
            txtBtnBuy.text = weaponSOs[currentWp].priceWp+"";
            btnSelect.SetActive(false);
        }
        else{
            btnSelect.SetActive(true);
            btnBuy.SetActive(false);
        }
    }
    
    public void ResetBtnSelect(){
        txtBtnSelect.text = "Select";
        if(ChooseManage.instance.listWpSO.indexCurrentWp==currentWp){
            txtBtnSelect.text = "Equipped";
        }
    }

}
