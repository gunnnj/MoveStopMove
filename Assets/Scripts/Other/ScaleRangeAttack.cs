using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScaleRangeAttack : MonoBehaviour
{
    public SphereCollider sphereCollider;
    public RawImage imgRangeAttack;
    public Transform body;
    public Score myScore;
    public TextMeshProUGUI txtLevel;
    public int tagLV=1;
    public ParticleSystem particle;
    private Vector3 scaleImage = new Vector3(0.1f,0.1f,0);
    private Vector3 scaleBody = new Vector3(0.075f,0.075f,0.075f);
    private float scaleRadius = 0.5f;
    public CinemachineVirtualCamera camera;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Transform>();
    }

    public void LevelUp(){
        body.localScale+= scaleBody;
        tagLV++;
        txtLevel.text=""+tagLV;
        sphereCollider.radius += scaleRadius;

        if(imgRangeAttack!=null){
            imgRangeAttack.rectTransform.localScale += scaleImage;
        }  
        
        if(camera!=null){
            camera.m_Lens.FieldOfView +=5;
        }
        if(particle!=null){
            particle.Play();
        } 
    }
}
