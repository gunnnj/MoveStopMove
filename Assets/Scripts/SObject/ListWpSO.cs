using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewListWeapon",menuName ="ListWeapon")]
public class ListWpSO : ScriptableObject
{
    public WeaponSO[] weaponSOs;
    public int indexCurrentWp = 0;

}
