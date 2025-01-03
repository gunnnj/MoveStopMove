using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectSkin : MonoBehaviour
{
    //public List<WeaponSO> listWP;
    public WeaponSO weaponSO;
    public Button[] buttons;
    public Outline[] outlines;
    public Image imageSkin;
    public TextMeshProUGUI nameWp;
    private Sprite spriteSkin;
    public static SelectSkin instance;
    public GameObject[] weaponGO;
    public GameObject colorChart;
    private int idxCustom = 4;

    void Start()
    {
        instance = this;
        NoDetectMaskWp();
        SetDefaultSkin();
    }
    //Set mặc định
    public void SetDefaultSkin(){
        nameWp.text = weaponSO.Name;
        for(int i=0; i<weaponSO.listSkin.Count()-1; i++){
            buttons[i].GetComponent<Image>().sprite = weaponSO.listSkin[i].skin; // Hiện skin 4 button 
        }
        ColorChart(false);
    }
    //Chọn skin
    public void OnClickBtnSkin(int index){
        imageSkin.gameObject.SetActive(true);
        
        for(int i = 0; i<buttons.Count(); i++){
            if(i==index){
                DetectMaskWp();
                outlines[index].enabled = !outlines[index].enabled;
                if(index == idxCustom){ //Khi chọn skin custom
                    HidenCustomSkin();
                    ColorChart(true);
                }
                else{
                    spriteSkin = buttons[i].GetComponent<Image>().sprite;
                    imageSkin.sprite = spriteSkin;
                    ColorChart(false);
                }     
            }
            else{
                outlines[i].enabled = false;
                NoDetectMaskWp();
            }
        }
        SaveIndexSkin(index);
        CustomSkin.instance.SaveMaterial();
    }
    public void SaveIndexSkin(int idx){
        int indexCurrentWp = SelectWeapon.instance.currentWp;
        SelectWeapon.instance.weaponSOs[indexCurrentWp].currentSkin = idx;
    }
    //Đổi vũ khí ScriptableObject
    public void ChangeWeapon(){
        int idx = SelectWeapon.instance.currentWp;
        weaponSO = SelectWeapon.instance.weaponSOs[idx];
        nameWp.text = weaponSO.Name;
        imageSkin.sprite = SelectWeapon.instance.weaponSOs[idx].listSkin[0].skin;

        for(int i=0; i<weaponSO.listSkin.Count()-1; i++){
            buttons[i].GetComponent<Image>().sprite = weaponSO.listSkin[i].skin;  // Hiện skin 4 button 
        }
    }

    public void HidenCustomSkin(){
        imageSkin.gameObject.SetActive(false);
        
    }
    //Đổi vũ khí GO
    public void ChangeWpGO(int idx){
        for(int i=0; i<3; i++){
            if(i==idx){
                weaponGO[i].SetActive(true);
            }
            else{
                weaponGO[i].SetActive(false);
            }
        }
    }
    //Không phát hiện weapon
    public void NoDetectMaskWp(){
        Camera.main.cullingMask &=~ (1 << LayerMask.NameToLayer("weapon"));
    }

    //Camera mask everything
    public void DetectMaskWp(){
        Camera.main.cullingMask = -1;
    }

    //Ẩn hiện bảng màu
    public void ColorChart(bool display){
        colorChart.SetActive(display);
    }
}
