using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FullsetSO", menuName = "SO/Fullset")]
public class FullsetSO : ScriptableObject
{
    public Material[] materialBody;
    public Sprite[] spriteFullset;
    public GameObject[] prefabAccessories; //phụ kiện
    public int[] priceFullset;
    public int currentFullset = 0;
    public bool wasEquipped;
}
