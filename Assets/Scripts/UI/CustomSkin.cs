using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CustomSkin : MonoBehaviour
{
    public Material[] materials;
    public int idxPart=0;
    private Color color;
    public Button[] buttons;
    public Button[] buttonPart;
    //public Image[] buttonParts;
    public GameObject[] weaponGOs;
    public MeshRenderer objCus;
    public ImgSO[] imgSOListCus;
    //public ImgSO imgSOCus;
    public static CustomSkin instance;

    //public ImgSO[] listCus;

    void Start()
    {
        instance = this;
        ScaleBtnByAmout();
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() => OnButtonClick(button));
        }
    }
    //Lấy màu của btn
    void OnButtonClick(Button button)
    {
        // Lấy màu từ hình ảnh (Image) của button
        Image buttonImage = button.GetComponent<Image>();
        if (buttonImage != null && buttonImage.sprite != null)
        {
            buttonPart[idxPart].GetComponent<Image>().color = buttonImage.color;
            //Lấy chỉ số của loại vũ khí
            int indexWp = SelectWeapon.instance.currentWp;
            ChangeColor(buttonImage.color, weaponGOs[indexWp]);
        }
    }
    //Lấy chỉ số của material
    public void ClickIdx(int idx){
        idxPart = idx;
    }
    //Hiện số phần theo số lượng material của vũ khí
    public void ScaleBtnByAmout(){
        HideBtn();
        int numBtn = buttonPart.Count();
        //Duyệt để hiện nút có material
        for(int i = 0; i< numBtn; i++){
            int indexWp = SelectWeapon.instance.currentWp; // Lấy chỉ số vũ khí
            int amoutPart = weaponGOs[indexWp].GetComponent<MeshRenderer>().materials.Count(); //Lấy số lượng material của vũ khí
            if(i <= amoutPart-1){
                buttonPart[i].gameObject.SetActive(true); //Hiện nút có phần material
                //Set màu btn là màu của material
                buttonPart[i].GetComponent<Image>().color = weaponGOs[indexWp].GetComponent<MeshRenderer>().materials[i].color;
            }
        }
    }
    //Ẩn nút hiện màu (phần) của vũ khí
    public void HideBtn(){
        int numBtn = buttonPart.Count();
        for(int i = 0; i< numBtn; i++){
            buttonPart[i].gameObject.SetActive(false);
        }
    }
    //Đổi màu theo từng phần của vũ khí
    public void ChangeColor(Color col,GameObject obj){
        Material[] amoutPart = obj.GetComponent<MeshRenderer>().materials;
        if(idxPart<=amoutPart.Count()-1){
            amoutPart[idxPart].color = col;
        }
    }

    public void SaveMaterial(){
        int indexWp = SelectWeapon.instance.currentWp;
        for(int i=0; i<imgSOListCus[indexWp].materials.Count(); i++){
            imgSOListCus[indexWp].materials[i].color = weaponGOs[indexWp].GetComponent<MeshRenderer>().materials[i].color;
        }
        // for(int i=0; i<imgSOCus.materials.Count(); i++){
        //     imgSOCus.materials[i].color = objCus.materials[i].color;
        // }

    }
}
