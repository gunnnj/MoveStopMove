using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="ListShieldSO",menuName ="SO/ListShieldSO")]
public class ListShieldSO : ScriptableObject
{
    public ShieldSO[] shieldSos;
    public int currentIndexShield = -1;
}
