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

        // for(int i=0; i<imgSOs.Count(); i++){

        //     if(imgSOs[i].isChoose){
                
        //         int materialCount = imgSOs[i].materials.Length;

        //         Material[] newMaterials = new Material[materialCount];

        //         for (int j = 0; j < materialCount; j++)
        //         {
        //             if (j < meshRenderer.materials.Length)
        //             {
        //                 // Gán mỗi material từ ImgSO vào mảng mới, tạo bản sao
        //                 newMaterials[j] = new Material(imgSOs[i].materials[j]); // Tạo bản sao của material
        //             }
        //             else
        //             {
        //                 Debug.Log("Không đủ materials trong imgSO để gán cho MeshRenderer!");
        //             }
        //         }

        //         // Cập nhật materials của MeshRenderer
        //         meshRenderer.materials = newMaterials;
        //     }
        // }
        
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
