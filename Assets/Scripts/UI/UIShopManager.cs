using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIShopManager : MonoBehaviour
{
    public Button[] btnSelectShops;
    public GameObject buttonPrefab;
    public ListPantSO listPantSO;
    public ListHatSO listHatSO;
    public ListShieldSO listShieldSO;
    public GameObject[] HatGO;
    public GameObject[] ShieldGO;
    public GameObject UIShop;
    public GameObject UIBtn;
    public GameObject player;
    public int indexButton = 0;
    public ShopFullset shopFullset;
    public Button[] listBtnSkin;
    public List<GameObject> listBtn;
    public static UIShopManager instance;
    void Start()
    {
        instance = this;
        listBtn = new List<GameObject>();
        //SetItemStart();
        //OnClickHat();
    }
    public void SetItemStart(){
        if(shopFullset.listFullsetSO.wasEquipped){return;}
        int indexHat = PlayerPrefs.GetInt("IndexHatGO",-1);
        int indexShield = PlayerPrefs.GetInt("IndexShieldGO",-1);
        if(indexHat>=0){
            HatGO[indexHat].SetActive(true);
        }
        if(indexShield>=0){
            ShieldGO[indexShield].SetActive(true);
        }
    }
    public void OnClickHat(){

        indexButton = 0;
        shopFullset.ResetMaterialAndAccessory();

        int amoutHat = listHatSO.hatSOs.Count();

        for(int i=0; i<listBtnSkin.Count(); i++){
            if(i<=amoutHat){
                listBtnSkin[i].gameObject.SetActive(true);
                listBtnSkin[i].GetComponent<Image>().sprite = listHatSO.hatSOs[i].imgHatGO;
                listBtnSkin[i].GetComponent<OnClickSkin>().index = i;

                if(listHatSO.hatSOs[i].wasBought){
                    listBtnSkin[i].transform.GetChild(1).gameObject.SetActive(false);
                }
                else{
                    listBtnSkin[i].transform.GetChild(1).gameObject.SetActive(true);
                }

                
            }
            else{
                listBtnSkin[i].gameObject.SetActive(false);
            }
        }  
        
    }
    public void OnClickPant(){
        indexButton = 1;
        shopFullset.ResetMaterialAndAccessory();  //Reset lại ban đầu

        int amoutPant = listPantSO.listPant.Count();

        for(int i=0; i<listBtnSkin.Count(); i++){
            if(i<amoutPant){
                listBtnSkin[i].gameObject.SetActive(true);
                listBtnSkin[i].GetComponent<Image>().sprite = listPantSO.listPant[i].imgSprite;
                listBtnSkin[i].GetComponent<OnClickSkin>().index = i;

                if(listPantSO.listPant[i].wasBought){
                    listBtnSkin[i].transform.GetChild(1).gameObject.SetActive(false);
                }
                else{
                    listBtnSkin[i].transform.GetChild(1).gameObject.SetActive(true);
                }
            }
            else{
                listBtnSkin[i].gameObject.SetActive(false);
            }
        }

    }

    public void OnClickShield(){
        indexButton = 2;
        shopFullset.ResetMaterialAndAccessory();

        int amoutShield = listShieldSO.shieldSos.Count();

        for(int i=0; i<listBtnSkin.Count(); i++){
            if(i<amoutShield){
                listBtnSkin[i].gameObject.SetActive(true);
                listBtnSkin[i].GetComponent<Image>().sprite = listShieldSO.shieldSos[i].imgShieldSO;
                listBtnSkin[i].GetComponent<OnClickSkin>().index = i;

                if(listPantSO.listPant[i].wasBought){
                    listBtnSkin[i].transform.GetChild(1).gameObject.SetActive(false);
                }
                else{
                    listBtnSkin[i].transform.GetChild(1).gameObject.SetActive(true);
                }
            }
            else{
                listBtnSkin[i].gameObject.SetActive(false);
            }
        }

    }
    public void OnClickFullset(){

        indexButton = 3;

        int amoutFullset = shopFullset.listFullsetSO.fullsetSOs.Count(); // lấy số lượng full set

        for(int i=0; i<listBtnSkin.Count(); i++){
            if(i<amoutFullset){
                listBtnSkin[i].gameObject.SetActive(true);
                listBtnSkin[i].GetComponent<Image>().sprite = shopFullset.listFullsetSO.fullsetSOs[i].imgFullset;
                listBtnSkin[i].GetComponent<OnClickSkin>().index = i;

                if(shopFullset.listFullsetSO.fullsetSOs[i].wasBought){
                    listBtnSkin[i].transform.GetChild(1).gameObject.SetActive(false);
                }
                else{
                    listBtnSkin[i].transform.GetChild(1).gameObject.SetActive(true);
                }
                
            }
            else{
                listBtnSkin[i].gameObject.SetActive(false);
            }
        }
 

    }

    //Khi ấn nút skin
    public void OnClickUISKin(){
        if(shopFullset.listFullsetSO.wasEquipped){
            OnClickFullset();
        }
        else{
            OnClickHat();
        }
        UIShop.SetActive(true);
        UIBtn.SetActive(false);
        PlayerDance();
    }
    // Ấn tắt shop
    public void OnClickClose(){
        UIShop.SetActive(false);
        UIBtn.SetActive(true);
        NoDance();
    }
    //Ẩn mũ đi
    public void HideHatGO(){
        foreach(var item in HatGO){
            item.SetActive(false);
        }
    }

    public void PlayerDance(){
        player.GetComponent<Animator>().SetBool("IsDance", true);
    }
    public void NoDance(){
        player.GetComponent<Animator>().SetBool("IsDance", false);
    }
}
