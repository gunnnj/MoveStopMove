using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationWeapon : MonoBehaviour
{
    [SerializeField] public float rotationSpeed = 1f; // Tốc độ xoay

    void Update()
    {
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
