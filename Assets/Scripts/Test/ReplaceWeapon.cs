using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaceWeapon : MonoBehaviour
{
    public Transform pos1;
    public Transform pos2;
    public ListWpSO listWpSO;
    public GameObject[] prefabWpfire;
    public PlayerAttack player;

    void Start()
    {
        SpawnWeaponOnHand();
    }
    //Tạo vũ khí theo chỉ số vũ khí đã chọn
    public void SpawnWeaponOnHand(){
        int indexWp = listWpSO.indexCurrentWp;
        WeaponSO weaponSO = listWpSO.weaponSOs[indexWp];
        GameObject weaponGO = weaponSO.prefabWp;
        if(indexWp==2){
            SpawnWeaponWithPrefab(pos2,weaponGO,indexWp);
        }
        else{
            SpawnWeaponWithPrefab(pos1,weaponGO,indexWp);
        }
    }
    public void SpawnWeaponWithPrefab(Transform trans, GameObject prefabWp, int idxWp){

        GameObject instantiatedObject = Instantiate(prefabWp, trans.position, trans.rotation);

        player.weapon = instantiatedObject; 

        player.weaponFire = prefabWpfire[idxWp];

        instantiatedObject.transform.localScale = trans.localScale;

        instantiatedObject.transform.SetParent(trans.parent);
    } 

}
