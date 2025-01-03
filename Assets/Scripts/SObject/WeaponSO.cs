using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewWeapon", menuName = "Weapon")]
public class WeaponSO : ScriptableObject
{
    public string Name;
    public GameObject prefabWp;
    public GameObject prefavWpFire;
    public ImgSO[] listSkin;
    public int priceWp;
    public int currentSkin;
    public bool wasBoughtWp;
}

