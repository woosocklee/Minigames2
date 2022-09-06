using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailWing : MonoBehaviour
{
    // Start is called before the first frame update

    public float rotatespeed = 1080.0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(new Vector3( rotatespeed,0,0) * Time.deltaTime);
    }
}
