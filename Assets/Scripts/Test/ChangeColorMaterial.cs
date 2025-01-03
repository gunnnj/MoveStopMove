using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColorMaterial : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public Material[] materials;
    public int index=0;
    private Color color;

    void Start()
    {
        materials = meshRenderer.materials;
    }

    public void OnClickChange(Button button){
        color = button.GetComponent<Image>().color;
        materials[index].color = color;
    }

    public void ClickIdx(int idx){
        index = idx;
        //btn.GetComponent<Image>().color = color;
    }
}
