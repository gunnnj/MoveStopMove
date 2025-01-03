using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="NewMaterial",menuName ="ImgMaterial")]
public class ImgSO : ScriptableObject
{
    public Sprite skin;
    public Material[] materials; 
    public bool isChoose=false;
}
