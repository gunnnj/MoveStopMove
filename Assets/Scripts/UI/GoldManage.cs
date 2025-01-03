using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldManage : MonoBehaviour
{
    public int gold = 1000;
    public static GoldManage instance;

    void Start()
    {
        instance = this;
    }
}
