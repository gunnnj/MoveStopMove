using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "FullsetSO", menuName = "SO/FullsetSO")]

public class FullsetSO : ScriptableObject
{
    public Sprite imgFullset;
    public GameObject fullsetGO;
    public Material materialBody;
    public int priceFullset;
    public bool wasBought;
}
