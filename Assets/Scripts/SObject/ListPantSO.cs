using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="ListPantSO",menuName ="SO/ListPantSO")]
public class ListPantSO : ScriptableObject
{
    public PantSO[] listPant;
    public int indexPant = 0;

}
