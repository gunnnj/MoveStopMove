using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class ButtonClickBuy : MonoBehaviour
{
    private Button btnBuy;
    public Button btnSelect;
    void Start()
    {
        btnBuy = GetComponent<Button>();
        if(btnBuy!=null){
            btnBuy.onClick.AddListener(ListeningButton);
        }
    }
    public void ListeningButton(){
        int indexCategory = UIShopManager.instance.indexButton;
        int index = PlayerPrefs.GetInt("IndexSkinCategory",-1);
        if(indexCategory==0){ BuyHat(index); SwitchBtnBuySelect();}
        if(indexCategory==1){ BuyPant(index);SwitchBtnBuySelect();}
        if(indexCategory==2){ BuyShield(index);SwitchBtnBuySelect();}
        if(indexCategory==3){ BuyFullset(index);SwitchBtnBuySelect();}

    }
    public void BuyHat(int index){

        Unlock(index);
        if(index>=0){
            UIShopManager.instance.listHatSO.hatSOs[index].wasBought = true;
            UIShopManager.instance.OnClickHat();
            int gold = PlayerPrefs.GetInt("Gold",0);
            gold = gold - UIShopManager.instance.listHatSO.hatSOs[index].priceHat;
            PlayerPrefs.SetInt("Gold",gold);
            PlayerPrefs.Save();
            GoldManage.instance.UpdateGold();
        }

    }
    public void BuyPant(int index){

        Unlock(index);
        if(index>=0){
            UIShopManager.instance.listPantSO.listPant[index].wasBought = true;
            UIShopManager.instance.OnClickPant();
            int gold = PlayerPrefs.GetInt("Gold",0);
            gold = gold - UIShopManager.instance.listPantSO.listPant[index].Price;
            PlayerPrefs.SetInt("Gold",gold);
            PlayerPrefs.Save();
            GoldManage.instance.UpdateGold();
        }

    }
    public void BuyShield(int index){

        Unlock(index);
        if(index>=0){
            UIShopManager.instance.listShieldSO.shieldSos[index].wasBought = true;
            UIShopManager.instance.OnClickShield();
            int gold = PlayerPrefs.GetInt("Gold",0);
            gold = gold - UIShopManager.instance.listShieldSO.shieldSos[index].priceShield;
            PlayerPrefs.SetInt("Gold",gold);
            PlayerPrefs.Save();
            GoldManage.instance.UpdateGold();
        }

    }
    public void BuyFullset(int index){

        Unlock(index);
        if(index>=0){
            UIShopManager.instance.shopFullset.listFullsetSO.fullsetSOs[index].wasBought = true;
            UIShopManager.instance.OnClickFullset();
            int gold = PlayerPrefs.GetInt("Gold",0);
            gold = gold - UIShopManager.instance.shopFullset.listFullsetSO.fullsetSOs[index].priceFullset;
            PlayerPrefs.SetInt("Gold",gold);
            PlayerPrefs.Save();
            GoldManage.instance.UpdateGold();
        }

    }

    public void SwitchBtnBuySelect(){
        btnBuy.gameObject.SetActive(false);
        btnSelect.gameObject.SetActive(true);
    }

    public void Unlock(int idx){
        if(idx>=0){
            UIShopManager.instance.listBtnSkin[idx].transform.GetChild(1).gameObject.SetActive(false);
        }
    }
}
