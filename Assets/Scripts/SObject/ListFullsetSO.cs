using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ListFullsetSO", menuName = "SO/ListFullset")]
public class ListFullsetSO : ScriptableObject
{
    public FullsetSO[] fullsetSOs;
    public int currentFullset = 0;
    public bool wasEquipped;
}
