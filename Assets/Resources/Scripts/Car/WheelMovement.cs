using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Car = null;
    public float maxrot = 30.0f;
    
    [Range(0,3600)]
    public float speed = 720.0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        WheelRot();
    }



    void RotFront()
    {
        this.transform.rotation *= Quaternion.Euler(new Vector3(0, -1, 0) * speed * Time.deltaTime);
    }
    void RotBack()
    {
        this.transform.rotation *= Quaternion.Euler(new Vector3(0, 1, 0) * speed * Time.deltaTime);

    }

    void WheelRot()
    {
        if (Input.GetKey(KeyCode.W))
        {
            RotFront();
        }
        else if (Input.GetKey(KeyCode.S))
        {
            RotBack();
        }
    }
}
