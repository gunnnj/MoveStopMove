using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ListHatSO",menuName ="SO/ListHatSO")]
public class ListHatSO : ScriptableObject
{
    public HatSO[] hatSOs;
    public int currentIndexHat = -1;
}
