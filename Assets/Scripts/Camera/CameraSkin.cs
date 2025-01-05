using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraSkin : MonoBehaviour
{
    public CinemachineVirtualCamera camera;
    private float FOVCam;
    private float FOVCamShopSkin = 50f;
    private float VectorY = 4.2f;
    private Vector3 VectorOffset;

    void Start()
    {
        FOVCam = camera.GetComponent<CinemachineVirtualCamera>().m_Lens.FieldOfView;
        VectorOffset = camera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset;
    }

    public void OnClickShopSkin(){
        camera.GetComponent<CinemachineVirtualCamera>().m_Lens.FieldOfView = FOVCamShopSkin;
        camera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = new Vector3(0,VectorY,-11.25f);  
    }

    public void OnClickCloseShopSkin(){
        camera.GetComponent<CinemachineVirtualCamera>().m_Lens.FieldOfView = FOVCam;
        camera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = VectorOffset;
    }
}
