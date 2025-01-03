using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetWeapon : MonoBehaviour
{
    public ListWpSO listWpSO;
    public Transform weaponTransform;

    void Start()
    {
        EquippedWp();
        EquippedSkin();
    }
    public void EquippedWp(){
        int indexWp = listWpSO.indexCurrentWp;
        WeaponSO weaponSO = listWpSO.weaponSOs[indexWp];
        GameObject weaponGO = weaponSO.prefabWp;
        Debug.Log(weaponGO.name);
        
    }

    public void EquippedSkin(){
        int indexWp = listWpSO.indexCurrentWp;
        int indexSkin = listWpSO.weaponSOs[indexWp].currentSkin;
        ImgSO imgSO = listWpSO.weaponSOs[indexWp].listSkin[indexSkin];
        Debug.Log(imgSO.name);
    }
}
