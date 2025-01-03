using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="PantSO",menuName ="SO/PantSO")]
public class PantSO : ScriptableObject
{
    public Sprite imgSprite;
    public Material material;
    public int Price;
    public bool Unlock;
}
