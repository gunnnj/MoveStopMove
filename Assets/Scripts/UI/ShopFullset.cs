using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class ShopFullset : MonoBehaviour
{
    public FullsetSO fullsetSO;
    public Transform[] transParents;
    public GameObject body;
    public GameObject pants;
    public Material materialNone;
    public ListPantSO listPantSO;
    private Material materialOriginBody;
    private Material materialOriginPant;
    private List<GameObject> listDestroy;

    void Start()
    {
        listDestroy = new List<GameObject>();
        materialOriginBody = body.GetComponent<SkinnedMeshRenderer>().material;
        //Kiểm tra xem có đang trang bị fullset ko?
        if(fullsetSO.wasEquipped){
            SpawnAccessory();
            pants.GetComponent<SkinnedMeshRenderer>().material = materialNone;
        }

    }
    public void SpawnAccessory(){
        ResetMaterialAndAccessory();
        int indexFullset = fullsetSO.currentFullset;
        //Spawn phụ kiện theo loại fullset
        GameObject Acces = Instantiate(fullsetSO.prefabAccessories[indexFullset],transParents[indexFullset].position,transParents[indexFullset].rotation);
        Acces.transform.localScale = transParents[indexFullset].localScale;
        Acces.transform.SetParent(transParents[indexFullset].parent);
        //Set material fullbody
        SetMaterialFullset(indexFullset);
        //Gán vào list để reset
        listDestroy.Add(Acces);
        
    }

    public void SetMaterialFullset(int idx){
        body.GetComponent<SkinnedMeshRenderer>().material = fullsetSO.materialBody[idx];
        pants.GetComponent<SkinnedMeshRenderer>().material = materialNone;
    }
    public void ResetMaterialAndAccessory(){
        foreach(var item in listDestroy){
            Destroy(item);
        }
        body.GetComponent<SkinnedMeshRenderer>().material = materialOriginBody;
        int indexPant = listPantSO.indexPant;
        materialOriginPant = listPantSO.listPant[indexPant].material;
        pants.GetComponent<SkinnedMeshRenderer>().material = materialOriginPant;
        
    }

}
