using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMaterialPant : MonoBehaviour
{
    public ListPantSO listPantSO;
    public SkinnedMeshRenderer pant;
    public FullsetSO fullsetSO;
    public static GetMaterialPant instance;

    void Start()
    {
        instance = this;
        if(!fullsetSO.wasEquipped){
            GetMaterial();
        }
        
    }

    public void GetMaterial(){
        int indexPant =  listPantSO.indexPant;
        pant.material = listPantSO.listPant[indexPant].material;
    }

}
