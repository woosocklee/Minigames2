using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HNS_PlayerCam : MonoBehaviour
{

    Quaternion starting;
    void Start()
    {
        starting = this.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.rotation = starting;
    }
}
