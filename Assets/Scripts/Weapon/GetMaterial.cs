using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GetMaterial : MonoBehaviour
{
    //public ImgSO[] imgSOs;
    public WeaponSO weaponSO;
    private MeshRenderer meshRenderer;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        GetSkin();        
    }
    //Lấy chỉ số skin
    public void GetSkin(){
        int indexSkin = weaponSO.currentSkin;
        ImgSO imgSO = weaponSO.listSkin[indexSkin];
        GetSkinMaterial(imgSO);
    }
    //Lấy skin material
    public void GetSkinMaterial(ImgSO img){
        int materialCount = img.materials.Length;
        Material[] newMaterials = new Material[materialCount];
        for (int j = 0; j < materialCount; j++)
        {
            if (j < meshRenderer.materials.Length)
            {
                newMaterials[j] = new Material(img.materials[j]); 
            }
            else
            {
                Debug.Log("Không đủ materials trong imgSO để gán cho MeshRenderer!");
            }
        }
        meshRenderer.materials = newMaterials; //set material
    }
}
