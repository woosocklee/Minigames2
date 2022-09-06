using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuncTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello world");
    }

    // Update is called once per frame
    void Update()
    {
        print("È£¿ì");
        print("È£È£¿ì");
    }

    private void Awake()
    {
        print("Awake");
    }
    private void OnEnable()
    {
        print("OnEnable");
    }
    private void LateUpdate()
    {
        print("LateUpdating...");
    }
    private void FixedUpdate()
    {
        Debug.Log("Fixing");
    }
    private void OnDisable()
    {
        Debug.Log("ÂøÂø ¤²¤²");
    }
}
