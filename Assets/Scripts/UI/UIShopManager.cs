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
    public GameObject UIShop;
    public GameObject UIBtn;
    public GameObject player;
    public GameObject[] HatGO;
    public Sprite[] spriteHat;
    public GameObject[] ShieldGO;
    public Sprite[] spriteShield;
    public int indexButton = 0;
    public ShopFullset shopFullset;
    private List<GameObject> listBtn;
    void Start()
    {
        listBtn = new List<GameObject>();
        SetItemStart();
        //OnClickHat();
    }
    public void SetItemStart(){
        if(shopFullset.fullsetSO.wasEquipped){return;}
        int indexHat = PlayerPrefs.GetInt("IndexHatGO",-1);
        int indexShield = PlayerPrefs.GetInt("IndexShieldGO",-1);
        if(indexHat>=0){
            HatGO[indexHat].SetActive(true);
        }
        if(indexShield>=0){
            ShieldGO[indexShield].SetActive(true);
        }
    }

    public void OnClickPant(){
        indexButton = 1;
        shopFullset.ResetMaterialAndAccessory();  //Reset lại ban đầu
        DestroyBtn(); // Reset button
        buttonPrefab.GetComponent<Image>().sprite = listPantSO.listPant[0].imgSprite; // hiển thị ở button đầu tiên
        int amoutSprite = listPantSO.listPant.Length;  // Lấy số lượng skin
        //Tạo số lượng button theo số lượng skin
        for(int i=1; i<amoutSprite;i++){
            GameObject btnSkin = Instantiate(buttonPrefab,transform);
            btnSkin.transform.SetParent(buttonPrefab.transform.parent);
            btnSkin.GetComponent<Image>().sprite = listPantSO.listPant[i].imgSprite;
            btnSkin.GetComponent<OnClickSkin>().index = i;
            listBtn.Add(btnSkin);
        }
    }
    public void OnClickHat(){
        indexButton = 0;
        shopFullset.ResetMaterialAndAccessory();
        DestroyBtn(); // Reset button
        buttonPrefab.GetComponent<Image>().sprite = spriteHat[0]; 
        int amoutHat = spriteHat.Count();
        //Tạo số lượng button theo số lượng skin
        for(int i=1; i<amoutHat; i++){
            GameObject btnSkin = Instantiate(buttonPrefab,transform);
            btnSkin.transform.SetParent(buttonPrefab.transform.parent);
            btnSkin.GetComponent<Image>().sprite = spriteHat[i];
            btnSkin.GetComponent<OnClickSkin>().index = i;
            listBtn.Add(btnSkin);
        }
        
    }

    public void OnClickShield(){
        indexButton = 2;
        shopFullset.ResetMaterialAndAccessory();
        DestroyBtn(); // Reset button
        buttonPrefab.GetComponent<Image>().sprite = spriteShield[0]; 
        //Tạo số lượng button theo số lượng skin
        GameObject btnSkin = Instantiate(buttonPrefab,transform);
        btnSkin.transform.SetParent(buttonPrefab.transform.parent);
        btnSkin.GetComponent<Image>().sprite = spriteShield[1];
        btnSkin.GetComponent<OnClickSkin>().index = 1;
        listBtn.Add(btnSkin);
    }
    public void OnClickFullset(){
        indexButton = 3;
        DestroyBtn();
        int amoutFullset = shopFullset.fullsetSO.spriteFullset.Count(); // lấy số lượng full set
        buttonPrefab.GetComponent<Image>().sprite = shopFullset.fullsetSO.spriteFullset[0];  // set hình ảnh nút đầu tiên
        //Tạo số lượng button theo số lượng skin
        for(int i=1; i<amoutFullset; i++){
            GameObject btnSkin = Instantiate(buttonPrefab,transform);
            btnSkin.transform.SetParent(buttonPrefab.transform.parent);
            btnSkin.GetComponent<OnClickSkin>().index = i;
            btnSkin.GetComponent<Image>().sprite = shopFullset.fullsetSO.spriteFullset[i];
            listBtn.Add(btnSkin);
        }
    }
    public void DestroyBtn(){
        foreach(var item in listBtn){
            Destroy(item);
        }
    }
    //Khi ấn nút skin
    public void OnClickUISKin(){
        if(shopFullset.fullsetSO.wasEquipped){
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
