using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="HatSO",menuName ="SO/HatSO")]
public class HatSO : ScriptableObject
{
    public GameObject[] litsHatGO;
    public Sprite[] listSprite;
    public int currentHat=0;
}
